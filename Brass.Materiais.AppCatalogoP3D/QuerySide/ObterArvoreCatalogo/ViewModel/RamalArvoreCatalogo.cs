using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo.ViewModel
{
    public class RamalArvoreCatalogo
    {
        public RamalArvoreCatalogo(string nome, string ident, string ident_pai, int nivel)
        {
            name = nome;
            guid = ident;
            guid_pai = ident_pai;
            children = new List<RamalArvoreCatalogo>();
            level = nivel;

        }

        public void Adiciona(RamalArvoreCatalogo ramal)
        {
            children.Add(ramal);
        }


        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; private set; }
        public string name { get; set; }
        public string guid { get; set; }
        public string guid_pai { get; set; }
        public int level { get; set; }
        public List<RamalArvoreCatalogo> children { get; set; }
    }
}
