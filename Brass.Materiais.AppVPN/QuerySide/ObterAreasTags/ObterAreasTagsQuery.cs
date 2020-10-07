using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppVPN.QuerySide.ObterAreasTags
{
    public class ObterAreasTagsQuery : IRequest<List<NumeroAtivo>>
    {
        public ObterAreasTagsQuery(string guidProjeto, string conectionString)
        {
            GuidProjeto = guidProjeto;
            TextoConexao = conectionString;
        }

        public string GuidProjeto { get; set; }
        public string TextoConexao { get; set; }
    }
}
