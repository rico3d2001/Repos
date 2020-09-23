using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterClientes
{
    public class ObterClientesQueryHandler : Notifiable, IRequestHandler<ObterClientesQuery, Cliente[]>
    {
        BaseMDBRepositorio<Cliente> _repositorio;

        public ObterClientesQueryHandler()
        {

            _repositorio = new BaseMDBRepositorio<Cliente>("BIM", "Clientes");
        }


        public Task<Cliente[]> Handle(ObterClientesQuery request, CancellationToken cancellationToken)
        {
            var projetos = _repositorio.Obter().ToArray();

            return Task.FromResult(projetos);


        }
    }
}
