using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
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
        RepoCatalogo _catalogosMDBRepositorio;
        RepoFamilia _familiasRepositorio;
        RepoItemPipe _itemPipeEstoqueRepositorio;
        RepoValores  _valorTabeladoRepositorio;
        RepoNomeTipoPropriedade _nomeTipoPropriedadeRepositorio; 
        RepoRelacaoPropriedadeItem _relacaoPropriedadeItemRepositorio;
        RepoIdioma _idiomaMDBRepositorio;
        CatalogoEntidade _catalogo;
        RepoPropriedadeItem _repoPropriedadeItem;




        public async Task<Unit> Handle(CarregaCatalogoCompletoTubulacaoCommand command, CancellationToken cancellationToken)
        {
            _catalogosMDBRepositorio = new RepoCatalogo(command.Conexao);
            _familiasRepositorio = new RepoFamilia(command.Conexao);
            _itemPipeEstoqueRepositorio = new RepoItemPipe(command.Conexao);
            _valorTabeladoRepositorio = RepoValores.Instancia(command.Conexao);
            _nomeTipoPropriedadeRepositorio = new RepoNomeTipoPropriedade(command.Conexao);
            _relacaoPropriedadeItemRepositorio = new RepoRelacaoPropriedadeItem(command.Conexao);
            _idiomaMDBRepositorio = new RepoIdioma(command.Conexao);
            _repoPropriedadeItem = new RepoPropriedadeItem(command.Conexao);

            defineCatalogo(command);

            injetar(command);

            return Unit.Value;
        }

        private string defineCatalogo(CarregaCatalogoCompletoTubulacaoCommand command)
        {
            string nomeCatalogo = command.Endereco.Split('\\').Last().Split('.').First();

            var catalogo = _catalogosMDBRepositorio.ObterPorNome(nomeCatalogo);
    
            if (catalogo == null)
            {

  
                var idioma = _idiomaMDBRepositorio.ObterPorIdiomaComPais(command.Idioma, command.Pais); 


                if (idioma == null)
                {
                    idioma = new Idioma(command.Idioma, command.Pais);
                    _idiomaMDBRepositorio.Cadastrar(idioma);
                }
             

                _catalogo = new CatalogoEntidade(nomeCatalogo, idioma.GUID, command.GuidDisciplina);
                _catalogosMDBRepositorio.CadastrarCatalogo(_catalogo);

            }
            else
            {
                _catalogo = catalogo;
            }

            return nomeCatalogo;
        }

        public void injetar(CarregaCatalogoCompletoTubulacaoCommand command)
        {
          

            int conta = _itemPipeEstoqueRepositorio.ObterTodos().Count();

            if (conta < command.EngineeringItems.Count())
            {


                foreach (var item in command.EngineeringItems)
                {

                    var partFamilyLongDesc = item.PartFamilyLongDesc;

                    var familia = _familiasRepositorio.ObterFamiliaPorDescricao(partFamilyLongDesc);


                    if (familia != null)
                    {
                        var itemPipeEstoque = _itemPipeEstoqueRepositorio.ObterPorPnPIDComCatalogo((int)item.PnPID, _catalogo.GUID);
 
                        if (itemPipeEstoque == null)
                        {

                            
                            var itemPipe = new ItemPipe(familia.GUID, "",_catalogo.GUID,(int)item.PnPID);

                            _itemPipeEstoqueRepositorio.CadastrarItemPipe(itemPipe);

                            Type type = item.GetType();

                            foreach (var info in type.GetProperties())
                            {

                                if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                                {

                            

                                    var nomeTipoPropriedade = _nomeTipoPropriedadeRepositorio.ObterPorNome(info.Name);

                                    if (nomeTipoPropriedade == null)
                                    {
                                        nomeTipoPropriedade = new NomeTipoPropriedade(info.Name);

                                        _nomeTipoPropriedadeRepositorio.CadastrarNomeTipoPropriedade(nomeTipoPropriedade);

                                    }
                                   

                                    var valor = info.GetValue(item, null);

                                    if (valor != null)
                                    {

                                       

                                        ValorTabelado valorTabelado = CriaValorTabelado(valor);

                                        

                                        var propriedadeEng = _repoPropriedadeItem.ObterPorTipoMaisValor(nomeTipoPropriedade.GUID, valorTabelado.GUID);

                                        if (propriedadeEng == null)
                                        {

                                            propriedadeEng = new PropriedadeItem(nomeTipoPropriedade.GUID, valorTabelado.GUID);


                                            _repoPropriedadeItem.Cadastrar(propriedadeEng);


                                        }

                                        var relacaoPropriedadeItem = new RelacaoPropriedadeItem(propriedadeEng.GUID, itemPipe.GUID);

                                        _relacaoPropriedadeItemRepositorio.Cadastrar(relacaoPropriedadeItem);


                                    }
                                }
                            }

                        }

                    }

                }

            }

        }

        private ValorTabelado CriaValorTabelado(object valor)
        {
            var valorTabelado = _valorTabeladoRepositorio.ObterDescricao(valor.ToString());

            if (valorTabelado == null)
            {
                valorTabelado = new ValorTabelado(valor.ToString(), "");

                _valorTabeladoRepositorio.CadastrarValor(valorTabelado);
            }
           

            return valorTabelado;
        }




    }
}
