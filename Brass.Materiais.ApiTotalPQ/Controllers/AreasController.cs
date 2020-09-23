using Brass.Materiais.AppPQClean.QuerySide.ObterEAP;
using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AreasController(IMediator mediator)
        {
            _mediator = mediator;
        }




        // GET: areas/48e9eb46-5a26-4b9c-9a53-163d448336fb         /Volumetrica
        // GET: areas/48e9eb46-5a26-4b9c-9a53-163d448336fb          /Processo
        [HttpGet("{guid_projeto}")]
        public Task<EAP> Get(string guid_projeto)//, string tipo)
        {

            return _mediator.Send(new ObterEAPQuery(guid_projeto, "BIM", "EAPGeral"));

        }

       
    }
}
