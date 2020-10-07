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

        
        public Task<ItemPQ[]> Handle(ObterTodosItensPQQuery request, CancellationToken cancellationToken)
        {

            _repoItemPQ = new RepoItemPQ(request.TextoConexao);

            int paginaAtual = request.Pagina;
            int itensPagina = request.Limite;

            var itens = _repoItemPQ.ObterItensPQPorProjeto(request.GuidProjeto);

            var itensPQ = itens
                          .Skip((paginaAtual - 1) * itensPagina)
                          .Take(itensPagina);

            return Task.FromResult(itensPQ.ToArray());
        }
    }
}
