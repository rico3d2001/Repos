using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.ValueObjects.Dimensoes;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.PQ.Dominio.Servico.Commands.Requests
{
    public class CriaNomesPropriedades
    {
        public List<NomeTipoPropriedade> ExtraiNomes()
        {
            var propriedadesRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");

            return propriedadesRepositorio.Obter(); //_itemEngenhariaService.ObterCatalogos();
        }

        public List<Familia> ObtemFamilias(string guidCategoria)
        {
            var familiaItemRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");


            return familiaItemRepositorio
                        .Encontrar(Builders<Familia>
                        .Filter.Eq(x => x.GUID_CATEGORIA, guidCategoria));
        }

        /*
        public List<DimensaoFamilia> ObtemItensFamilia(string guidFamilia)
        {
            var familiaItemRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");


            //var familia = familiaItemRepositorio
                //.Encontrar(Builders<Familia>
                //.Filter.Eq(x => x.GUID, guidFamilia));

            List<DimensaoFamilia> listaItens = new List<DimensaoFamilia>();



            var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
            var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
            var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");

            var familia = familiaItemRepositorio
                .Encontrar(Builders<Familia>
                .Filter.Eq(x => x.GUID, guidFamilia))
                .First();


            var guidNomePropriedade = nomeTipoPropriedadeRepositorio
                .Encontrar(Builders<NomeTipoPropriedade>
                .Filter.Eq(x => x.NOME, "PartSizeLongDesc")).First().GUID;


            var descricoesDisponiveis = propriedadeItemRepositorio
                .Encontrar(Builders<PropriedadeItem>
                .Filter.Eq(x => x.GUID_TIPO, guidNomePropriedade));


            var todasRelacoesPropriedadeItem = relacaoPropriedadeItemRepositorio.Obter();


            var todosOsValoresTabelados = valorTabeladoRepositorio.Obter();

            var descricoes = (from guidFam in familia.IdsItens
                              join relPI in todasRelacoesPropriedadeItem on guidFam equals relPI.GUID_ITEM_ENG
                              join diam in descricoesDisponiveis on relPI.GUID_PROPRIEDADE equals diam.GUID
                              join val in todosOsValoresTabelados on diam.GUID_VALOR equals val.GUID
                              select new { Valor = val.VALOR }).ToList();


            if (descricoes.Count() > 0)
            {
                foreach (var decricao in descricoes)
                {
                    listaItens.Add(new DimensaoFamilia(decricao.Valor));
                }

            }

            return listaItens;
        }

        */
        
        
        private List<Familia> distinguir(List<Familia> familias)
        {
            List<Familia> resposta = new List<Familia>();

            foreach (var entrada in familias)
            {
                if(resposta.FirstOrDefault(x => x.PartFamilyLongDesc.VALOR == entrada.PartFamilyLongDesc.VALOR) == null)
                {
                    resposta.Add(entrada);
                }
            }

            return resposta;
        }
        
        public List<PropriedadeCadastro> ObtemPropriedades(string guidItem)
        {
            List<PropriedadeCadastro> listaResult = new List<PropriedadeCadastro>();



            return listaResult;
        }

        public void CriaFamilias(string guidCatalogo)
        {

            var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            var builderNomeTipoPropriedade = Builders<NomeTipoPropriedade>.Filter;
            var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            var relacaoFamiliaItemRepositorio = new BaseMDBRepositorio<RelacaoFamiliaItem>("Catalogo", "RelacaoFamiliaItem");
            var itemPipeRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
            var categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");
            var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
            var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
            var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");

            var propriedadePartFamilyLongDesc = nomeTipoPropriedadeRepositorio
                .Encontrar(builderNomeTipoPropriedade.Eq(x => x.NOME, "PartFamilyLongDesc")).First();



            var categorias = categoriasRepositorio
                .Encontrar(Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));



            var todasRelacoesPropriedadeItemRepositorio = relacaoPropriedadeItemRepositorio.Obter();

            var itensPorCatalogo = itemPipeRepositorio
                   .Encontrar(
                   Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));

            var todasPropriedades = propriedadeItemRepositorio.Obter();
            //.Encontrar(Builders<PropriedadeItem>.Filter.Eq(x => x.GUID, propriedadePartFamilyLongDesc.GUID ));

            var todosValores = valorTabeladoRepositorio.Obter();


            var fams =
                    (from propriedade in todasPropriedades
                     join rel in todasRelacoesPropriedadeItemRepositorio on propriedade.GUID equals rel.GUID_PROPRIEDADE
                     join val in todosValores on propriedade.GUID_VALOR equals val.GUID
                     join item in itensPorCatalogo on rel.GUID_ITEM_ENG equals item.GUID
                     join categ in categorias on item.GUID_TIPO_ITEM equals categ.GUID_TIPO
                     where propriedade.GUID_TIPO == propriedadePartFamilyLongDesc.GUID
                     select new Familia(guidCatalogo, categ.GUID, val)).ToList();



            var resumo = distinguir(fams);

            
           

            foreach (var fam in resumo)
            {


                //var itens = (from it in itensPorCatalogo
                //            join rels in todasRelacoesPropriedadeItemRepositorio on it.GUID equals rels.GUID_ITEM_ENG
                //            join prop in todasPropriedades on rels.GUID_PROPRIEDADE equals prop.GUID_VALOR
                //            select new { guid = it.GUID }).ToList();

                //foreach (var item in itens)
                //{

                //    fam.AdicionaIdentiicadorItem(item.guid);
                //}




                var etapa1 = todasPropriedades.Where(x => x.GUID_VALOR == fam.PartFamilyLongDesc.GUID).ToList();

                var etapa2 = todasRelacoesPropriedadeItemRepositorio.Where(x => x.GUID_PROPRIEDADE == etapa1.First().GUID).ToList();

                foreach (var item in etapa2)
                {

                    var etapa3 = itensPorCatalogo.Where(x => x.GUID == item.GUID_ITEM_ENG).ToList();
                    if (etapa3.Count == 1)
                    {
                        fam.AdicionaIdentificadorItem(etapa3.First().GUID);
                    }

                }



                //var descricoes = from itemFam in itensRelacionadosFamilia
                //join relPI in todasRelacoesPropriedadeItem on itemFam.GUID_ITEM equals relPI.GUID_ITEM_ENG
                //join diam in descricoesDisponiveis on relPI.GUID_PROPRIEDADE equals diam.GUID
                //join val in todosOsValoresTabelados on diam.GUID_VALOR equals val.GUID
                //select new { Valor = val.VALOR };


                familiasRepositorio.Inserir(fam);

            }


        }


        //private static List<RelacaoPropriedadeItem> obterRelacoesPropItens(RelacaoFamiliaItem itemRelacionado)
        //{
        //    var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
        //    var filtroRelacaoPropriedadeItem = Builders<RelacaoPropriedadeItem>.Filter
        //                                  .Eq(x => x.GUID_ITEM_ENG, itemRelacionado.GUID_ITEM);
        //    var relacoesEntrePropiedadesItem = relacaoPropriedadeItemRepositorio.Encontrar(filtroRelacaoPropriedadeItem);
        //    return relacoesEntrePropiedadesItem;
        //}








        public List<Familia> ExtraiItensCategoria(string guidCatalogo, string guidCategoria)
        {

            /*
            string qry = "SELECT PropriedadeItemEng.GUID AS GUID_ITEM_PROPRIEDADE, TipoPropriedade.NOME AS PROPRIEDADE, Valores.VALOR AS VALOR_PROPRIEDADE,"
                                 + "ItemEngenharia.PnPID AS PnPID, ItemEngenharia.GUID AS GUID_ITEM"
                                    + " FROM ItemEngenharia INNER JOIN"
                                    + " PropriedadeItemEng ON ItemEngenharia.GUID = PropriedadeItemEng.GUID_ITEM_ENG INNER JOIN"
                                    + " PropriedadeEng ON PropriedadeItemEng.GUID_PROPRIEDADE = PropriedadeEng.GUID INNER JOIN"
                                    + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                    + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID"
                                    + " WHERE ItemEngenharia.GUID = (SELECT ItemEngenharia.GUID"
                                                        + " FROM PropriedadeEng INNER JOIN"
                                                        + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                                                        + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                                                        + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                                        + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                                                        + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                                                        + " WHERE(TipoPropriedade.NOME = N'PartCategory')"
                                                        + " AND(Valores.GUID = '" + guidCategoria + "')"
                                                        + " AND(TipoItem.GUID = '" + guidTipoItem + "')"
                                                        + " AND(ItemEngenharia.GUID = '" + prop.GUID + "'))";

            */
            //6ade7953-5936-46a5-8934-330bfd2bba64

            var lista = new List<Familia>();

            var itemPipeRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

            //var item = itemPipeRepositorio.Obter().First();


            var builder = Builders<ItemPipe>.Filter;
            var filterItemPipeEstoque = builder.Eq(x => x.GUID_CATALOGO, guidCatalogo) & builder.Eq(x => x.GUID_TIPO_ITEM, guidCategoria);
            var itens = itemPipeRepositorio.Encontrar(filterItemPipeEstoque);

            var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");

            var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");

            foreach (var item in itens)
            {

                var filtroRelacaoPropriedadeItem = Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, item.GUID);

                var relacoes = relacaoPropriedadeItemRepositorio.Encontrar(filtroRelacaoPropriedadeItem);

                var familia = new Familia(guidCatalogo, guidCategoria, new ValorTabelado());

                foreach (var relacao in relacoes)
                {

                    var filtroPropriedadeItem = Builders<PropriedadeItem>.Filter.Eq(x => x.GUID, relacao.GUID_PROPRIEDADE);

                    var propriedadeItem = propriedadeItemRepositorio.Encontrar(filtroPropriedadeItem).First();


                    var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
                    var builderNomeTipoPropriedade = Builders<NomeTipoPropriedade>.Filter;
                    var filtroNomeTipoPropriedade = builderNomeTipoPropriedade.Eq(x => x.GUID, propriedadeItem.GUID_TIPO)
                                                    & builderNomeTipoPropriedade.Eq(x => x.NOME, "PartFamilyLongDesc");
                    var propriedades = nomeTipoPropriedadeRepositorio.Encontrar(filtroNomeTipoPropriedade);

                    if (propriedades.Count() > 0)
                    {


                        var strPropriedade = propriedades.First().NOME;

                        if (strPropriedade == "PartFamilyLongDesc")
                        {
                            var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
                            var filtroValorTabelado = Builders<ValorTabelado>.Filter.Eq(x => x.GUID, propriedadeItem.GUID_VALOR);
                            var valor = valorTabeladoRepositorio.Encontrar(filtroValorTabelado).First();
                            string strValor = valor.VALOR.Replace('"', '¨');


                            familia.GetType().GetProperty(strPropriedade).SetValue(familia, strValor);

                            break;
                        }

                    }

                }

                //lista.Add(familia);

            }



            //var filtro = Builders<ItemPipe>.Filter.Eq(x => x.PnPID, 0);

            //var itensPipeCategoria = itemPipeRepositorio.Encontrar(filtro);

            return lista; //_itemEngenhariaService.ObterCatalogos();
        }



        public List<RamalArvoreCatalogo> ObtemRamalFamilias(string guidCategoria)
        {
            List<RamalArvoreCatalogo> lista = new List<RamalArvoreCatalogo>();

            //var categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");
            //var filtroCategorias = Builders<Categoria>.Filter.Eq(x => x.GUID, guidCategoria);
            //var categoria = categoriasRepositorio.Encontrar(filtroCategorias).First();

            var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            var filtroFamilias = Builders<Familia>.Filter.Eq(x => x.GUID_CATEGORIA, guidCategoria);
            var familias = familiasRepositorio.Encontrar(filtroFamilias);

            familias.ForEach(x => lista.Add(new RamalArvoreCatalogo(x.PartFamilyLongDesc.VALOR, x.GUID, x.GUID_CATEGORIA, 2)));



            return lista;
        }



        public List<RamalArvoreCatalogo> ExtraiTroncoCatalogo()
        {
            List<RamalArvoreCatalogo> lista = new List<RamalArvoreCatalogo>();

            var catalogoRepositorio = new BaseMDBRepositorio<Catalogo>("Catalogo", "Catalogo");
            var catalogos = catalogoRepositorio.Obter();
            foreach (var catalogo in catalogos)
            {

                RamalArvoreCatalogo ramal = new RamalArvoreCatalogo(catalogo.NOME, catalogo.GUID, "raiz", 0);

                var categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");
                var filtroCategorias = Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, catalogo.GUID);
                var categorias = categoriasRepositorio.Encontrar(filtroCategorias);

                var tipoItemEngRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");
                foreach (var categoria in categorias)
                {
                    var filtro = Builders<TipoItemEng>.Filter.Eq(x => x.GUID, categoria.GUID_TIPO);
                    var nomes = tipoItemEngRepositorio.Encontrar(filtro);
                    if (nomes.Count() > 0)
                    {
                        ramal.children.Add(
                            new RamalArvoreCatalogo(
                                nomes.First().NOME,
                                categoria.GUID,
                                catalogo.GUID,
                                1));
                    }

                }

                lista.Add(ramal);
            }

            return lista;
        }




    }
}
