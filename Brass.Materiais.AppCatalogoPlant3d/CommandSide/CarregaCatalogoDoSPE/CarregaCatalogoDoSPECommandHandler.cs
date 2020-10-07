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
        RepoSPE _repoSPE;
        RepoCatalogo _catalogosMDBRepositorio;
        RepoFamilia _familiasRepositorio;
        RepoItemPipe _itemPipeEstoqueRepositorio;
        RepoValores _valorTabeladoRepositorio;
        RepoNomeTipoPropriedade _nomeTipoPropriedadeRepositorio;
        RepoRelacaoPropriedadeItem _relacaoPropriedadeItemRepositorio;
        RepoIdioma _repoIdioma;
        RepoAtividade _repoAtividade;

        private CatalogoEntidade _catalogo;
        


        public async Task<Unit> Handle(CarregaCatalogoDoSPECommand command, CancellationToken cancellationToken)
        {

            _repoSPE = new RepoSPE(command.Conexao);
            _repoIdioma = new RepoIdioma(command.Conexao);
            _catalogosMDBRepositorio = new RepoCatalogo(command.Conexao);
            _familiasRepositorio = new RepoFamilia(command.Conexao);
            _itemPipeEstoqueRepositorio = new RepoItemPipe(command.Conexao);
            _valorTabeladoRepositorio = RepoValores.Instancia(command.Conexao);
            _nomeTipoPropriedadeRepositorio = new RepoNomeTipoPropriedade(command.Conexao);
            _relacaoPropriedadeItemRepositorio = new RepoRelacaoPropriedadeItem( command.Conexao);
            _repoAtividade = new RepoAtividade(command.Conexao);



            //var spes = _repoSPE.ObterDoNomeDoCatalogo(command.NomeCatalogo);

            defineCatalogo(command); //command.Nome, command.Idioma, command.Pais, command.GuidDisciplina);

            return Unit.Value;
        }

        private CatalogoEntidade defineCatalogo(CarregaCatalogoDoSPECommand command)//string nomeCatalogo, string idiomaParametro, string pais, string guidDisciplina)
        {


            var catalogo = _catalogosMDBRepositorio.ObterPorNome(command.NomeCatalogo);

            if (catalogo == null )
            {

                string guidIdioma = string.Empty;



                var idioma = _repoIdioma.ObterIdiomaPorLinguaPais(command.Idioma, command.Pais);


                if (idioma == null)
                {
                    //guidIdioma = Guid.NewGuid().ToString();
                    idioma = new Idioma(command.Idioma, command.Pais);
                    _repoIdioma.Cadastrar(idioma);
                }
              

                _catalogo = new CatalogoEntidade(command.NomeCatalogo, guidIdioma, command.GuidDisciplina);
                _catalogosMDBRepositorio.CadastrarCatalogo(_catalogo);

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

                _valorTabeladoRepositorio.CadastrarValor(valorTabelado);
            }
            else
            {
                valorTabelado = valoresTabelados.First();
            }

            return valorTabelado;
        }
    }
}
