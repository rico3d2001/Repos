using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoFamilia
    {
        BaseMDBRepositorio<Familia> _repositorioFamilias;
        public RepoFamilia()
        {
            _repositorioFamilias = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
        }

        public Familia ObterFamiliaPorDescricao(string descricao)
        {
            var familias = _repositorioFamilias.Encontrar(Builders<Familia>.Filter.Eq(x => x.PartFamilyLongDesc.VALOR, descricao));

            return familias.Count() == 1 ? familias.First() : null;
        }

        public Familia ObterFamiliaPorValor(ValorTabelado valor)
        {
            var familias = _repositorioFamilias.Encontrar(Builders<Familia>.Filter.Eq(x => x.PartFamilyLongDesc.VALOR, valor.VALOR));

            return familias.Count() == 1 ? familias.First() : null;
        }

        public void Cadastrar(Familia familia)
        {
            _repositorioFamilias.Inserir(familia);
        }

        public List<Familia> ExtraiItensCategoria(string guidCatalogo, string guidCategoria)
        {




            var lista = new List<Familia>();

            var itemPipeRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");


            var builder = Builders<ItemPipe>.Filter;
            var filterItemPipeEstoque = builder.Eq(x => x.GUID_CATALOGO, guidCatalogo) & builder.Eq(x => x.GUID_TIPO_ITEM, guidCategoria);
            var itens = itemPipeRepositorio.Encontrar(filterItemPipeEstoque);

            var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");

            var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");

            foreach (var item in itens)
            {

                var filtroRelacaoPropriedadeItem = Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, item.GUID);

                var relacoes = relacaoPropriedadeItemRepositorio.Encontrar(filtroRelacaoPropriedadeItem);


                var familia = new Familia(guidCatalogo, guidCategoria, new ValorTabelado("", ""));

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



            }


            return lista;
        }

        public List<Familia> ObterPorCategoria(Categoria categoria)
        {
            return _repositorioFamilias.Encontrar(Builders<Familia>.Filter.Eq(x => x.GUID_CATEGORIA, categoria.GUID));
        }
    }
}
