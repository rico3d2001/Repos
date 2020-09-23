using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.ViewModel
{

   

    public class RamalArvoreAtividade
    {
        public RamalArvoreAtividade(string nome, string ident, string ident_pai, int nivel, string codigo)
        {
            name = nome;
            guid = ident;
            guid_pai = ident_pai;
            children = new List<RamalArvoreAtividade>();
            level = nivel;
            Codigo = codigo;

        }

        public void Adiciona(RamalArvoreAtividade ramal)
        {
            children.Add(ramal);
        }


        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; private set; }
        public string name { get; set; }
        public string guid { get; set; }
        public string guid_pai { get; set; }
        public int level { get; set; }
        public string Codigo { get; set; }
        public List<RamalArvoreAtividade> children { get; set; }
    }
}
