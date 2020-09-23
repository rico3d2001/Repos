using Brass.Materiais.Nucleo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterDisciplinas
{
    public class ObterDisciplinasQueryHandler : Notifiable, IRequestHandler<ObterDisciplinasQuery, Disciplina[]>
    {
        RepoDisciplinas _repoDisciplinas;
        public ObterDisciplinasQueryHandler()
        {
            _repoDisciplinas = new RepoDisciplinas();
        }



        public Task<Disciplina[]> Handle(ObterDisciplinasQuery request, CancellationToken cancellationToken)
        {
            var disciplinas = _repoDisciplinas.ObterTodasDisciplinas();


            return Task.FromResult(disciplinas.ToArray());
        }
    }
}
