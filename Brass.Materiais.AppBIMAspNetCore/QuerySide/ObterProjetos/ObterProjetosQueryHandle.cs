using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppBIMAspNetCore.QuerySide.ObterProjetos
{
    public class ObterProjetosQueryHandle : Notifiable, IRequestHandler<ObterProjetosQuery, Projeto[]>
    {



        

        BaseMDBRepositorio<Projeto> _projetosRepositorio;

        public ObterProjetosQueryHandle()
        {

            _projetosRepositorio = new BaseMDBRepositorio<Projeto>("BIM", "Projetos");
        }


        public Task<Projeto[]> Handle(ObterProjetosQuery request, CancellationToken cancellationToken)
        {
            var projetos = _projetosRepositorio.Obter().ToArray();

            return Task.FromResult(projetos);


        }
















    }
}
