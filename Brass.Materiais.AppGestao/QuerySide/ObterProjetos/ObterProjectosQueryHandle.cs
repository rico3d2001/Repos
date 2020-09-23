using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterProjetos
{
    public class ObterProjectosQueryHandle : Notifiable, IRequestHandler<ObterProjectosQuery, Projeto[]>
    {



        

        BaseMDBRepositorio<Projeto> _projetosRepositorio;

        public ObterProjectosQueryHandle()
        {

            _projetosRepositorio = new BaseMDBRepositorio<Projeto>("BIM", "Projetos");
        }


        public Task<Projeto[]> Handle(ObterProjectosQuery request, CancellationToken cancellationToken)
        {
            var projetos = _projetosRepositorio.Obter().ToArray();

            return Task.FromResult(projetos);


        }
















    }
}
