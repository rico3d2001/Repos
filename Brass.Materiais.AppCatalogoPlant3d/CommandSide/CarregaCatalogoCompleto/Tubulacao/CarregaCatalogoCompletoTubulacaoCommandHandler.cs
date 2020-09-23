using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Tubulacao
{
    public class CarregaCatalogoCompletoTubulacaoCommandHandler : Notifiable, IRequestHandler<CarregaCatalogoCompletoTubulacaoCommand>
    {
        BaseMDBRepositorio<CatalogoEntidade> _catalogosMDBRepositorio;
        BaseMDBRepositorio<Familia> _familiasRepositorio;
        BaseMDBRepositorio<ItemPipe> _itemPipeEstoqueRepositorio;
        BaseMDBRepositorio<ValorTabelado> _valorTabeladoRepositorio;
        BaseMDBRepositorio<NomeTipoPropriedade> _nomeTipoPropriedadeRepositorio; 
        BaseMDBRepositorio<RelacaoPropriedadeItem> _relacaoPropriedadeItemRepositorio;

        private CatalogoEntidade _catalogo;

        public CarregaCatalogoCompletoTubulacaoCommandHandler()
        {
            _catalogosMDBRepositorio = new BaseMDBRepositorio<CatalogoEntidade>("Catalogo", "Catalogo");
            _familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            _itemPipeEstoqueRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
            _nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            _relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
        }


        public async Task<Unit> Handle(CarregaCatalogoCompletoTubulacaoCommand command, CancellationToken cancellationToken)
        {

            defineCatalogo(command);

            injetar(command);

            return Unit.Value;
        }

        private string defineCatalogo(CarregaCatalogoCompletoTubulacaoCommand command)
        {
            string nomeCatalogo = command.Endereco.Split('\\').Last().Split('.').First();

            var catalogos = _catalogosMDBRepositorio
                .Encontrar(Builders<CatalogoEntidade>.Filter.Eq(x => x.NOME, nomeCatalogo));
    
            if (catalogos.Count == 0)
            {

                string guidIdioma = string.Empty;

                var idiomaMDBRepositorio = new BaseMDBRepositorio<Idioma>("Catalogo", "Idioma");

                var builder = Builders<Idioma>.Filter;
                var filter = builder.Eq(x => x.IDIOMA, command.Idioma) & builder.Eq(x => x.PAIS, command.Pais);

                var idiomas = idiomaMDBRepositorio.Encontrar(filter);


                if (idiomas.Count == 0)
                {
                    guidIdioma = Guid.NewGuid().ToString();
                    var idioma = new Idioma(command.Idioma, command.Pais);
                    idiomaMDBRepositorio.Inserir(idioma);
                }
                else
                {
                    guidIdioma = idiomas.First().GUID;
                }

                _catalogo = new CatalogoEntidade(nomeCatalogo,guidIdioma, command.GuidDisciplina);
                _catalogosMDBRepositorio.Inserir(_catalogo);

            }
            else
            {
                _catalogo = catalogos.First();
            }

            return nomeCatalogo;
        }

        public void injetar(CarregaCatalogoCompletoTubulacaoCommand command)
        {
          

            

            

            int conta = _itemPipeEstoqueRepositorio.Obter().Count();

            if (conta < command.EngineeringItems.Count())
            {


                foreach (var item in command.EngineeringItems)
                {

                    var partFamilyLongDesc = item.PartFamilyLongDesc;

                    var familias = _familiasRepositorio.Encontrar(Builders<Familia>.Filter.Eq(x => x.PartFamilyLongDesc.VALOR, partFamilyLongDesc)).ToList();

                    string guidFamilia = "";
                    if (familias.Count == 1)
                    {
                        guidFamilia = familias.First().GUID;


                        var itensPipeEstoque = _itemPipeEstoqueRepositorio.Encontrar(
                            Builders<ItemPipe>.Filter.Eq(x => x.PnPID, (int)item.PnPID)
                            & Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, _catalogo.GUID)).ToList();



                        if (itensPipeEstoque.Count == 0)
                        {

                            
                            var itemPipe = new ItemPipe(guidFamilia,"",_catalogo.GUID,(int)item.PnPID);

                            _itemPipeEstoqueRepositorio.Inserir(itemPipe);

                            Type type = item.GetType();

                            foreach (var info in type.GetProperties())
                            {

                                if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                                {

                                    NomeTipoPropriedade nomeTipoPropriedade = null;


                                    

                                    var nomesTiposPropriedade = _nomeTipoPropriedadeRepositorio.Encontrar(
                                                  Builders<NomeTipoPropriedade>.Filter.Eq(x => x.NOME, info.Name));



                                    if (nomesTiposPropriedade.Count == 0)
                                    {
                                        nomeTipoPropriedade = new NomeTipoPropriedade(info.Name);

                                        _nomeTipoPropriedadeRepositorio.Inserir(nomeTipoPropriedade);

                                    }
                                    else
                                    {
                                        nomeTipoPropriedade = nomesTiposPropriedade.First();
                                    }

                                 

                                    PropertyInfo campo = type.GetProperty(info.Name);
                                    var valor = info.GetValue(item, null);

                                    if (valor != null)
                                    {




                                        var valoresTabelados = _valorTabeladoRepositorio.Encontrar(
                                              Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, valor.ToString()));

                                        ValorTabelado valorTabelado = CriaValorTabelado(valor, valoresTabelados);

                                        PropriedadeItem propriedadeEng = null;

                                        var propriedadeRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");


                                        var propriedades = propriedadeRepositorio.Encontrar(
                                            Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, nomeTipoPropriedade.GUID)
                                            & Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_VALOR, valorTabelado.GUID));

                                        if (propriedades.Count == 0)
                                        {

                                            propriedadeEng = new PropriedadeItem(nomeTipoPropriedade.GUID, valorTabelado.GUID);


                                            propriedadeRepositorio.Inserir(propriedadeEng);


                                        }
                                        else
                                        {
                                            propriedadeEng = propriedades.First();
                                        }





                                        var relacaoPropriedadeItem = new RelacaoPropriedadeItem(propriedadeEng.GUID, itemPipe.GUID);



                                        _relacaoPropriedadeItemRepositorio.Inserir(relacaoPropriedadeItem);


                                    }
                                }
                            }

                        }

                    }

                }

            }

        }

        private ValorTabelado CriaValorTabelado(object valor, List<ValorTabelado> valoresTabelados)
        {
            ValorTabelado valorTabelado = null;

            if (valoresTabelados.Count == 0)
            {
                valorTabelado = new ValorTabelado(valor.ToString(), "");

                _valorTabeladoRepositorio.Inserir(valorTabelado);
            }
            else
            {
                valorTabelado = valoresTabelados.First();
            }

            return valorTabelado;
        }




    }
}
