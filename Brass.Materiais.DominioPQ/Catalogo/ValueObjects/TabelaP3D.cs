using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.ValueObjects
{
    public class TabelaP3D : ObjetoValor
    {
        public string TableName { get; set; }
        public string BaseTable { get; set; }
        public string Abstract { get; set; }
        public string PhysicalName { get; set; }
        public int Revision { get; set; }
        public int SyncTimestamp { get; set; }

    }
}
