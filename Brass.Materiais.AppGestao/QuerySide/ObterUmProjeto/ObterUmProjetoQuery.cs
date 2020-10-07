using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppGestao.QuerySide.ObterUmProjeto
{
    public class ObterUmProjetoQuery : IRequest<Projeto>
    {
        public ObterUmProjetoQuery(string siglaUsuario, string guidProjeto, string conectionString)
        {
            TextoConexao = conectionString;
            SiglaUsuario = siglaUsuario;
            GuidProjeto = guidProjeto;
        }

        public string SiglaUsuario { get; set; }
        public string GuidProjeto { get; set; }
        public string TextoConexao { get; set; }
    }
}
