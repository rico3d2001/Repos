using Brass.Materiais.AppBIM360.QuerySide.ObterAreasTagsQueryBIM360;
using Brass.Materiais.AppVPN.QuerySide.ObterAreasTags;
using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brass.Materiais.ApiBIM.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasTagController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AreasTagController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // 
        //  areas/AreasTag/de602b02-5cf5-4761-a47e-4303fe10071b

        [HttpGet("{guid_projeto}/{origem}")]
        public Task<List<AreaPlanejada>> GetAreasTag(string guid_projeto, string origem)//, string tipo)
        {
            switch (origem)
            {
                case "VPN":
                    {
                        var obterAreasTagsQuery = new ObterAreasTagsQuery(guid_projeto);
                        return _mediator.Send(obterAreasTagsQuery);
                    }
                case "BIM360":
                    {
                        var obterAreasTagsQuery = new ObterAreasTagsQueryBIM360Query(guid_projeto);
                        return _mediator.Send(obterAreasTagsQuery);
                    }
                default:
                    {
                        var obterAreasTagsQuery = new ObterAreasTagsQuery(guid_projeto);
                        return _mediator.Send(obterAreasTagsQuery);
                    }

            }





        }
    }
}
