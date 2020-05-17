using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class Familia:Entidade
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

     


        //public override bool Equals(Object obj)
        //{

        //    return familia.PartFamilyLongDesc.VALOR == PartFamilyLongDesc.VALOR ? true : false;
        //}

        public string GUID_CATALOGO { get; set; }
        public string GUID_CATEGORIA { get; set; }
        public ValorTabelado PartFamilyLongDesc { get; set; }
        public List<string> IdsItens { get => _idsItens; set => _idsItens = value; }
    }
}
