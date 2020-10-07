using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppGestao.QuerySide.ObterProjetos
{
    public class ObterProjectosQuery : IRequest<Projeto[]>
    {
        public ObterProjectosQuery(string connectionString)
        {
            TextoConexao = connectionString;
        }

        public string TextoConexao { get; set; }
    }
}
