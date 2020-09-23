using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoTipoDeItem
    {

        BaseMDBRepositorio<TipoItemEng> _tipoItemEngRepositorio;

        public RepoTipoDeItem()
        {
            _tipoItemEngRepositorio = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");
        }

        public TipoItemEng ObterPorNome(string nome)
        {
            var tipos = _tipoItemEngRepositorio.Encontrar(
                           Builders<TipoItemEng>.Filter.Eq(x => x.NOME, nome));

            return tipos.Count() == 1 ? tipos.First() : null;
        }

        public void CadastrarTipo(TipoItemEng tipoItemEng)
        {
            _tipoItemEngRepositorio.Inserir(tipoItemEng);
        }

        public TipoItemEng ObterPorGuid(string gUID_TIPO)
        {
            return _tipoItemEngRepositorio.Obter(gUID_TIPO);
        }
    }
}
