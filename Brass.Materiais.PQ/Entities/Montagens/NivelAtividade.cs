using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Entities.Montagens
{
    public class NivelAtividade:Entidade
    {
        public NivelAtividade(string gUID_CLIENTE, Versao versao, int oredenador, string nome)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            Versao = versao;
            Oredenador = oredenador;
            Nome = nome;
        }

        public string GUID_CLIENTE { get; set; }
        public Versao Versao { get; set; }
        public int Oredenador { get; set; }
        public string Nome { get; set; }
       
    }
}
