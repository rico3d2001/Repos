using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterPQ
{
    public class ObterPQQueryHandle : Notifiable, IRequestHandler<ObterPQQuery, DataPQ>
    {
        RepoPQ _repoPQ;

       
        public Task<DataPQ> Handle(ObterPQQuery request, CancellationToken cancellationToken)
        {
            _repoPQ = new RepoPQ(request.TextoConexao);

            var pq = _repoPQ.ObterPQ(request.IdentidadePQ);



            return Task.FromResult(pq);
        }
    }
}
