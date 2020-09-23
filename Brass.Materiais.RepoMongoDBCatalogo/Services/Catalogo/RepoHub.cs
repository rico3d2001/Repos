using Brass.Materiais.DominioPQ.BIM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoHub
    {
        BaseMDBRepositorio<Hub> _repoHub;
        BaseMDBRepositorio<Projeto> _repoProjetos;

        public RepoHub()
        {
            _repoHub = new BaseMDBRepositorio<Hub>("BIM", "Hubs");
            _repoProjetos = new BaseMDBRepositorio<Projeto>("BIM", "Projetos");
        }

        public List<Hub> ObterTodosHubs()
        {
            return _repoHub.Obter();
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
