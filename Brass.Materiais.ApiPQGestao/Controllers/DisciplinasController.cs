﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppGestao.QuerySide.ObterDisciplinas;
using Brass.Materiais.Nucleo.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiPQGestao.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
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
            var query = new ObterDisciplinasQuery();

            return _mediator.Send(query);

        }


    }
}