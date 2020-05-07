using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.Dominio.Entities
{
    public partial class TipoItemEng: Entidade
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public virtual string Id { get; private set; }
        //public string GUID { get; set; }
        public string NOME { get; set; }
    }
}
