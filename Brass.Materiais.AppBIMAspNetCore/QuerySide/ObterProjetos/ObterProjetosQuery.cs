using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppBIMAspNetCore.QuerySide.ObterProjetos
{
    public class ObterProjetosQuery : IRequest<Projeto[]>
    {
        public ObterProjetosQuery(string connectionString)
        {
            TextoConexao = connectionString;
        }

        public string TextoConexao { get; set; }
    }
}
