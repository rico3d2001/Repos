using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterUmProjeto
{
    public class ObterUmProjetoQueryHandle : Notifiable, IRequestHandler<ObterUmProjetoQuery, Projeto>
    {
      
        public Task<Projeto> Handle(ObterUmProjetoQuery request, CancellationToken cancellationToken)
        {
            var projetosRepositorio = new RepoProjetos(request.TextoConexao);

            var projeto = projetosRepositorio.ObterProjeto(request.GuidProjeto);

            return Task.FromResult(projeto);
        }
    }
}
