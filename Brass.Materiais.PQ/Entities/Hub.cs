using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Entities
{
    public class Hub : Entidade
    {
        List<Projeto> _projetos;

        public Hub()
        {
            _projetos = new List<Projeto>();
        }

        public List<Projeto> Projetos { get => _projetos; }

        public void AdicionaProjeto(string nome)
        {
            var projeto = new Projeto(nome);

            if (projeto.NomeProjeto.Valid)
            {
                _projetos.Add(projeto);
            }

        }


        public Projeto this[int index]
        {
            get { return _projetos[index]; }
        }

        public int QtdProjetos
        {
            get { return _projetos.Count; }
        }





    }
}
