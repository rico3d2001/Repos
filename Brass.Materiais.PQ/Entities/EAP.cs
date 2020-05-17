using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Entities
{
    public class EAP : Entidade
    {
        List<Area> _areas;
        public EAP()
        {
            _areas = new List<Area>();
        }

        public List<Area> Areas { get => _areas; }

        public void AdicionaArea(Area area)
        {

            if (area.NomeArea.Valid)
            {
                _areas.Add(area);
            }

        }

      
    }
}
