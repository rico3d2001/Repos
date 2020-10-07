using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterListaPQs
{
    public class ObterListaPQsQuery : IRequest<List<EstadoApp>>
    {
        RepoProjetos _repoProjetos;

        public ObterListaPQsQuery(string siglaUsuario, string guidProjeto, string guidDiscilina, string conectionString)
        {
            TextoConexao = conectionString;
            _repoProjetos = new RepoProjetos(conectionString);
          var projeto =  _repoProjetos.ObterProjeto(guidProjeto);

            IdentidadeEstado = new IdentidadeEstado(projeto, siglaUsuario, guidDiscilina);
         }

        public IdentidadeEstado IdentidadeEstado { get; set; }
        public string TextoConexao { get; set; }
    }
}
