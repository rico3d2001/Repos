using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterProjetos
{
    public class ObterProjectosQueryHandle : Notifiable, IRequestHandler<ObterProjectosQuery, Projeto[]>
    {

        public Task<Projeto[]> Handle(ObterProjectosQuery request, CancellationToken cancellationToken)
        {
            var projetosRepositorio = new RepoProjetos(request.TextoConexao);

            var projetos = projetosRepositorio.ObterTodos().ToArray();

            return Task.FromResult(projetos);


        }
















    }
}
