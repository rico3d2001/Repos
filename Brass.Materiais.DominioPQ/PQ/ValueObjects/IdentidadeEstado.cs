using Brass.Materiais.DominioPQ.BIM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class IdentidadeEstado
    {


        public string GuidProjeto { get; set; }
        public string SiglaUsuario { get; set; }
        public string GuidDisciplina { get; set; }
        public string GuidCliente { get; set; }
        public string GuidIdioma { get; set; }


        public IdentidadeEstado()
        {

        }
       

        public IdentidadeEstado(Projeto projeto, string siglaUsuario, string guidDisciplina)
        {
          
            GuidProjeto = projeto == null ? "" : projeto.GUID;
            SiglaUsuario = siglaUsuario;
            GuidDisciplina = guidDisciplina;
            GuidCliente = projeto == null ? "" : projeto.GUID_CLIENTE;
            GuidIdioma = projeto == null ? "" : projeto.GUID_IDIOMA;
        }

       


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
