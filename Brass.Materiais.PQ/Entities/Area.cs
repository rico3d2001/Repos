using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.PQ.ObjetosValor.Nomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Entities
{
    public class Area : Entidade
    {
        string _pasta;


        public Area(string pasta)
        {
            _pasta = pasta;
            var nmArea = pasta.Split('\\').Last();
            NomeArea = new NomeArea(nmArea);

            
            //AreaSuperior = areaSuperior;
            children = new List<Area>();
        }

        //public string Pasta { get; private set; }
        public NomeArea NomeArea { get; private set; }
        //public Area AreaSuperior { get; private set; }
        public List<Area> children { get; private set; }

        public void AdicionaArea(Area area)
        {
            if (area.NomeArea.Valid)
            {
                children.Add(area);
            }


        }

        public string GetPasta()
        {
            return _pasta;
        }

      
    }
}
