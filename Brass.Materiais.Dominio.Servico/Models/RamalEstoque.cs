using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Models
{
    public class RamalEstoque
    {

        public RamalEstoque(string nome, string ident, string ident_pai, int nivel)
        {
            name = nome;
            guid = ident;
            guid_pai = ident_pai;
            children = new List<RamalEstoque>();
            level = nivel;

        }

        public void Adiciona(RamalEstoque ramal)
        {
            children.Add(ramal);
        }


        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; private set; }
        public string name { get; set; }
        public string guid { get; set; }
        public string guid_pai { get; set; }
        public int level { get; set; }
        public List<RamalEstoque> children { get; set; }

    }
}
