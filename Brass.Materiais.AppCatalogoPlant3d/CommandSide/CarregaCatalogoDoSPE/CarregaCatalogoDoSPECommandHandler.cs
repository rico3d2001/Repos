using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoDoSPE
{
    public class CarregaCatalogoDoSPECommandHandler : Notifiable, IRequestHandler<CarregaCatalogoDoSPECommand>
    {
        BaseMDBRepositorio<ItemSPE> _repoSPE;
        BaseMDBRepositorio<CatalogoEntidade> _catalogosMDBRepositorio;
        RepoFamilia _familiasRepositorio;
        RepoItemPipe _itemPipeEstoqueRepositorio;
        BaseMDBRepositorio<ValorTabelado> _valorTabeladoRepositorio;
        BaseMDBRepositorio<NomeTipoPropriedade> _nomeTipoPropriedadeRepositorio;
        BaseMDBRepositorio<RelacaoPropriedadeItem> _relacaoPropriedadeItemRepositorio;
        BaseMDBRepositorio<Idioma> _repoIdioma;
        RepoAtividade _repoAtividade;

        private CatalogoEntidade _catalogo;
        public CarregaCatalogoDoSPECommandHandler()
        {
            _repoSPE = new BaseMDBRepositorio<ItemSPE>("Catalogo", "SPE");
            _repoIdioma = new BaseMDBRepositorio<Idioma>("Catalogo", "Idioma");
            _catalogosMDBRepositorio = new BaseMDBRepositorio<CatalogoEntidade>("Catalogo", "Catalogo");
            _familiasRepositorio = new RepoFamilia();
            _itemPipeEstoqueRepositorio = new RepoItemPipe();
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
            _nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            _relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
            _repoAtividade = new RepoAtividade();
        }


        public async Task<Unit> Handle(CarregaCatalogoDoSPECommand command, CancellationToken cancellationToken)
        {

            var spes = _repoSPE.Encontrar(Builders<ItemSPE>.Filter.Eq(x => x.SPEBook.Nome, command.NomeCatalogo)).ToList();

            defineCatalogo(command); //command.Nome, command.Idioma, command.Pais, command.GuidDisciplina);

            return Unit.Value;
        }

        private CatalogoEntidade defineCatalogo(CarregaCatalogoDoSPECommand command)//string nomeCatalogo, string idiomaParametro, string pais, string guidDisciplina)
        {


            var catalogos = _catalogosMDBRepositorio
                .Encontrar(Builders<CatalogoEntidade>.Filter.Eq(x => x.NOME, command.NomeCatalogo));

            if (catalogos.Count == 0)
            {

                string guidIdioma = string.Empty;



                var idiomas = _repoIdioma.Encontrar(
                    Builders<Idioma>.Filter.Eq(x => x.IDIOMA, command.Idioma)
                    & Builders<Idioma>.Filter.Eq(x => x.PAIS, command.Pais));


                if (idiomas.Count == 0)
                {
                    guidIdioma = Guid.NewGuid().ToString();
                    var idioma = new Idioma(command.Idioma, command.Pais);
                    _repoIdioma.Inserir(idioma);
                }
                else
                {
                    guidIdioma = idiomas.First().GUID;
                }

                _catalogo = new CatalogoEntidade(command.NomeCatalogo, guidIdioma, command.GuidDisciplina);
                _catalogosMDBRepositorio.Inserir(_catalogo);

            }
            else
            {
                _catalogo = catalogos.First();
            }

            return _catalogo;
        }

        public void injetar(List<ItemSPE> itensSPE)
        {
            //var nivel_K = "";
            //var nivel_TT = "";
            //var nivel_UU = "";
            //var nivel_VVV = "";
            //var nivel_WWW = "";



            int itemPipePnpID = 0;



            foreach (var itemSPE in itensSPE)
            {
                Atividade atividade = null;
                Familia familia = null;

                if (itemSPE.Nivel_WWW == "000")
                {
                    if (itemSPE.Nivel_VVV != "000")
                    {
                        atividade = _repoAtividade.ObterDoNivelVVVporDescicao(itemSPE.Descricao);
                        familia = _familiasRepositorio.ObterFamiliaPorDescricao(itemSPE.Descricao);
                        if(familia == null)
                        {
                            //familia = new Familia(_catalogo.GUID,_catalogo.)
                        }
                    }

                }
                else
                {

                    var guidFamilia = familia.GUID;


                    //var itensPipeEstoque = _itemPipeEstoqueRepositorio.Encontrar(
                    //    Builders<ItemPipe>.Filter.Eq(x => x.PnPID, (int)item.PnPID)
                    //    & Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, _catalogo.GUID)).ToList();

                    var itemPipe = _itemPipeEstoqueRepositorio.ObterPorGuid(itemSPE.GUID);



                    if (itemPipe == null)
                    {
                        itemPipePnpID++;

                        itemPipe = new ItemPipe(guidFamilia, "", _catalogo.GUID, itemPipePnpID);

                        //itemPipe.GUID_ATIVIDADE;

        //                public string GUID_TIPO_ITEM { get; set; }
        //public string GUID_CATALOGO { get; set; }
        //public string GUID_ITEM_PAI { get; set; }
        //public int PnPID { get; set; }

                        //public string GUID_ATIVIDADE { get; set; }
                        //public string GUID_FAMILIA { get; set; }


                        _itemPipeEstoqueRepositorio.CadastrarItemPipe(itemPipe);

                    

                    }


                }

                //var partFamilyLongDesc = item.PartFamilyLongDesc;

                //var familias = _familiasRepositorio.Encontrar(Builders<Familia>.Filter.Eq(x => x.PartFamilyLongDesc.VALOR, partFamilyLongDesc)).ToList();

                //string guidFamilia = "";
                //if (familias.Count == 1)
                //{
                //    guidFamilia = familias.First().GUID;


                //    var itensPipeEstoque = _itemPipeEstoqueRepositorio.Encontrar(
                //        Builders<ItemPipe>.Filter.Eq(x => x.PnPID, (int)item.PnPID)
                //        & Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, _catalogo.GUID)).ToList();



                //    if (itensPipeEstoque.Count == 0)
                //    {


                //        var itemPipe = new ItemPipe(guidFamilia, "", _catalogo.GUID, (int)item.PnPID);

                //        _itemPipeEstoqueRepositorio.Inserir(itemPipe);

                //        Type type = item.GetType();

                //        foreach (var info in type.GetProperties())
                //        {

                //            if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                //            {

                //                NomeTipoPropriedade nomeTipoPropriedade = null;




                //                var nomesTiposPropriedade = _nomeTipoPropriedadeRepositorio.Encontrar(
                //                              Builders<NomeTipoPropriedade>.Filter.Eq(x => x.NOME, info.Name));



                //                if (nomesTiposPropriedade.Count == 0)
                //                {
                //                    nomeTipoPropriedade = new NomeTipoPropriedade(info.Name);

                //                    _nomeTipoPropriedadeRepositorio.Inserir(nomeTipoPropriedade);

                //                }
                //                else
                //                {
                //                    nomeTipoPropriedade = nomesTiposPropriedade.First();
                //                }



                //                PropertyInfo campo = type.GetProperty(info.Name);
                //                var valor = info.GetValue(item, null);

                //                if (valor != null)
                //                {




                //                    var valoresTabelados = _valorTabeladoRepositorio.Encontrar(
                //                          Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, valor.ToString()));

                //                    ValorTabelado valorTabelado = CriaValorTabelado(valor, valoresTabelados);

                //                    PropriedadeItem propriedadeEng = null;

                //                    var propriedadeRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");


                //                    var propriedades = propriedadeRepositorio.Encontrar(
                //                        Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, nomeTipoPropriedade.GUID)
                //                        & Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_VALOR, valorTabelado.GUID));

                //                    if (propriedades.Count == 0)
                //                    {

                //                        propriedadeEng = new PropriedadeItem(nomeTipoPropriedade.GUID, valorTabelado.GUID);


                //                        propriedadeRepositorio.Inserir(propriedadeEng);


                //                    }
                //                    else
                //                    {
                //                        propriedadeEng = propriedades.First();
                //                    }





                //                    var relacaoPropriedadeItem = new RelacaoPropriedadeItem(propriedadeEng.GUID, itemPipe.GUID);



                //                    _relacaoPropriedadeItemRepositorio.Inserir(relacaoPropriedadeItem);


                //                }
                //            }
                //        }

                //    }

                //}

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
