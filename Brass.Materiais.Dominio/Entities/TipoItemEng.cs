using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.PQ.Entities.Montagens;

namespace Brass.Materiais.Dominio.Entities
{
    public partial class TipoItemEng: Entidade
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public virtual string Id { get; private set; }
        //public string GUID { get; set; }
        public string NOME { get; set; }

        public Atividade AtividadeVVV { get; set; }


    }
}
