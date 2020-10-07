using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Enumerations
{
    public class TipoAtivo : Enumeracao
    {
        public static readonly TipoAtivo TUBULACAO = new TipoAtivo(1, "YY-01");
        public static readonly TipoAtivo ELETRICOS = new TipoAtivo(2, "YY-02");
        public static readonly TipoAtivo INSTRUMENTACAO = new TipoAtivo(3, "YY-03");
        public static readonly TipoAtivo CALDEIRARIA = new TipoAtivo(4, "YY-04");
        public static readonly TipoAtivo ESTRUTURAS_METALICAS = new TipoAtivo(5, "YY-05");
        public static readonly TipoAtivo EQUIPAMENTOS = new TipoAtivo(6, "EQP");
        public static readonly TipoAtivo INDEFINIDO = new TipoAtivo(7, "");
        public TipoAtivo(int id, string name) : base(id, name)
        {
        }

        public static TipoAtivo ObterDoComponente(BaseComponentesPlant baseComponentesPlant)
        {
            
            switch (baseComponentesPlant.IndicadorAtivo)
            {
                case 1:
                    return TipoAtivo.TUBULACAO;
                case 2:
                    return TipoAtivo.ELETRICOS;
                case 3:
                    return TipoAtivo.INSTRUMENTACAO;
                case 4:
                    return TipoAtivo.CALDEIRARIA;
                case 5:
                    return TipoAtivo.ESTRUTURAS_METALICAS;
                case 6:
                    return TipoAtivo.EQUIPAMENTOS;

            }

            return TipoAtivo.INDEFINIDO;
        }

        public static TipoAtivo ObterDaSigla(string sigla)
        {
            switch (sigla)
            {
                case "YY-01":
                    return TipoAtivo.TUBULACAO;
                case "YY-02":
                    return TipoAtivo.ELETRICOS;
                case "YY-03":
                    return TipoAtivo.INSTRUMENTACAO;
                case "YY-04":
                    return TipoAtivo.CALDEIRARIA;
                case "YY-05":
                    return TipoAtivo.ESTRUTURAS_METALICAS;
                case "EQP":
                    return TipoAtivo.EQUIPAMENTOS;

            }

            return TipoAtivo.INDEFINIDO;
        }

        public static TipoAtivo ObterDoTag(string tagCompleto)
        {
            var parteReferenciaAtivo = tagCompleto.Split('-').First();

            if (parteReferenciaAtivo.Length == 6 && parteReferenciaAtivo != "000000")
            {

                switch (parteReferenciaAtivo.Substring(4, 2))
                {
                    case "PI":
                        return TipoAtivo.TUBULACAO;
                }
            }

            return TipoAtivo.INDEFINIDO; 
        }


    }
}
