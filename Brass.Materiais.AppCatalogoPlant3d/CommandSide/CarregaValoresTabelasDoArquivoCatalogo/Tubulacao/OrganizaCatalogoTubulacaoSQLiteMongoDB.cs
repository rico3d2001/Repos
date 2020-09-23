using Brass.Materiais.AppCatalogoPlant3d.Service;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using MongoDB.Driver;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaValoresTabelasDoArquivoCatalogo.Tubulacao
{
    public class OrganizaCatalogoTubulacaoSQLiteMongoDB
    {

        private string _endereco;
        private string _idioma;
        private string _pais;
        private string _conexao;
        private CatalogoEntidade _catalogo;

        public OrganizaCatalogoTubulacaoSQLiteMongoDB(string endereco, string guidDisciplina)//string endereco, string idioma, string pais, string conexao)
        {

            _endereco = endereco;
  
            string nomeCatalogo = _endereco.Split('\\').Last().Split('.').First();

            DefineCatalogo(nomeCatalogo, guidDisciplina);

            ConexaoSQLite.BuildConnectionString(endereco);

        }

        private void DefineCatalogo(string nomeCatalogo, string guidDisciplina)
        {

            var catalogosMDBRepositorio = new BaseMDBRepositorio<CatalogoEntidade>("Catalogo", "Catalogo");

     
            var catalogos = catalogosMDBRepositorio
                .Encontrar(Builders<CatalogoEntidade>.Filter.Eq(x => x.NOME, nomeCatalogo));
     


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
                    var idioma = new Idioma(_idioma,_pais);

                    idiomaMDBRepositorio.Inserir(idioma);
                }
                else
                {
                    guidIdioma = idiomas.First().GUID;
                }


                _catalogo = new CatalogoEntidade(nomeCatalogo,guidIdioma, guidDisciplina);

                catalogosMDBRepositorio.Inserir(_catalogo);
            }
            else
            {
                _catalogo = catalogos.First();
            }

     
        }

        public void PegaTipos()
        {
            var itemPipeEstoqueRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

            var filtro = Builders<ItemPipe>.Filter.Eq(x => x.GUID_ITEM_PAI, _catalogo.GUID);

            var itensPipeCategoria = itemPipeEstoqueRepositorio.Encontrar(filtro);
        }

        public void Injetar()
        {
            var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");

            var itensEngenhariaP3D = CapturarItensEngenhariaPlant3d();


            var itemPipeEstoqueRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

            int conta = itemPipeEstoqueRepositorio.Obter().Count();

            if (conta < itensEngenhariaP3D.Count())
            {


                foreach (var item in itensEngenhariaP3D)
                {

                    var partFamilyLongDesc = item.PartFamilyLongDesc;

                    var familias = familiasRepositorio.Encontrar(Builders<Familia>.Filter.Eq(x => x.PartFamilyLongDesc.VALOR, partFamilyLongDesc)).ToList();

                    string guidFamilia = "";
                    if (familias.Count == 1)
                    {
                        guidFamilia = familias.First().GUID;


                        var itensPipeEstoque = itemPipeEstoqueRepositorio.Encontrar(
                            Builders<ItemPipe>.Filter.Eq(x => x.PnPID, (int)item.PnPID)
                            & Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, _catalogo.GUID)).ToList();



                        if (itensPipeEstoque.Count == 0)
                        {

                            TipoItemEng tipoItem = null;
                            string tipoItemEng = item.ShortDescription.Split(',')[0];



                            var tipoItemPipeStockRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");


                            var tipos = tipoItemPipeStockRepositorio.Encontrar(Builders<TipoItemEng>.Filter.Eq(x => x.NOME, tipoItemEng));



                            if (tipos.Count == 0)
                            {
                                tipoItem = new TipoItemEng(tipoItemEng);

                                tipoItemPipeStockRepositorio.Inserir(tipoItem);

                            }
                            else
                            {
                                tipoItem = tipos.First();
                            }


                            var itemPipe = new ItemPipe(guidFamilia,tipoItem.GUID,_catalogo.GUID,(int)item.PnPID);

                            itemPipeEstoqueRepositorio.Inserir(itemPipe);

                            Type type = item.GetType();

                            foreach (var info in type.GetProperties())
                            {

                                if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                                {

                                    NomeTipoPropriedade nomeTipoPropriedade = null;


                                    var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");

                                    var nomesTiposPropriedade = nomeTipoPropriedadeRepositorio.Encontrar(
                                                  Builders<NomeTipoPropriedade>.Filter.Eq(x => x.NOME, info.Name));



                                    if (nomesTiposPropriedade.Count == 0)
                                    {
                                        nomeTipoPropriedade = new NomeTipoPropriedade(info.Name);

                                        nomeTipoPropriedadeRepositorio.Inserir(nomeTipoPropriedade);

                                    }
                                    else
                                    {
                                        nomeTipoPropriedade = nomesTiposPropriedade.First();
                                    }

                                    var relacaoEntrePropriedadesRepositorio = new BaseMDBRepositorio<RelacaoEntrePropriedades>("Catalogo", "RelacaoEntrePropriedades");

                                    var filtroRelacaoEntrePropriedades =
                                        Builders<RelacaoEntrePropriedades>.Filter.Eq(x => x.GUID_PNPTABLE, tipoItem.GUID)
                                        & Builders<RelacaoEntrePropriedades>.Filter.Eq(x => x.GUID_PROPIEDADE, nomeTipoPropriedade.GUID);

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

                                        var valoresTabelados = valorTabeladoRepositorio.Encontrar(
                                              Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, valor.ToString()));


                                        ValorTabelado valorTabelado = null;

                                        if (valoresTabelados.Count == 0)
                                        {
                                            valorTabelado = new ValorTabelado(valor.ToString(),"");

                                            valorTabeladoRepositorio.Inserir(valorTabelado);
                                        }
                                        else
                                        {
                                            valorTabelado = valoresTabelados.First();
                                        }

                                        


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

            }

        }


        public List<EngineeringItems> CapturarItensEngenhariaPlant3d()
        {


            List<EngineeringItems> listaResult;

            var repoSQLiteService = new RepositorioService<EngineeringItems>();
            var dominioService = new DominioService<EngineeringItems>(repoSQLiteService);


            dominioService.Start(Storage.ConnectionString);

            listaResult = (List<EngineeringItems>)dominioService.GetAll();

            dominioService.Dispose();
    
            return listaResult;

        }
    }
}
