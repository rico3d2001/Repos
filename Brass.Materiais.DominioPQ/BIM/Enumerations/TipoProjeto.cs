using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Enumerations
{
    public class TipoProjeto : Enumeracao
    {
        public static readonly TipoProjeto VPN_BIDIMENSIONAL = new TipoProjeto(1, "2D VPN");
        public static readonly TipoProjeto VPN_TRIDIMENSIONAL = new TipoProjeto(1, "3D VPN");
        public static readonly TipoProjeto BIM360_BIDIMENSIONAL = new TipoProjeto(1, "2D BIM 360");
        public static readonly TipoProjeto BIM360_TRIDIMENSIONAL = new TipoProjeto(1, "3D BIM 360");
        public TipoProjeto(int id, string name) : base(id, name)
        {
        }
    }
}
