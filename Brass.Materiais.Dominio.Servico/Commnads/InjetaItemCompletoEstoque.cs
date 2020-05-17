using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using Brass.Materiais.RepositorioSQLServer;
using Brass.Materiais.RepositorioSQLServer.Service;
using MongoDB.Driver;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class InjetaItemCompletoEstoque
    {

        private string _endereco;
        private string _idioma;
        private string _pais;
        private string _conexao;
        private Catalogo _catalogo;

        public InjetaItemCompletoEstoque(string endereco, string idioma, string pais, string conexao)
        {

            _conexao = conexao;
            _endereco = endereco;
            _idioma = idioma;
            _pais = pais;

            string nomeCatalogo = _endereco.Split('\\').Last().Split('.').First();

            DefineCatalogo(nomeCatalogo);

            ConexaoSQLite.BuildConnectionString(endereco);

        }

        private void DefineCatalogo(string nomeCatalogo)
        {
            //Catalogo catalogo = null;

            var catalogosMDBRepositorio = new BaseMDBRepositorio<Catalogo>("Catalogo", "Catalogo");

            //using (var repositorioCatalogo = new Repositorio<CatalogoPlant3d>(_conexao))
            //{


            var catalogos = catalogosMDBRepositorio
                .Encontrar(Builders<Catalogo>.Filter.Eq(x => x.NOME, nomeCatalogo));
            //repositorioCatalogo.Find(x => x.NOME == nomeCatalogo);


            if (catalogos.Count == 0)
            {

                string guidIdioma = string.Empty;

                var idiomaMDBRepositorio = new BaseMDBRepositorio<Idioma>("Catalogo", "Idioma");

                var builder = Builders<Idioma>.Filter;
                var filter = builder.Eq(x => x.IDIOMA, _idioma) & builder.Eq(x => x.PAIS, _pais);

                var idiomas = idiomaMDBRepositorio.Encontrar(filter);


                if (idiomas.Count == 0)
                {
                    guidIdioma = Guid.NewGuid().ToString();
                    var idioma = new Idioma()
                    {
                        IDIOMA = _idioma,
                        PAIS = _pais
                    };

                    idiomaMDBRepositorio.Inserir(idioma);
                }
                else
                {
                    guidIdioma = idiomas.First().GUID;
                }


                _catalogo = new Catalogo()
                {
                    NOME = nomeCatalogo,
                    GUID_IDIOMA = guidIdioma
                };

                catalogosMDBRepositorio.Inserir(_catalogo);
            }
            else
            {
                _catalogo = catalogos.First();
            }

            //}

            //return _catalogo;
        }

        public void PegaTipos()
        {
            var itemPipeEstoqueRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

            var filtro = Builders<ItemPipe>.Filter.Eq(x => x.GUID_ITEM_PAI, _catalogo.GUID);

            var itensPipeCategoria = itemPipeEstoqueRepositorio.Encontrar(filtro);
        }

        public void Injetar()
        {


            var itensEngenhariaP3D = capturarItensEngenhariaPlant3d();


            //for (int i = 1; i <= itensEngenhariaP3D.Count(); i++)
            //{



            var itemPipeEstoqueRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

            int conta = itemPipeEstoqueRepositorio.Obter().Count();

            if (conta < itensEngenhariaP3D.Count())
            {


                foreach (var item in itensEngenhariaP3D)
                {








                    var builder = Builders<ItemPipe>.Filter;
                    var filterItemPipeEstoque = builder.Eq(x => x.PnPID, (int)item.PnPID) & builder.Eq(x => x.GUID_CATALOGO, _catalogo.GUID);
                    var itensPipeEstoque = itemPipeEstoqueRepositorio.Encontrar(filterItemPipeEstoque);



                    if (itensPipeEstoque.Count == 0)
                    {

                        TipoItemEng tipoItem = null;
                        string tipoItemEng = item.ShortDescription.Split(',')[0];



                        var tipoItemPipeStockRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");

                        var filterTiposItem = Builders<TipoItemEng>.Filter.Eq(x => x.NOME, tipoItemEng);

                        var tipos = tipoItemPipeStockRepositorio.Encontrar(filterTiposItem);



                        if (tipos.Count == 0)
                        {
                            tipoItem = new TipoItemEng()
                            {
                                NOME = tipoItemEng
                            };

                            tipoItemPipeStockRepositorio.Inserir(tipoItem);

                        }
                        else
                        {
                            tipoItem = tipos.First();
                        }


                        var itemPipe = new ItemPipe()
                        {
                            GUID_TIPO_ITEM = tipoItem.GUID,
                            GUID_CATALOGO = _catalogo.GUID,
                            PnPID = (int)item.PnPID
                        };

                        itemPipeEstoqueRepositorio.Inserir(itemPipe);

                        Type type = item.GetType();

                        foreach (var info in type.GetProperties())
                        {

                            if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                            {

                                NomeTipoPropriedade nomeTipoPropriedade = null;


                                var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
                                var filterNomeTipoPropriedade = Builders<NomeTipoPropriedade>.Filter.Eq(x => x.NOME, info.Name);
                                var nomesTiposPropriedade = nomeTipoPropriedadeRepositorio.Encontrar(filterNomeTipoPropriedade);



                                if (nomesTiposPropriedade.Count == 0)
                                {
                                    nomeTipoPropriedade = new NomeTipoPropriedade()
                                    {
                                        NOME = info.Name
                                    };

                                    nomeTipoPropriedadeRepositorio.Inserir(nomeTipoPropriedade);


                                }
                                else
                                {
                                    nomeTipoPropriedade = nomesTiposPropriedade.First();
                                }




                                var relacaoEntrePropriedadesRepositorio = new BaseMDBRepositorio<RelacaoEntrePropriedades>("Catalogo", "RelacaoEntrePropriedades");
                                var builderRelacaoEntrePropriedades = Builders<RelacaoEntrePropriedades>.Filter;
                                var filtroRelacaoEntrePropriedades = builderRelacaoEntrePropriedades
                                    .Eq(x => x.GUID_PNPTABLE, tipoItem.GUID)
                                    &
                                    builderRelacaoEntrePropriedades
                                    .Eq(x => x.GUID_PROPIEDADE, nomeTipoPropriedade.GUID);

                                var relacoes = relacaoEntrePropriedadesRepositorio.Encontrar(filtroRelacaoEntrePropriedades);


                                if (relacoes.Count == 0)
                                {
                                    var relacao = new RelacaoEntrePropriedades()
                                    {
                                        GUID_PNPTABLE = tipoItem.GUID,
                                        GUID_PROPIEDADE = nomeTipoPropriedade.GUID
                                    };

                                    relacaoEntrePropriedadesRepositorio.Inserir(relacao);

                                }






                                PropertyInfo campo = type.GetProperty(info.Name);
                                var valor = info.GetValue(item, null);

                                if (valor != null)
                                {


                                    var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
                                    var filterValorTabelado = Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, valor.ToString());
                                    var valoresTabelados = valorTabeladoRepositorio.Encontrar(filterValorTabelado);


                                    ValorTabelado valorTabelado = null;

                                    if (valoresTabelados.Count == 0)
                                    {
                                        valorTabelado = new ValorTabelado()
                                        {
                                            VALOR = valor.ToString(),
                                            Sigla_BRASS = ""
                                        };

                                        valorTabeladoRepositorio.Inserir(valorTabelado);
                                    }
                                    else
                                    {
                                        valorTabelado = valoresTabelados.First();
                                    }


                                    if (nomeTipoPropriedade.NOME == "PartCategory")
                                    {

                                        ItemPipe itemCategoria = null;
                                        var builderItem = Builders<ItemPipe>.Filter;
                                        var filterItem = builderItem.Eq(x => x.GUID, valorTabelado.GUID)
                                            & builderItem.Eq(x => x.GUID_CATALOGO, _catalogo.GUID);
                                        var itens = itemPipeEstoqueRepositorio.Encontrar(filterItem);

                                        if (itens.Count == 0)
                                        {
                                            itemCategoria = new ItemPipe()
                                            {
                                                GUID_TIPO_ITEM = nomeTipoPropriedade.GUID,
                                                GUID_CATALOGO = _catalogo.GUID,
                                                PnPID = 0,
                                                GUID_ITEM_PAI = _catalogo.GUID
                                            };

                                            itemPipeEstoqueRepositorio.Inserir(itemCategoria);
                                        }
                                        else
                                        {
                                            itemCategoria = itens.First();
                                        }

                                        itemPipe.GUID_ITEM_PAI = itemCategoria.GUID;


                                        itemPipeEstoqueRepositorio.Atualizar(itemPipe);

                                    }

                                    






                                    PropriedadeItem propriedadeEng = null;

                                    var propriedadeRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
                                    var builderPropriedade = Builders<PropriedadeItem>.Filter;
                                    var filterPropriedade =
                                        builderPropriedade.Eq(x => x.GUID_TIPO, nomeTipoPropriedade.GUID)
                                        & builderPropriedade.Eq(x => x.GUID_VALOR, valorTabelado.GUID);
                                    var propriedades = propriedadeRepositorio.Encontrar(filterPropriedade);

                                    if (propriedades.Count == 0)
                                    {

                                        propriedadeEng = new PropriedadeItem(nomeTipoPropriedade.GUID, valorTabelado.GUID);
                                      

                                        propriedadeRepositorio.Inserir(propriedadeEng);


                                    }
                                    else
                                    {
                                        propriedadeEng = propriedades.First();
                                    }


                                    var relacaoPropriedadeItemRepositorio =
                                        new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");


                                    var relacaoPropriedadeItem = new RelacaoPropriedadeItem(propriedadeEng.GUID, itemPipe.GUID);
                                    


                                    relacaoPropriedadeItemRepositorio.Inserir(relacaoPropriedadeItem);


                                }
                            }
                        }

                    }

                }

            }


            //}


        }


        private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        {


            List<EngineeringItems> listaResult;

            var repoSQLiteService = new RepositorioService<EngineeringItems>();
            var dominioService = new DominioService<EngineeringItems>(repoSQLiteService);


            //using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>(_conexao))
            ///{
            dominioService.Start(Storage.ConnectionString);

            listaResult = (List<EngineeringItems>)dominioService.GetAll();

            dominioService.Dispose();
            //}

            return listaResult;

        }
    }
}
