using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class LinhaVale: LinhaPQ
    {
        public List<CelulaPQ> Celulas { get; set; }

        public LinhaVale(int cor)
        {
            CorLinha = cor;
            Celulas = new List<CelulaPQ>()
            {
                new CelulaPQ(CelulaVale.Item,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.Area,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.SubArea,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.NumeroAtivo,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.K,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.TT,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.UU,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.VVV,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.WWW,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.DescricaoAtividade,"","Texto",true,"Esquerda","Centro","Arial",10),
                new CelulaPQ(CelulaVale.Unidade,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.CMS,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.CM_K,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.CM_TT,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.CM_UU,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.Sequencial,"","Texto",false,"Direita","Centro","Arial",10),
                new CelulaPQ(CelulaVale.Quantidade,"","Texto",false,"Direita","Centro","Arial",10),
                new CelulaPQ(CelulaVale.ProvisaoEng,"","Texto",false,"Direita","Centro","Arial",10),
                new CelulaPQ(CelulaVale.NCM_TEC,"","Texto",false,"Centro","Centro","Arial",10),
                new CelulaPQ(CelulaVale.PrecoUnitario,"","Texto",false,"Direita","Centro","Arial",10),
                new CelulaPQ(CelulaVale.PrecoTotal,"","Texto",false,"Direita","Centro","Arial",10)

            };

            LinhasFilhas = new List<LinhaVale>();
        }

        public void PrencheCelula(CelulaVale tipoCelulaPQVale, string valor)
        {
            var celula = Celulas.First(x => x.TipoCelulaPQ == tipoCelulaPQVale);
            celula.ValorCelula = valor;
        }

        public int CorLinha { get; set; }

        public List<LinhaVale> LinhasFilhas { get; private set; }


        public LinhaVale LinhaOrigem { get; set; }


        public void AddLinha(LinhaVale linha)
        {
            LinhasFilhas.Add(linha);
        }

    }



}

