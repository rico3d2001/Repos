using Brass.Materiais.DominioPQ.PQ.Entities;
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

namespace Brass.Materiais.AppPQClean.QuerySide.ObterPQAtiva
{
    public class ObterPQAtivaQueryHandler : Notifiable, IRequestHandler<ObterPQAtivaQuery, DataPQ>
    {

        RepoPQ _repoPQ;
        public ObterPQAtivaQueryHandler()
        {
            _repoPQ = new RepoPQ();
           
        }


        public Task<DataPQ> Handle(ObterPQAtivaQuery request, CancellationToken cancellationToken)
        {

            var pqsAtivas = _repoPQ.ObterPQsAtivas(request.IdentidadePQ);

            if (pqsAtivas.Count == 1)
            {
                return Task.FromResult(pqsAtivas.First());
                
            }
            else
            {
                return null;
            }

           
        }
    }
}
