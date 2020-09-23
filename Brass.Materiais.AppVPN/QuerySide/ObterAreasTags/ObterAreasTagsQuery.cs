using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppVPN.QuerySide.ObterAreasTags
{
    public class ObterAreasTagsQuery : IRequest<List<AreaPlanejada>>
    {
        public ObterAreasTagsQuery(string guidProjeto)
        {
            GuidProjeto = guidProjeto;
        }

        public string GuidProjeto { get; set; }
    }
}
