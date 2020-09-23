using Brass.Materiais.Dominio.Utils;
using System.Collections.Generic;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class Familia : Entidade
    {

        List<string> _idsItens;

        public Familia(string gUID_CATALOGO, string gUID_CATEGORIA, ValorTabelado valor)
        {
            GUID_CATALOGO = gUID_CATALOGO;
            GUID_CATEGORIA = gUID_CATEGORIA;
            PartFamilyLongDesc = valor;
            _idsItens = new List<string>();
        }

        public void AdicionaIdentificadorItem(string guidItem)
        {
            _idsItens.Add(guidItem);
        }


        public string GUID_CATALOGO { get; set; }
        public string GUID_CATEGORIA { get; set; }
        public ValorTabelado PartFamilyLongDesc { get; set; }
        public List<string> IdsItens { get => _idsItens; set => _idsItens = value; }

        public string PartFamilyId { get; set; }
    }
}
