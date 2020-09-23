using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppBIM360.QuerySide.ObterAreasTagsQueryBIM360
{
    public class ObterAreasTagsQueryBIM360Query : IRequest<List<AreaPlanejada>>
    {
        public ObterAreasTagsQueryBIM360Query(string guidProjeto)
        {
            GuidProjeto = guidProjeto;
        }

        public string GuidProjeto { get; set; }
    }
}
