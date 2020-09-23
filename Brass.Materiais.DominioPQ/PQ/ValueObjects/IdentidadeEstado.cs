using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class IdentidadeEstado
    {

        public IdentidadeEstado()
        {

        }
        public IdentidadeEstado(string siglaUsuario, string guidDisciplina)
        {
            SiglaUsuario = siglaUsuario;
            GuidDisciplina = guidDisciplina;
            GuidProjeto = "none";
        }

        public IdentidadeEstado(string guidProjeto, string siglaUsuario, string guidDisciplina)
        {
            GuidProjeto = guidProjeto;
            SiglaUsuario = siglaUsuario;
            GuidDisciplina = guidDisciplina;
        }

        public string GuidProjeto { get; set; }

        public string SiglaUsuario { get; set; }
        public string GuidDisciplina { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var argumento = obj as IdentidadeEstado;
                if(this.GuidProjeto == argumento.GuidProjeto 
                    && this.SiglaUsuario == argumento.SiglaUsuario 
                    && this.GuidDisciplina == argumento.GuidDisciplina)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
