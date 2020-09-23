using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.ValueObjects
{
    public class ArquivoOrigem:Enumeracao
    {
        public static readonly ArquivoOrigem MP3D = new ArquivoOrigem(1, "ModeloPlant3d");
        public static readonly ArquivoOrigem DP3D = new ArquivoOrigem(2, "DiagramaPlant3d");


        public ArquivoOrigem(int id, string name)
        : base(id, name)
        {
        }
    }
}
