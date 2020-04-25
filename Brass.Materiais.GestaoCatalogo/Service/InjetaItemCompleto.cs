using AutoMapper;
using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.Dominio.ValueObjects.Plant3D;
using Brass.Materiais.InjecaoDependencia;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using Brass.Materiais.RepositorioSQLServer;
using Brass.Materiais.RepositorioSQLServer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Unity;

namespace Brass.Materiais.GestaoCatalogo.Service
{
    public class InjetaItemCompleto
    {
        private string _endereco;
        private string _idioma;
        private string _pais;
        private string _conexao;
        private CatalogoPlant3d _catalogo;


        private IMapper _mapper;


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

        public ItemEngenharia PegaItemEngenhariaBanco(string nomeCatalogo, long PnPID)
        {
            ItemEngenharia itemEngenharia = null;



            using (var repositorioItemEngenharia = new Repositorio<ItemEngenharia>(_conexao))
            {
                itemEngenharia = repositorioItemEngenharia.Find(x => x.GUID_CATALOGO == _catalogo.GUID && x.PnPID == PnPID);
            }

            return itemEngenharia;
        }

        public void InjetarUnitario(EngineeringItems itemPlant)
        {
            using (var repositorioItemEngenharia = new Repositorio<ItemEngenharia>(_conexao))
            {

                //var itensCategoria = repositorioItemEngenharia.Query(x => x.GUID_ITEM_PAI == catalogo.GUID).ToList();



                ItemEngenharia itemEngenharia = null;



                itemEngenharia = repositorioItemEngenharia.Find(x => x.PnPID == (int)itemPlant.PnPID && x.GUID_CATALOGO == _catalogo.GUID);

                if (itemEngenharia == null)
                {

                    TipoItem tipoItem = null;
                    string tipoItemEng = itemPlant.ShortDescription.Split(',')[0];

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
                        PnPID = (int)itemPlant.PnPID
                    };

                    repositorioItemEngenharia.Insert(itemEngenharia);

                    Type type = itemPlant.GetType();

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
                            var valor = info.GetValue(itemPlant, null);

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


                                    using (var repositorioCategoriasCatalogo = new Repositorio<Categorias_Catalogo>(_conexao))
                                    {
                                        var categoriaCatalogo = repositorioCategoriasCatalogo.Find(x => x.GUID_CATEGORIA == valorTabelado.GUID && x.GUID_CATALOGO == _catalogo.GUID);

                                        if (categoriaCatalogo == null)
                                        {
                                            categoriaCatalogo = new Categorias_Catalogo()
                                            {
                                                GUID = Guid.NewGuid().ToString(),
                                                GUID_CATALOGO = _catalogo.GUID,
                                                GUID_CATEGORIA = valorTabelado.GUID
                                            };

                                            repositorioCategoriasCatalogo.Insert(categoriaCatalogo);
                                        }

                                    }



                                    //var itemCategoria = repositorioItemEngenharia.Find(x => x.GUID == valorTabelado.GUID);// && x.GUID_CATALOGO == _catalogo.GUID);




                                    //if (itemCategoria == null)
                                    //{
                                    //    itemCategoria = new ItemEngenharia()
                                    //    {
                                    //        GUID = valorTabelado.GUID,
                                    //        GUID_TIPO_ITEM = tipoPropriedade.GUID,
                                    //        GUID_CATALOGO = _catalogo.GUID,
                                    //        PnPID = 0,
                                    //        GUID_ITEM_PAI = _catalogo.GUID
                                    //    };

                                    //    repositorioItemEngenharia.Insert(itemCategoria);
                                    //}

                                    //itemEngenharia.GUID_ITEM_PAI = itemCategoria.GUID;


                                    //repositorioItemEngenharia.Edit(itemEngenharia);

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

        private List<TabelaP3D> CapturarListaTabelasPlant3d()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PnPTables, TabelaP3D>());



            _mapper = config.CreateMapper();

            List<PnPTables> tabelas;
            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<PnPTables>>())
            {
                dominioService.Start(Storage.ConnectionString);

                tabelas = (List<PnPTables>)dominioService.GetAll();
            }

            return _mapper.Map<List<TabelaP3D>>(tabelas);
        }

        //private void sincronizarGuidItem(EngineeringItems entidade)
        //{

        //    using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
        //    {
        //        dominioService.Start(Storage.ConnectionString);

        //        dominioService.Update(entidade);
        //    }
        //}

        private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        {


            List<EngineeringItems> listaResult;

            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>(_conexao))
            {
                dominioService.Start(Storage.ConnectionString);

                listaResult = (List<EngineeringItems>)dominioService.GetAll();


            }

            return listaResult;

        }
    }
}
