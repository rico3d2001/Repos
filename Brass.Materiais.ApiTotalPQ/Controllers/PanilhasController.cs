using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppBulkLoad.Services.CommandSide;
using Brass.Materiais.AppBulkLoad.Services.CommandSide.AtividadeBulkLoad;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PanilhasController : GeralController
    {
        private readonly IMediator _mediator;

        public PanilhasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("");
            }

            var query = new AtividadeBulkLoadCommand(file.FileName, "seiLa", _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

          
        }


    }
}
