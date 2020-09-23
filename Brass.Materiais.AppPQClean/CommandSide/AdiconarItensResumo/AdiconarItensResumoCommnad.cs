using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppPQClean.CommandSide.AdiconarItensResumo
{
    public class AdiconarItensResumoCommnad : Notifiable, IRequest
    {
        public AdiconarItensResumoCommnad(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ, List<ItemPQ> itens)
        {

            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(guidProjeto, siglaUsuario, guidDisciplina), numeroPQ);
            Itens = itens;
            NumeroPQ = numeroPQ;
        }

        public IdentidadePQ IdentidadePQ { get; set; }
        public List<ItemPQ> Itens { get; set; }
        public int NumeroPQ { get; set; }



        public void Validate()
        {

        }
    }
}
