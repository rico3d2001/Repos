using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppBIMAspNetCore.QuerySide.ObterProjetos
{
    public class ObterProjetosQueryHandle : Notifiable, IRequestHandler<ObterProjetosQuery, Projeto[]>
    {


        public Task<Projeto[]> Handle(ObterProjetosQuery request, CancellationToken cancellationToken)
        {
            var projetosRepositorio = new RepoProjetos(request.TextoConexao);

            var projetos = projetosRepositorio.ObterTodos().ToArray();

            return Task.FromResult(projetos);


        }
















    }
}
