using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.PQ.ObjetosValor.Nomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Entities
{
    public class Projeto : Entidade
    {

        public Projeto(string nome)
        {


            NomeProjeto = new NomeProjeto(nome);

            //AddNotifications(NomeProjeto);
        }

        public EAP EAP { get; set; }

        public NomeProjeto NomeProjeto { get; private set; }
    }
}
