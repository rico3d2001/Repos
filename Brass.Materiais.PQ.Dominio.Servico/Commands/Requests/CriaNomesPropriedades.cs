using Brass.Materiais.Dominio.Entities;
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
    public class CriaNomesPropriedades
    {
        public List<NomeTipoPropriedade> ExtraiNomes()
        {
            var propriedadesRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");

            return propriedadesRepositorio.Obter(); //_itemEngenhariaService.ObterCatalogos();
        }

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

                var familia = new Familia(guidCatalogo, guidCategoria);

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

        public void ExtraiTroncoCatalogo(string v)
        {
            throw new NotImplementedException();
        }

        public void CriaFamilias(string guidCatalogo)
        {
            var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            var relacaoFamiliaItemRepositorio = new BaseMDBRepositorio<RelacaoFamiliaItem>("Catalogo", "RelacaoFamiliaItem");

            var itemPipeRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
            

            var categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");
            var filtroCategorias = Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo);
            var categorias = categoriasRepositorio.Encontrar(filtroCategorias);

            foreach (var categoria in categorias)
            {
                var builderItemPipe = Builders<ItemPipe>.Filter;
                var filterItemPipeEstoque = builderItemPipe.Eq(x => x.GUID_CATALOGO, guidCatalogo) & builderItemPipe.Eq(x => x.GUID_TIPO_ITEM, categoria.GUID_TIPO);
                var itens = itemPipeRepositorio.Encontrar(filterItemPipeEstoque);

                var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");

                var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");

                foreach (var item in itens)
                {

                    var filtroRelacaoPropriedadeItem = Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, item.GUID);

                    var relacoes = relacaoPropriedadeItemRepositorio.Encontrar(filtroRelacaoPropriedadeItem);

                    var builderFamilias = Builders<Familia>.Filter;
                    var filterFamilias = builderFamilias.Eq(x => x.GUID_CATALOGO, guidCatalogo) 
                                               & builderFamilias.Eq(x => x.GUID_CATEGORIA, categoria.GUID);
                    var familias = familiasRepositorio.Encontrar(filterFamilias);

                    Familia familia = null;
                    if (familias.Count() == 0)
                    {

                        familia = new Familia(guidCatalogo, categoria.GUID);

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

                        familiasRepositorio.Inserir(familia);
                    }
                    else
                    {
                        familia = familias.First();
                    }

                    RelacaoFamiliaItem relacaoFamiliaItem = new RelacaoFamiliaItem()
                    {
                        GUID_FAMILIA = familia.GUID,
                        GUID_ITEM = item.GUID,
                        GUID_CATEGORIA = categoria.GUID
                    };

                    relacaoFamiliaItemRepositorio.Inserir(relacaoFamiliaItem);

                }

            }
        }
    }
}
