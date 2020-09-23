using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObterArvoreCatalogo.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.GestaoCatalogo.Service.TesteUnit
{
    [TestClass]
    public class TestesRamaisCatalogo
    {
        [TestMethod]
        public void CriaRamais()
        {

            List<RamalArvoreCatalogo> ramalArvoreCatalogos = new List<RamalArvoreCatalogo>();

            var ramalArvoreCatalogoRepositorio = new BaseMDBRepositorio<RamalArvoreCatalogo>("Catalogo", "RamalEstoque");

            var catalogosRepositorio = new BaseMDBRepositorio<CatalogoEntidade>("Catalogo", "Catalogo");

            var tipoItemEngRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");

            var categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");

            var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");

            var catalogos = catalogosRepositorio.Obter();


            foreach (var catalogo in catalogos)
            {
                var ramalCatalogo = new RamalArvoreCatalogo(catalogo.NOME, catalogo.GUID, "", 0);

                ramalArvoreCatalogos.Add(ramalCatalogo);


                var categorias = categoriasRepositorio.Encontrar(Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, catalogo.GUID));
                foreach (var categoria in categorias)
                {
                    var tipoItemEng = tipoItemEngRepositorio.Obter(categoria.GUID_TIPO);
                    var ramalCategoria = new RamalArvoreCatalogo(tipoItemEng.NOME, categoria.GUID, catalogo.GUID, 1);
                    ramalArvoreCatalogos.Add(ramalCategoria);

                    var familias = familiasRepositorio.Encontrar(Builders<Familia>.Filter.Eq(x => x.GUID_CATEGORIA, categoria.GUID));
                    foreach (var familia in familias)
                    {
                        var ramalFamilia = new RamalArvoreCatalogo(familia.PartFamilyLongDesc.VALOR, familia.GUID, categoria.GUID, 2);
                    }
                }
            }





        }
    }
}
