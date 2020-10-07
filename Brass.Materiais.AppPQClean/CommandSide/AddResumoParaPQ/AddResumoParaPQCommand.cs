using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppPQClean.CommandSide.AddResumoParaPQ
{
    public class AddResumoParaPQCommand : Notifiable, IRequest
    {
       // PlanilhaPQ<LinhaVale> _planilhaVale;



        

        public AddResumoParaPQCommand(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ, List<ItemPQ> itens, string conectionString)
        {
            TextoConexao = conectionString;
            var repoProjetos = new RepoProjetos(conectionString);
            var projeto = repoProjetos.ObterProjeto(guidProjeto);
            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(projeto, siglaUsuario, guidDisciplina), numeroPQ);
            ItensParametro = itens;
        }

        public IdentidadePQ IdentidadePQ { get; set; }

        public List<ItemPQ> ItensParametro { get; set; }
        public string TextoConexao { get; set; }
    }
}
