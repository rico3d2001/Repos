using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterClientes
{
    public class ObterClientesQueryHandler : Notifiable, IRequestHandler<ObterClientesQuery, Cliente[]>
    {
     

       


        public Task<Cliente[]> Handle(ObterClientesQuery request, CancellationToken cancellationToken)
        {
            var repositorio = new RepoClientes(request.TextoConexao);

            var projetos = repositorio.ObterTodos().ToArray();

            return Task.FromResult(projetos);


        }
    }
}
