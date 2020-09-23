using Brass.Materiais.Dominio.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class Area : Entidade
    {
        protected string _pasta;
        

        public Area(string pasta, string tipo, string numeroArea, string numeroSubArea, string nomeArea)
        {
            _pasta = pasta;
            var nmArea = pasta.Split('\\').Last();
            NomeArea = nmArea;
            Tipo = tipo;
            NumeroArea = numeroArea;
            NumeroSubArea = numeroSubArea;
            NomeArea = nomeArea;
            //AreaSuperior = areaSuperior;
            children = new List<Area>();
        }


        public string NumeroSubArea { get; private set; }
        public string NumeroArea { get; private set; }
        //public string Pasta { get; private set; }
        public string NomeArea { get; private set; }
        //public Area AreaSuperior { get; private set; }
        public List<Area> children { get; private set; }

        public string Tipo { get; set; }

        public void AdicionaArea(Area area)
        {
            //if (area.NomeArea.Valid)
            //{
                children.Add(area);
            //}


        }

       


        public string GetPasta()
        {
            return _pasta;
        }


    }
}

