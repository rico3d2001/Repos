using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class IdentidadePQ: ObjetoValor
    {

        public IdentidadePQ()
        {
                
        }

        public IdentidadePQ(IdentidadeEstado identidadeEstado, int numeroPQ)
        {
            IdentidadeEstado = identidadeEstado;
            NumeroPQ = numeroPQ;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var argumento = obj as IdentidadePQ;

                if (this.IdentidadeEstado.Equals(argumento.IdentidadeEstado))
                {
                    return this.NumeroPQ == argumento.NumeroPQ ? true : false;
                }
                else
                {
                    return false;
                }
            }
        }


        //public IdentidadePQ(string siglaUsuario, string guidDisciplina)
        //{

        //    IdentidadeEstado = new IdentidadeEstado(siglaUsuario, guidDisciplina);
        //    NumeroPQ = -1;

        //}

        //public IdentidadePQ(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ)
        //{
        //    IdentidadeEstado = new IdentidadeEstado(guidProjeto, siglaUsuario, guidDisciplina);
        //    NumeroPQ = numeroPQ;
        //}

        public IdentidadeEstado IdentidadeEstado { get; set; }


        public int NumeroPQ { get; set; }
    }
}
