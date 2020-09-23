using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCategoria
{
    public class ObterCategoriasQueryHandler : Notifiable, IRequestHandler<ObterCategoriasQuery, Familia[]>
    {

        RepoFamilia _repoFamilia;
        public ObterCategoriasQueryHandler()
        {
            _repoFamilia = new RepoFamilia();
        }

        public Task<Familia[]> Handle(ObterCategoriasQuery request, CancellationToken cancellationToken)
        {
            var resultado = _repoFamilia.ExtraiItensCategoria(request.GuidCatalogo, request.GuidTipoItem);

            return Task.FromResult(resultado.ToArray());
        }
    }
}
