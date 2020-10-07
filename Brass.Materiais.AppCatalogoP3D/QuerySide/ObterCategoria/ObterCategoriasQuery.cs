using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCategoria
{
    public class ObterCategoriasQuery : IRequest<Familia[]>
    {
        public ObterCategoriasQuery(string guidCatalogo, string guidTipoItem, string conectionString)
        {
            GuidCatalogo = guidCatalogo;
            GuidTipoItem = guidTipoItem; 
            TextoConexao = conectionString;
        }

        public string TextoConexao { get; set; }
        public string GuidCatalogo { get; set; }
        public string GuidTipoItem { get; set; }

        
    }
}
