using Brass.Materiais.AppCatalogoPlant3d.Service;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
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

        public OrganizaCatalogoTubulacaoSQLiteMongoDB(string endereco, string guidDisciplina, string conexao)//string endereco, string idioma, string pais, string conexao)
        {
            _conexao = conexao;
            _endereco = endereco;
  
            string nomeCatalogo = _endereco.Split('\\').Last().Split('.').First();

            DefineCatalogo(nomeCatalogo, guidDisciplina);

            ConexaoSQLite.BuildConnectionString(endereco);

        }

        private void DefineCatalogo(string nomeCatalogo, string guidDisciplina)
        {

            var catalogosMDBRepositorio = new RepoCatalogo(_conexao);

     
            var catalogo =  catalogosMDBRepositorio.ObterPorNome(nomeCatalogo);
     


            if (catalogo == null)
            {
                var idiomaMDBRepositorio = new RepoIdioma(_conexao);

                var idioma = idiomaMDBRepositorio.ObterIdiomaPorLinguaPais(_idioma, _pais);


                if (idioma == null)
                {

                    idioma = new Idioma(_idioma,_pais);

                    idiomaMDBRepositorio.Cadastrar(idioma);
                }
       
                _catalogo = new CatalogoEntidade(nomeCatalogo, idioma.GUID, guidDisciplina);

                catalogosMDBRepositorio.CadastrarCatalogo(_catalogo);
            }
          

     
        }

        //public void PegaTipos()
        //{
        //    var itemPipeEstoqueRepositorio = new RepoItemPipe(_conexao);

            
        //    var itensPipeCategoria = itemPipeEstoqueRepositorio.ObterTodosDoCatalogo(_catalogo.GUID);
        //}

        public void Injetar()
        {
      
            var familiasRepositorio = new RepoFamilia(_conexao);

            var itensEngenhariaP3D = CapturarItensEngenhariaPlant3d();


            var itemPipeEstoqueRepositorio = new RepoItemPipe(_conexao);

            int conta = itemPipeEstoqueRepositorio.ObterTodos().Count();

            if (conta < itensEngenhariaP3D.Count())
            {


                foreach (var item in itensEngenhariaP3D)
                {

                    var partFamilyLongDesc = item.PartFamilyLongDesc;

                    var familia = familiasRepositorio.ObterFamiliaPorDescricao(partFamilyLongDesc);

      
                    if (familia == null)
                    {


                  
                        var itemPipeEstoque = itemPipeEstoqueRepositorio.ObterPorPnPIDComCatalogo((int)item.PnPID, _catalogo.GUID);



                        if (itemPipeEstoque ==  null)
                        {

                            string tipoItemEng = item.ShortDescription.Split(',')[0];



                            var tipoItemPipeStockRepositorio = new RepoTipoDeItem(_conexao);


                            var tipoItem = tipoItemPipeStockRepositorio.ObterPorNome(tipoItemEng);



                            if (tipoItem == null)
                            {
                                tipoItem = new TipoItemEng(tipoItemEng);

                                tipoItemPipeStockRepositorio.CadastrarTipo(tipoItem);

                            }
                           


                            var itemPipe = new ItemPipe(familia.GUID,tipoItem.GUID,_catalogo.GUID,(int)item.PnPID);

                            itemPipeEstoqueRepositorio.CadastrarItemPipe(itemPipe);

                            Type type = item.GetType();

                            foreach (var info in type.GetProperties())
                            {

                                if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                                {

 
                                    var nomeTipoPropriedadeRepositorio =  new RepoNomeTipoPropriedade(_conexao);

                                    var nomeTipoPropriedade = nomeTipoPropriedadeRepositorio.ObterPorNome(info.Name);



                                    if (nomeTipoPropriedade == null)
                                    {
                                        nomeTipoPropriedade = new NomeTipoPropriedade(info.Name);

                                        nomeTipoPropriedadeRepositorio.CadastrarNomeTipoPropriedade(nomeTipoPropriedade);

                                    }
                                 


                                    RepoRelacaoEntrePropriedades repoRelacaoEntrePropriedades = new RepoRelacaoEntrePropriedades(_conexao);

                                    var relacao = repoRelacaoEntrePropriedades.ObterRelacaoEntrePropriedades(tipoItem.GUID, nomeTipoPropriedade.GUID);

                                    if (relacao == null)
                                    {
                                        relacao = new RelacaoEntrePropriedades()
                                        {
                                            GUID_PNPTABLE = tipoItem.GUID,
                                            GUID_PROPIEDADE = nomeTipoPropriedade.GUID
                                        };

                                        repoRelacaoEntrePropriedades.Cadastrar(relacao);

                                    }

                                    PropertyInfo campo = type.GetProperty(info.Name);
                                    var valor = info.GetValue(item, null);

                                    if (valor != null)
                                    {


                                        var valorTabeladoRepositorio = RepoValores.Instancia(_conexao);

                                        var valorTabelado = valorTabeladoRepositorio.ObterDescricao(valor.ToString());


                                    

                                        if (valorTabelado == null)
                                        {
                                            valorTabelado = new ValorTabelado(valor.ToString(),"");

                                            valorTabeladoRepositorio.CadastrarValor(valorTabelado);
                                        }
                                       
                           
                                        var propriedadeRepositorio = new RepoPropriedadeItem(_conexao);


                                        var propriedadeEng = propriedadeRepositorio.ObterPorTipoMaisValor(nomeTipoPropriedade.GUID, valorTabelado.GUID);

                                        if (propriedadeEng == null)
                                        {

                                            propriedadeEng = new PropriedadeItem(nomeTipoPropriedade.GUID, valorTabelado.GUID);


                                            propriedadeRepositorio.Cadastrar(propriedadeEng);


                                        }
                                      

                                        var relacaoPropriedadeItemRepositorio = new RepoRelacaoPropriedadeItem(_conexao);


                                        var relacaoPropriedadeItem = new RelacaoPropriedadeItem(propriedadeEng.GUID, itemPipe.GUID);



                                        relacaoPropriedadeItemRepositorio.Cadastrar(relacaoPropriedadeItem);


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
