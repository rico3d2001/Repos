using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Dominio.Servico.Commands.Requests
{
    public class CriaCategorias
    {
        public void Injetar(string catalogoGUID)
        {
            var tipoItemEngRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");

            var tipos = tipoItemEngRepositorio.Obter();

            var categoriaRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");

            foreach (var tipo in tipos)
            {
                Categoria categoria = new Categoria()
                {
                    GUID_CATALOGO = catalogoGUID,
                    GUID_TIPO = tipo.GUID
                };

                categoriaRepositorio.Inserir(categoria);
            }
        }
    }
}
