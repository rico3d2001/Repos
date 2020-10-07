using Brass.Materiais.DominioPQ.BIM.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoHub : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<Hub> _repoHub;
        BaseMDBRepositorio<Projeto> _repoProjetos;

        public RepoHub(string conectionString) : base(conectionString)
        {
            _repoHub = new BaseMDBRepositorio<Hub>(new ConexaoMongoDb("BIM", conectionString), "Hubs");
        }

        public List<Hub> ObterTodosHubs()
        {
            return _repoHub.Obter();
        }

        public Hub ObterDaSiglaDoUsuario(string siglaUsuario)
        {
            var hubs = _repoHub.Encontrar(
            Builders<Hub>.Filter.Eq(x => x.Usuario.Sigla, siglaUsuario));

            return hubs.Count() == 1 ? hubs.First() : null;
        }

        public void PassarProjetosParaVPN(Hub hub)
        {
            foreach (var projeto in hub.Projetos)
            {
                projeto.Origem = "VPN";
            }

            _repoHub.Atualizar(hub);
        }

        public Hub ObterPorGuid(string guidHub)
        {
            return _repoHub.Obter(guidHub);
        }

        public void ModificarHub(Hub hub)
        {
            _repoHub.Atualizar(hub);
        }

        public void AdicionarProjeto(Projeto projeto, Hub hub)
        {
            _repoProjetos.Inserir(projeto);
            hub.AdicionaProjeto(projeto);
            _repoHub.Atualizar(hub);
        }
    }
}
