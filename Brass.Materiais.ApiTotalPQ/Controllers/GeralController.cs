using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeralController : ControllerBase
    {
        protected string _conectStringMongo;

        public GeralController()
        {
            _conectStringMongo = "local";
            //_conectStringMongo = "testeAtlas";
            
        }
    }
}
