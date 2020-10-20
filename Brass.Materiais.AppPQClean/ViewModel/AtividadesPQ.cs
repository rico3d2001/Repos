using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppPQClean.ViewModel
{
    public class AtividadesPQ
    {

        public AtividadesPQ(ItemPQ itemPQ, string conexao)
        {
            var repoAtividade = new RepoAtividade(conexao);

            VVV = repoAtividade.ObterPorGuid(itemPQ.Atividade.GUID_PAI);
            UU = repoAtividade.ObterPorGuid(VVV.GUID_PAI);
            TT = repoAtividade.ObterPorGuid(UU.GUID_PAI);
            K = repoAtividade.ObterPorGuid(TT.GUID_PAI);
        }


        

        public Atividade VVV { get; set; }
        public Atividade UU { get; set; }
        public Atividade TT { get; set; }
        public Atividade K { get; set; }



    }
}
