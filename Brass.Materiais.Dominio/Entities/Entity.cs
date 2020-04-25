using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class Entity
    {
        public Entity()
        {
            GUID = Guid.NewGuid().ToString();
        }

        public string GUID { get; private set; }
    }
}
