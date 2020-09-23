using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.PQ.Dominio.Servico.Commands.Requests
{
    //public class CriaNomesPropriedades
    //{
    //    public List<NomeTipoPropriedade> ExtraiNomes()
    //    {
    //        var propriedadesRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");

    //        return propriedadesRepositorio.Obter(); 
    //    }

    //    public List<Familia> ObtemFamilias(string guidCategoria)
    //    {
    //        var familiaItemRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");


    //        return familiaItemRepositorio
    //                    .Encontrar(Builders<Familia>
    //                    .Filter.Eq(x => x.GUID_CATEGORIA, guidCategoria));
    //    }

       
        
        
    //    private List<Familia> distinguir(List<Familia> familias)
    //    {
    //        List<Familia> resposta = new List<Familia>();

    //        foreach (var entrada in familias)
    //        {
    //            if(resposta.FirstOrDefault(x => x.PartFamilyLongDesc.VALOR == entrada.PartFamilyLongDesc.VALOR) == null)
    //            {
    //                resposta.Add(entrada);
    //            }
    //        }

    //        return resposta;
    //    }
        
    //    public List<PropriedadeCadastro> ObtemPropriedades(string guidItem)
    //    {
    //        List<PropriedadeCadastro> listaResult = new List<PropriedadeCadastro>();



    //        return listaResult;
    //    }

    //    public void CriaFamilias(string guidCatalogo)
    //    {

    //        var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
    //        var builderNomeTipoPropriedade = Builders<NomeTipoPropriedade>.Filter;
    //        var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
    //        var relacaoFamiliaItemRepositorio = new BaseMDBRepositorio<RelacaoFamiliaItem>("Catalogo", "RelacaoFamiliaItem");
    //        var itemPipeRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
    //        var categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");
    //        var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
    //        var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
    //        var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");

    //        var propriedadePartFamilyLongDesc = nomeTipoPropriedadeRepositorio
    //            .Encontrar(builderNomeTipoPropriedade.Eq(x => x.NOME, "PartFamilyLongDesc")).First();



    //        var categorias = categoriasRepositorio
    //            .Encontrar(Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));



    //        var todasRelacoesPropriedadeItemRepositorio = relacaoPropriedadeItemRepositorio.Obter();

    //        var itensPorCatalogo = itemPipeRepositorio
    //               .Encontrar(
    //               Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));

    //        var todasPropriedades = propriedadeItemRepositorio.Obter();


    //        var todosValores = valorTabeladoRepositorio.Obter();


    //        var fams =
    //                (from propriedade in todasPropriedades
    //                 join rel in todasRelacoesPropriedadeItemRepositorio on propriedade.GUID equals rel.GUID_PROPRIEDADE
    //                 join val in todosValores on propriedade.GUID_VALOR equals val.GUID
    //                 join item in itensPorCatalogo on rel.GUID_ITEM_ENG equals item.GUID
    //                 join categ in categorias on item.GUID_TIPO_ITEM equals categ.GUID_TIPO
    //                 where propriedade.GUID_TIPO == propriedadePartFamilyLongDesc.GUID
    //                 select new Familia(guidCatalogo, categ.GUID, val)).ToList();



    //        var resumo = distinguir(fams);

            
           

    //        foreach (var fam in resumo)
    //        {


              




    //            var etapa1 = todasPropriedades.Where(x => x.GUID_VALOR == fam.PartFamilyLongDesc.GUID).ToList();

    //            var etapa2 = todasRelacoesPropriedadeItemRepositorio.Where(x => x.GUID_PROPRIEDADE == etapa1.First().GUID).ToList();

    //            foreach (var item in etapa2)
    //            {

    //                var etapa3 = itensPorCatalogo.Where(x => x.GUID == item.GUID_ITEM_ENG).ToList();
    //                if (etapa3.Count == 1)
    //                {
    //                    fam.AdicionaIdentificadorItem(etapa3.First().GUID);
    //                }

    //            }



               


    //            familiasRepositorio.Inserir(fam);

    //        }


    //    }


        

    //    public List<Familia> ExtraiItensCategoria(string guidCatalogo, string guidCategoria)
    //    {

           
         

    //        var lista = new List<Familia>();

    //        var itemPipeRepositorio = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

     
    //        var builder = Builders<ItemPipe>.Filter;
    //        var filterItemPipeEstoque = builder.Eq(x => x.GUID_CATALOGO, guidCatalogo) & builder.Eq(x => x.GUID_TIPO_ITEM, guidCategoria);
    //        var itens = itemPipeRepositorio.Encontrar(filterItemPipeEstoque);

    //        var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");

    //        var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");

    //        foreach (var item in itens)
    //        {

    //            var filtroRelacaoPropriedadeItem = Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, item.GUID);

    //            var relacoes = relacaoPropriedadeItemRepositorio.Encontrar(filtroRelacaoPropriedadeItem);

      
    //            var familia = new Familia(guidCatalogo, guidCategoria, new ValorTabelado("",""));

    //            foreach (var relacao in relacoes)
    //            {

    //                var filtroPropriedadeItem = Builders<PropriedadeItem>.Filter.Eq(x => x.GUID, relacao.GUID_PROPRIEDADE);

    //                var propriedadeItem = propriedadeItemRepositorio.Encontrar(filtroPropriedadeItem).First();


    //                var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
    //                var builderNomeTipoPropriedade = Builders<NomeTipoPropriedade>.Filter;
    //                var filtroNomeTipoPropriedade = builderNomeTipoPropriedade.Eq(x => x.GUID, propriedadeItem.GUID_TIPO)
    //                                                & builderNomeTipoPropriedade.Eq(x => x.NOME, "PartFamilyLongDesc");
    //                var propriedades = nomeTipoPropriedadeRepositorio.Encontrar(filtroNomeTipoPropriedade);

    //                if (propriedades.Count() > 0)
    //                {


    //                    var strPropriedade = propriedades.First().NOME;

    //                    if (strPropriedade == "PartFamilyLongDesc")
    //                    {
    //                        var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
    //                        var filtroValorTabelado = Builders<ValorTabelado>.Filter.Eq(x => x.GUID, propriedadeItem.GUID_VALOR);
    //                        var valor = valorTabeladoRepositorio.Encontrar(filtroValorTabelado).First();
    //                        string strValor = valor.VALOR.Replace('"', '¨');


    //                        familia.GetType().GetProperty(strPropriedade).SetValue(familia, strValor);

    //                        break;
    //                    }

    //                }

    //            }



    //        }


    //        return lista; 
    //    }



    //    public List<RamalArvoreCatalogo> ObtemRamalFamilias(string guidCategoria)
    //    {
    //        List<RamalArvoreCatalogo> lista = new List<RamalArvoreCatalogo>();

       
    //        var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
    //        var filtroFamilias = Builders<Familia>.Filter.Eq(x => x.GUID_CATEGORIA, guidCategoria);
    //        var familias = familiasRepositorio.Encontrar(filtroFamilias);

    //        familias.ForEach(x => lista.Add(new RamalArvoreCatalogo(x.PartFamilyLongDesc.VALOR, x.GUID, x.GUID_CATEGORIA, 2)));



    //        return lista;
    //    }



    //    public List<RamalArvoreCatalogo> ExtraiTroncoCatalogo()
    //    {
    //        List<RamalArvoreCatalogo> lista = new List<RamalArvoreCatalogo>();

    //        var catalogoRepositorio = new BaseMDBRepositorio<CatalogoEntidade>("Catalogo", "Catalogo");
    //        var catalogos = catalogoRepositorio.Obter();
    //        foreach (var catalogo in catalogos)
    //        {

    //            RamalArvoreCatalogo ramal = new RamalArvoreCatalogo(catalogo.NOME, catalogo.GUID, "raiz", 0);

    //            var categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");
    //            var filtroCategorias = Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, catalogo.GUID);
    //            var categorias = categoriasRepositorio.Encontrar(filtroCategorias);

    //            var tipoItemEngRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");
    //            foreach (var categoria in categorias)
    //            {
    //                var filtro = Builders<TipoItemEng>.Filter.Eq(x => x.GUID, categoria.GUID_TIPO);
    //                var nomes = tipoItemEngRepositorio.Encontrar(filtro);
    //                if (nomes.Count() > 0)
    //                {
    //                    ramal.children.Add(
    //                        new RamalArvoreCatalogo(
    //                            nomes.First().NOME,
    //                            categoria.GUID,
    //                            catalogo.GUID,
    //                            1));
    //                }

    //            }

    //            lista.Add(ramal);
    //        }

    //        return lista;
    //    }




    //}
}
