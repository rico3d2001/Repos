using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterTodosItensPQ
{
    public class ObterTodosItensPQQueryHandler : Notifiable, IRequestHandler<ObterTodosItensPQQuery, ItemPQ[]>
    {
        RepoItemPQ _repoItemPQ;

        public ObterTodosItensPQQueryHandler()
        {
            _repoItemPQ = new RepoItemPQ();
        }
        public Task<ItemPQ[]> Handle(ObterTodosItensPQQuery request, CancellationToken cancellationToken)
        {
            var itens = _repoItemPQ.ObterItensPQPorProjeto(request.GuidProjeto);

            var itensPQ = itens.ToArray();

            return Task.FromResult(itensPQ);
        }
    }
}
