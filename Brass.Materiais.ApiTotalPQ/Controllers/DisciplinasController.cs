using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppGestao.QuerySide.ObterDisciplinas;
using Brass.Materiais.Nucleo.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : GeralController
    {
        private readonly IMediator _mediator;

        public DisciplinasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /api/disciplinas  CatalogoDTO
        [HttpGet]
        public Task<Disciplina[]> ObterDisciplinas()
        {
            var query = new ObterDisciplinasQuery(_conectStringMongo);

            return _mediator.Send(query);

        }


    }
}
