using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoNivelAtividade : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<NivelAtividade> _repoNivelAtividade;
        public RepoNivelAtividade(string conectionString) : base(conectionString)
        {
            _repoNivelAtividade = new BaseMDBRepositorio<NivelAtividade>(new ConexaoMongoDb("MontagemPQ", conectionString), "NivelAtividade");
        }

        public void Cadastar(NivelAtividade nivelAtividade)
        {
            _repoNivelAtividade.Inserir(nivelAtividade);
        }

        public List<NivelAtividade> ObterListaDoCliente(Cliente cliente)
        {
            return _repoNivelAtividade.Encontrar(Builders<NivelAtividade>.Filter.Eq(x => x.GUID_CLIENTE, cliente.GUID));
           
        }

        public NivelAtividade ObterPorNomeDoNivel(string codigo)
        {
            var niveis = _repoNivelAtividade.Encontrar(Builders<NivelAtividade>.Filter.Eq(x => x.Nome, codigo));

            return niveis.Count() == 1 ? niveis.First() : null;
        }

        public List<NivelAtividade> ObterTodos()
        {
           return _repoNivelAtividade.Obter();
        }
    }
}
