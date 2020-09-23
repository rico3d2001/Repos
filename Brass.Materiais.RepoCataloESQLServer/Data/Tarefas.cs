using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class Tarefas
    {
        public int Id { get; set; }
        public bool? EstaCompleta { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset? DataConclusao { get; set; }
    }
}
