using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo.ViewModel;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCategoria;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : GeralController
    {
        private readonly IMediator _mediator;

        public CatalogosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: catalogos/ItensEng/Arvore
        [HttpGet("ItensEng/Arvore/{guidDisciplina}")]
        public Task<RamalArvoreCatalogo[]> GetArvore(string guidDisciplina)//IEnumerable<RamalEstoque> GetArvore()
        {

            var query = new ObtemArvoreCatalogoQuery(guidDisciplina, _conectStringMongo);

            return _mediator.Send(query);


        }

        ////GET: catalogos/Dimensoes/a3bc03da-c013-4a19-b328-fc46c06d699d/ef0179fc-76e9-4e60-a9b1-bfab57139d8e
        //[HttpGet("Dimensoes/{guid_familia}/{guid_Atividade}")]
        //public Task<ItemParaAtivar[]> GetDimensoes(string guid_familia, string guid_Atividade)
        //{
        //    var query = new ObterItensFamiliaQuery(guid_familia, guid_Atividade);

        //    return _mediator.Send(query);
        //}




        //// GET: ItensEng/Linhas/0154689d-a6af-4504-a5c2-5552d2522f70
        ////    catalogos/ItensEng/Linhas/9dcd21a8-43f0-4875-bf95-04255f7b2e68
        //[HttpGet("ItensEng/Linhas/{guidCatalogo}/{guidTipoItem}")]
        //public IEnumerable<Familia> GetLinhas(string guidCatalogo, string guidTipoItem)

        //   ItensEng/Linhas/532f43f4-59eb-4962-a4a9-edf7cee699a5/0154689d-a6af-4504-a5c2-5552d2522f70
        [HttpGet("ItensEng/Linhas/{guidCatalogo}/{guidTipoItem}")]
        public Task<Familia[]> GetCategorias(string guidCatalogo, string guidTipoItem)
        {

            //ObterCategoriasQuery
            var query = new ObterCategoriasQuery(guidCatalogo, guidTipoItem, _conectStringMongo);

            return _mediator.Send(query);


            //CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            //return criaArvoreCatalogo.ExtraiItensCategoria("532f43f4-59eb-4962-a4a9-edf7cee699a5", guidTipoItem);



        }



    }
}
