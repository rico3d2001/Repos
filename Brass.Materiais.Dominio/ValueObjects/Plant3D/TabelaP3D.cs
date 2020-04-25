using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Plant3D
{
    public class TabelaP3D: ValueObject
    {
        public string TableName { get; set; }
        public string BaseTable { get; set; }
        public string Abstract { get; set; }
        public string PhysicalName { get; set; }
        public int Revision { get; set; }
        public int SyncTimestamp { get; set; }

    }
}
