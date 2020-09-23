using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoCategoria
    {
        BaseMDBRepositorio<Categoria> _categoriasRepositorio;

        public RepoCategoria()
        {
            _categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");
        }

        public Categoria ObterPorTipoDeItem(TipoItemEng tipoItemEng)
        {
            var categorias = _categoriasRepositorio.Encontrar(
                           Builders<Categoria>.Filter.Eq(x => x.GUID_TIPO, tipoItemEng.GUID));

            return categorias.Count() == 1 ? categorias.First() : null;
        }

        public void CadastrarCategoria(Categoria categoria)
        {
            _categoriasRepositorio.Inserir(categoria);
        }

        public void CriaCategoria(string catalogoGUID)
        {
            var tipoItemEngRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");

            var tipos = tipoItemEngRepositorio.Obter();

            //var categoriaRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");

            foreach (var tipo in tipos)
            {
                Categoria categoria = new Categoria(catalogoGUID, tipo.GUID);


                _categoriasRepositorio.Inserir(categoria);
            }
        }

        public List<Categoria> ObterPorCatalogo(CatalogoEntidade catalogo)
        {
            return _categoriasRepositorio.Encontrar(Builders<Categoria>.Filter.Eq(x => x.GUID_CATALOGO, catalogo.GUID));
        }
    }
}
