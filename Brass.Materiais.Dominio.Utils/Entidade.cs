using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Utils
{
    public class Entidade
    {

        public Entidade()
        {
            GUID = Guid.NewGuid().ToString();
        }


        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; private set; }
        public string GUID { get; set; }
        //public Guid Id { get; set; }
    }
}
