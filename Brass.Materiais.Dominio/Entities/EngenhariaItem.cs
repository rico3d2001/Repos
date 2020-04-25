using Brass.Materiais.Dominio.Interfaces;
using Brass.Materiais.Dominio.ValueObjects;
using Brass.Materiais.Dominio.ValueObjects.Descricoes;
using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.Dominio.Entities
{
    public class EngenhariaItem:Entity
    {
        private ICodificacao _codificacao;

        public EngenhariaItem(NomeItem nomeItem, EngenhariaItem itemPai, ICodificacao codificacao)
        {
            NomeItem = nomeItem;
            ItemPai = itemPai;
            _codificacao = codificacao;

           
        }

        public NomeItem NomeItem { get; set; }
        public EngenhariaItem ItemPai { get; set; }
        public CodigoItem CodigoItem { get { return _codificacao.Codificar(Propriedades); }  }
        public GrupoDescricoes GrupoDescricoes { get; set; }
        public List<Propriedade> Propriedades { get; set; }



        public void AddPropriedade(Propriedade propriedade)
        {
            

            Propriedades.Add(propriedade);
        }



    }
}
