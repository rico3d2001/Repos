using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class Catalogo:Entidade
    {
        public Catalogo()
        {

        }
        //[BsonRepresentation(BsonType.ObjectId)]
        //public virtual string Id { get; private set; }

        //public string GUID { get; set; }
        public string GUID_IDIOMA { get; set; }
        public string NOME { get; set; }

      
    }
}
