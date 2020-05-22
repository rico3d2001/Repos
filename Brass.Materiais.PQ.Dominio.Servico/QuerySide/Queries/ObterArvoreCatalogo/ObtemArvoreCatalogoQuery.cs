using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObtemArvoreCatalogo
{

    public class ObtemArvoreCatalogoQuery : IComando
    {

        public void Validate()
        {
            throw new System.NotImplementedException();
        }


     
    
        public List<RamalArvoreCatalogo> ExtraiArvoreCatalogoEstoque(BaseMDBRepositorio<Catalogo> catalogoRepositorio, BaseMDBRepositorio<Familia> familiasRepositorio)
        {
          

            var catalogos = catalogoRepositorio.Obter(); 


            var ramais = new List<RamalArvoreCatalogo>();

            foreach (var catalogo in catalogos)
            {
                ramais.Add(new RamalArvoreCatalogo(catalogo.NOME, catalogo.GUID, string.Empty,1));
            }

            ramais = ramais.OrderBy(x => x.name).ToList();

            foreach (var ramalCatalogo in ramais)
            {
                adicionaRamalCategoria(ramalCatalogo.guid, ramais, familiasRepositorio);
            }

            var ramalEstoqueRepositorio = new BaseMDBRepositorio<RamalArvoreCatalogo>("Catalogo", "RamalEstoque");

            ramalEstoqueRepositorio.Inserir(ramais);

            return ramais;
        }

        private void adicionaRamalCategoria(string guidcatalogo, List<RamalArvoreCatalogo> ramaisCatalogos, BaseMDBRepositorio<Familia> familiasRepositorio)
        {
       
            var categoriaRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");

            var filtroCategorias = Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, guidcatalogo);

            var tipoRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");

            var listaCategoriasCatalogo = categoriaRepositorio.Encontrar(filtroCategorias);//_itemEngenhariaService.ObterCategorias(guidcatalogo);//new ArquivoEstoqueService().ObterPorConfiguracao(guidcatalogo);

            var cat = ramaisCatalogos.First(x => x.guid == guidcatalogo);

            if (cat != null)
            {
                foreach (var categoria in listaCategoriasCatalogo)
                {
                    var filtroTipo = Builders<TipoItemEng>.Filter.Eq(x => x.GUID, categoria.GUID_TIPO);
                    var tipo = tipoRepositorio.Encontrar(filtroTipo).First();
                    var categ = new RamalArvoreCatalogo(tipo.NOME, categoria.GUID, guidcatalogo,2);
                    adicionaRamalFamilia(guidcatalogo, categ, familiasRepositorio);
                    cat.Adiciona(categ);

                }
            }
           
        }

        private void adicionaRamalFamilia(string guidCatalogo, RamalArvoreCatalogo categoria, BaseMDBRepositorio<Familia> familiasRepositorio)
        {
            
            var listaFamilias = familiasRepositorio.Encontrar(Builders<Familia>.Filter.Eq(x => x.GUID_CATEGORIA, categoria.guid));


            foreach (var familia in listaFamilias)
            {
                var ramalFamilia = new RamalArvoreCatalogo(familia.PartFamilyLongDesc.VALOR, familia.GUID, categoria.guid,3);
              
                categoria.Adiciona(ramalFamilia);
            }
        }

        private void adicionaDiametros (string guidCategoria, RamalArvoreCatalogo ramalFamilia)
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

                    
                    var filtroPropriedadeItemTESTE = Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, nomeTipoPropriedade_GUID);
                    var propriedadeTESTE = propriedadeItemRepositorio.Encontrar(filtroPropriedadeItemTESTE);

                    foreach (var p in propriedadeTESTE)
                    {


                
                            var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
                            var filtroValorTabelado = Builders<ValorTabelado>.Filter
                                                  .Eq(x => x.GUID, p.GUID_VALOR);
                            var valor = valorTabeladoRepositorio.Encontrar(filtroValorTabelado).First();

                            var ramalValor = new RamalArvoreCatalogo(valor.VALOR, p.GUID, relacaoFamilia.GUID_ITEM,5);
                     
                    }
                }



            }
        }

        
    }
}
