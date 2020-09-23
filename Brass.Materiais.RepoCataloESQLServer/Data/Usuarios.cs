using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
