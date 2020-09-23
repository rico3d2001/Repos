using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using System.Collections.Generic;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class Hub : Entidade
    {
       



        public Hub(Usuario usuario)
        {
            Usuario = usuario;
            Projetos = new List<Projeto>();
        }

        public List<Projeto> Projetos { get; set; }

        public void AdicionaProjeto(Projeto projeto)
        {
            //var projeto = new Projeto();

            //if (projeto.NomeProjeto.Valid)
            //{
            Projetos.Add(projeto);
            //}

        }

        public Usuario Usuario { get; set; }


        public Projeto this[int index]
        {
            get { return Projetos[index]; }
        }

        public int QtdProjetos
        {
            get { return Projetos.Count; }
        }





    }
}
