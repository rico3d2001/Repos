using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Coleta
{
    public class Coletado:Entidade
    {

        

        public Coletado(string guidProjeto, BaseComponentesPlant componentesPlant)
        {
            GuidProjeto = guidProjeto;
            //Versao = versao;
            ComponentePlant = componentesPlant;
        }

        public BaseComponentesPlant ComponentePlant { get; set; }
        public string GuidProjeto { get; set; }
        //public Versao Versao { get; set; }
    }
}
