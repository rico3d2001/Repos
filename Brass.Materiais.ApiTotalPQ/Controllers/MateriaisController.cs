using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterFamiliaParaAdicao;
using Brass.Materiais.AppCatalogoP3D.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MateriaisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // materiais/764398e4-1de1-40a4-9fb1-2f66c39d5ec2
        [HttpGet("{guidFamilia}")]
        public Task<ItemParaAdicionar[]> Get(string guidFamilia)
        {

            var query = new ObterFamiliaParaAdicaoQuery(guidFamilia);

            return _mediator.Send(query);

        }
    }
}
