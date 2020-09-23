using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Brass.Materiais.RepositorioSQLServer;
using Brass.Materiais.RepositorioSQLServer.Service;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Brass.Materiais.AppCatalogoPlant3d.Service
{
    public class InjetaItemCompleto
    {

        private string _endereco;
        private string _idioma;
        private string _pais;
        private string _conexao;
        private CatalogoPlant3d _catalogo;

        public InjetaItemCompleto(string endereco, string idioma, string pais, string conexao)
        {

            _conexao = conexao;
            _endereco = endereco;
            _idioma = idioma;
            _pais = pais;

            string nomeCatalogo = _endereco.Split('\\').Last().Split('.').First();

            _catalogo = DefineCatalogo(nomeCatalogo);

            ConexaoSQLite.BuildConnectionString(endereco);

        }

        private CatalogoPlant3d DefineCatalogo(string nomeCatalogo)
        {
            CatalogoPlant3d catalogo = null;


            using (var repositorioCatalogo = new Repositorio<CatalogoPlant3d>(_conexao))
            {

                catalogo = repositorioCatalogo.Find(x => x.NOME == nomeCatalogo);


                if (catalogo == null)
                {

                    string guidIdioma = string.Empty;

                    using (var repositorioIdioma = new Repositorio<CT_Idioma>(_conexao))
                    {
                        guidIdioma = repositorioIdioma.Find(x => x.IDIOMA == _idioma && x.PAIS == _pais).GUID;
                    }


                    catalogo = new CatalogoPlant3d()
                    {
                        GUID = Guid.NewGuid().ToString(),
                        NOME = nomeCatalogo,
                        GUID_IDIOMA = guidIdioma
                    };

                    repositorioCatalogo.Insert(catalogo);
                }

            }

            return catalogo;
        }

        public void Injetar()
        {

           
            var itensEngenhariaP3D = capturarItensEngenhariaPlant3d();

            //if (itensEngenhariaP3D.Count() > 0)
            for (int i = 1; i <= itensEngenhariaP3D.Count(); i++)
            {




                //string nomeCatalogo = _endereco.Split('\\').Last().Split('.').First();

                //CatalogoPlant3d catalogo = DefineCatalogo(nomeCatalogo);

                using (var repositorioItemEngenharia = new Repositorio<ItemEngenharia>(_conexao))
                {

                    //var itensCategoria = repositorioItemEngenharia.Query(x => x.GUID_ITEM_PAI == catalogo.GUID).ToList();

                    foreach (var item in itensEngenhariaP3D)
                    {

                        ItemEngenharia itemEngenharia = null;



                        itemEngenharia = repositorioItemEngenharia.Find(x => x.PnPID == (int)item.PnPID && x.GUID_CATALOGO == _catalogo.GUID);

                        if (itemEngenharia == null)
                        {

                            TipoItem tipoItem = null;
                            string tipoItemEng = item.ShortDescription.Split(',')[0];

                            using (var repositorioTiposItem = new Repositorio<TipoItem>(_conexao))
                            {

                                tipoItem = repositorioTiposItem.Find(x => x.NOME == tipoItemEng);
                                if (tipoItem == null)
                                {
                                    tipoItem = new TipoItem()
                                    {
                                        GUID = Guid.NewGuid().ToString(),
                                        NOME = tipoItemEng
                                    };

                                    repositorioTiposItem.Insert(tipoItem);


                                }
                            }







                            itemEngenharia = new ItemEngenharia()
                            {
                                GUID = Guid.NewGuid().ToString(),
                                GUID_TIPO_ITEM = tipoItem.GUID,
                                GUID_CATALOGO = _catalogo.GUID,
                                PnPID = (int)item.PnPID
                            };

                            repositorioItemEngenharia.Insert(itemEngenharia);

                            Type type = item.GetType();

                            foreach (var info in type.GetProperties())
                            {

                                PropriedadeItemEng propriedadeItemEng;



                                if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                                {

                                    TipoPropriedade tipoPropriedade = null;
                                    using (var repositorioTipos = new Repositorio<TipoPropriedade>(_conexao))
                                    {

                                        tipoPropriedade = repositorioTipos.Find(x => x.NOME == info.Name);

                                        if (tipoPropriedade == null)
                                        {
                                            tipoPropriedade = new TipoPropriedade()
                                            {
                                                GUID = Guid.NewGuid().ToString(),
                                                NOME = info.Name
                                            };

                                            repositorioTipos.Insert(tipoPropriedade);


                                        }
                                    }






                                    using (var repositorioPropRelacionadas = new Repositorio<PrpiedadesRelacionadas>(_conexao))
                                    {


                                        PrpiedadesRelacionadas relacao = repositorioPropRelacionadas
                                            .Find(x => x.GUID_PNPTABLE == tipoItem.GUID && x.GUID_PROPIEDADE == tipoPropriedade.GUID);


                                        if (relacao == null)
                                        {
                                            relacao = new PrpiedadesRelacionadas()
                                            {
                                                GUID = Guid.NewGuid().ToString(),
                                                GUID_PNPTABLE = tipoItem.GUID,
                                                GUID_PROPIEDADE = tipoPropriedade.GUID
                                            };

                                            repositorioPropRelacionadas.Insert(relacao);

                                        }
                                    }





                                    PropertyInfo campo = type.GetProperty(info.Name);
                                    var valor = info.GetValue(item, null);

                                    if (valor != null)
                                    {


                                        Valores valorTabelado = null;
                                        using (var repositorioValores = new Repositorio<Valores>(_conexao))
                                        {

                                            valorTabelado = repositorioValores.Find(x => x.VALOR == valor.ToString());

                                            if (valorTabelado == null)
                                            {
                                                valorTabelado = new Valores()
                                                {
                                                    GUID = Guid.NewGuid().ToString(),
                                                    VALOR = valor.ToString(),
                                                    Sigla_BRASS = ""
                                                };

                                                repositorioValores.Insert(valorTabelado);
                                            }
                                        }

                                        if (tipoPropriedade.NOME == "PartCategory")
                                        {
                                            var itemCategoria = repositorioItemEngenharia.Find(x => x.GUID == valorTabelado.GUID && x.GUID_CATALOGO == _catalogo.GUID);

                                            if (itemCategoria == null)
                                            {
                                                itemCategoria = new ItemEngenharia()
                                                {
                                                    GUID = valorTabelado.GUID,
                                                    GUID_TIPO_ITEM = tipoPropriedade.GUID,
                                                    GUID_CATALOGO = _catalogo.GUID,
                                                    PnPID = 0,
                                                    GUID_ITEM_PAI = _catalogo.GUID
                                                };

                                                repositorioItemEngenharia.Insert(itemCategoria);
                                            }

                                            itemEngenharia.GUID_ITEM_PAI = itemCategoria.GUID;


                                            repositorioItemEngenharia.Edit(itemEngenharia);

                                        }






                                        PropriedadeEng propriedadeEng = null;
                                        using (var repositorioPropriedades = new Repositorio<PropriedadeEng>(_conexao))
                                        {

                                            propriedadeEng = repositorioPropriedades.
                                                Find(x => x.GUID_TIPO == tipoPropriedade.GUID && x.GUID_VALOR == valorTabelado.GUID);


                                            if (propriedadeEng == null)
                                            {

                                                propriedadeEng = new PropriedadeEng()
                                                {
                                                    GUID = Guid.NewGuid().ToString(),
                                                    GUID_TIPO = tipoPropriedade.GUID,
                                                    GUID_VALOR = valorTabelado.GUID
                                                };

                                                repositorioPropriedades.Insert(propriedadeEng);


                                            }
                                        }


                                        using (var repositorioPropriedadeItemEng = new Repositorio<PropriedadeItemEng>(_conexao))
                                        {
                                            propriedadeItemEng = new PropriedadeItemEng()
                                            {
                                                GUID = Guid.NewGuid().ToString(),
                                                GUID_ITEM_ENG = itemEngenharia.GUID,
                                                GUID_PROPRIEDADE = propriedadeEng.GUID
                                            };


                                            repositorioPropriedadeItemEng.Insert(propriedadeItemEng);







                                        }

                                    }
                                }
                            }

                        }

                    }
                }

            }


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
