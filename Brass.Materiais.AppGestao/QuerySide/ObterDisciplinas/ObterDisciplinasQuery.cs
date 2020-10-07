using Brass.Materiais.Nucleo.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterDisciplinas
{
    public class ObterDisciplinasQuery : IRequest<Disciplina[]>
    {
        public ObterDisciplinasQuery(string connecitonString)
        {
            TextoConexao = connecitonString;
        }

        public string TextoConexao { get; set; }
    }
}
