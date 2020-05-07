using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Dominio.Servico.Commands.Requests
{
    public class CriaArvoreCatalogo
    {
        //BaseMDBRepositorio<RamalEstoque> _ramalEstoqueService;
        public CriaArvoreCatalogo()
        {
           
            //_ramalEstoqueService = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
        }

        public void CarregaRamaisEstoque()
        {


            List<RamalEstoque> ramals = ExtraiArvoreEstoque();

            //_ramalEstoqueService.Carregar(ramals);

        }

        public List<RamalEstoque> ExtraiArvoreEstoque()
        {
            //_itemEngenhariaService = new ItemEngenhariaService();

            var catalogoRepositorio = new BaseMDBRepositorio<Catalogo>("Catalogo", "Catalogo");

            var catalogos = catalogoRepositorio.Obter(); //_itemEngenhariaService.ObterCatalogos();


            var ramais = new List<RamalEstoque>();

            foreach (var catalogo in catalogos)
            {
                ramais.Add(new RamalEstoque(catalogo.NOME, catalogo.GUID, string.Empty));
            }

            ramais = ramais.OrderBy(x => x.name).ToList();

            foreach (var ramalCatalogo in ramais)
            {
                adicionaRamalCategoria(ramalCatalogo.guid, ramais);
            }

            var ramalEstoqueRepositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");

            ramalEstoqueRepositorio.Inserir(ramais);

            return ramais;
        }

        private void adicionaRamalCategoria(string guidcatalogo, List<RamalEstoque> ramaisCatalogos)
        {
            /*
           string qry = "SELECT Categoria.GUID, Categoria.NOME"
                         + " FROM Categorias_Catalogo INNER JOIN"
                         + " Categoria ON Categorias_Catalogo.GUID_CATEGORIA = Categoria.GUID"
                         + " WHERE(Categorias_Catalogo.GUID_CATALOGO = '" + guidCatalogo + "')";
            
              */
            var categoriaRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");

            var filtroCategorias = Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, guidcatalogo);

            //var itensPipeCategoria = itemPipeEstoqueRepositorio.Encontrar(filtro);
            var tipoRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");

            var listaCategoriasCatalogo = categoriaRepositorio.Encontrar(filtroCategorias);//_itemEngenhariaService.ObterCategorias(guidcatalogo);//new ArquivoEstoqueService().ObterPorConfiguracao(guidcatalogo);

            var cat = ramaisCatalogos.First(x => x.guid == guidcatalogo);

            if (cat != null)
            {
                foreach (var categoria in listaCategoriasCatalogo)
                {
                    var filtroTipo = Builders<TipoItemEng>.Filter.Eq(x => x.GUID, categoria.GUID_TIPO);
                    var tipo = tipoRepositorio.Encontrar(filtroTipo).First();
                    var categ = new RamalEstoque(tipo.NOME, categoria.GUID, guidcatalogo);
                    adicionaRamalFamilia(guidcatalogo, categ);
                    cat.Adiciona(categ);

                }
            }
           
        }

        private void adicionaRamalFamilia(string guidCatalogo, RamalEstoque categoria )
        {
            //var listaPlanilhas = new TemplateEstoqueService().ObterPorArquivo(arquivo.id);
            //var listaTipos = _itemEngenhariaService.ObterTiposItem(guidCatalogo, categoria.guid);

            var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            var builderFamilias = Builders<Familia>.Filter;
            var filtroFamilia = builderFamilias.Eq(x => x.GUID_CATALOGO, guidCatalogo)
                                            & builderFamilias.Eq(x => x.GUID_CATEGORIA, categoria.guid);
            var listaFamilias = familiasRepositorio.Encontrar(filtroFamilia);


            foreach (var familia in listaFamilias)
            {
                var ramalFamilia = new RamalEstoque(familia.PartFamilyLongDesc, familia.GUID, categoria.guid);
                adicionaDiametros(categoria.guid, ramalFamilia);
                categoria.Adiciona(ramalFamilia);
            }
        }

        private void adicionaDiametros (string guidCategoria, RamalEstoque ramalFamilia)
        {
            var relacaoFamiliaItemRepositorio = new BaseMDBRepositorio<RelacaoFamiliaItem>("Catalogo", "RelacaoFamiliaItem");
            var builderRelacaoFamiliaItem = Builders<RelacaoFamiliaItem>.Filter;
            var filtroRelacaoFamiliaItem = builderRelacaoFamiliaItem.Eq(x => x.GUID_CATEGORIA, guidCategoria)
                                            & builderRelacaoFamiliaItem.Eq(x => x.GUID_FAMILIA, ramalFamilia.guid);

            var relacoesFamilia = relacaoFamiliaItemRepositorio.Encontrar(filtroRelacaoFamiliaItem);

            foreach (var relacaoFamilia in relacoesFamilia)
            {
                var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
                var filtroRelacaoPropriedadeItem = Builders<RelacaoPropriedadeItem>.Filter
                                              .Eq(x => x.GUID_ITEM_ENG, relacaoFamilia.GUID_ITEM);
                var relacoesPropriedadesItem = relacaoPropriedadeItemRepositorio.Encontrar(filtroRelacaoPropriedadeItem);

                //Todos os diametros nominais disponiveis
                var nomeTipoPropriedade_GUID = "5ef2516d-8c5f-4b55-a049-442f0e5cc4f4";
                var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
                var filtroPropriedadeItem = Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, nomeTipoPropriedade_GUID);
                var diametrosNominaisDisponiveis = propriedadeItemRepositorio.Encontrar(filtroPropriedadeItem);

                foreach (var relacaoPropriedadeItem in relacoesPropriedadesItem)
                {

                    var GUID_PROPRIEDADE = relacaoPropriedadeItem.GUID_PROPRIEDADE;

                    var diametro = diametrosNominaisDisponiveis.FirstOrDefault(x => x.GUID == GUID_PROPRIEDADE);

                    //teste
                    var filtroPropriedadeItemTESTE = Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, nomeTipoPropriedade_GUID);
                    var propriedadeTESTE = propriedadeItemRepositorio.Encontrar(filtroPropriedadeItemTESTE);

                    foreach (var p in propriedadeTESTE)
                    {


                        //if (propriedadeTESTE.Count() > 0)
                        //{
                        //var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
                        //var filtroNomeTipoPropriedade = Builders<NomeTipoPropriedade>.Filter.Eq(x => x.GUID, nomeTipoPropriedade_GUID);
                        //var propTeste = nomeTipoPropriedadeRepositorio.Encontrar(filtroNomeTipoPropriedade).First();

                        //if (propTeste.NOME == "NominalDiameter")
                        //{


                        //teste



                        //if (diametro != null)
                        //{
                            var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
                            var filtroValorTabelado = Builders<ValorTabelado>.Filter
                                                  .Eq(x => x.GUID, p.GUID_VALOR);
                            var valor = valorTabeladoRepositorio.Encontrar(filtroValorTabelado).First();

                            var ramalValor = new RamalEstoque(valor.VALOR, p.GUID, relacaoFamilia.GUID_ITEM);
                        //}
                        // }
                        //}
                    }
                }



            }
        }
    }
}
