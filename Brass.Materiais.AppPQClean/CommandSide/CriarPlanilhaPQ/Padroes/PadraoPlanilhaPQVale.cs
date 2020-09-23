namespace Brass.Materiais.AppPQClean.CommandSide.CriarPlanilhaPQ.Padroes
{
    public class PadraoPlanilhaPQVale //: EscritorPlanilha<LinhaVale>, IEscritoraPlanilha
    {

        bool _negrito = false;

        //public PadraoPlanilhaPQVale(PlanilhaPQ<LinhaVale> planilhaVale) : base(planilhaVale)
        //{
            
        //    _numeroLinha = 11;
        //}

        

        //protected override void EscreverPorLinha(LinhaVale linha, Celula celula)
        //{
        //    //if (_numeroLinha >= 11 && _numeroLinha <= 13)
        //    //{
        //            Preencher(linha, celula);
        //            //UsaLinha(linha, celula);
        //    //}

        //}

        //private void Preencher(LinhaVale linha, Celula celula)
        //{
        //    var comprimentoItem = 0;

        //    foreach (var cel in linha.Celulas)
        //    {
                

        //        if (cel.TipoCelulaPQ.Name == "Item")
        //        {
        //            comprimentoItem = cel.ValorCelula.Length;
        //        }
 
        //        if (comprimentoItem <= 3)
        //        {
        //            celula.FormataTexto(_numeroLinha, cel.TipoCelulaPQ.Id, cel.Fonte, cel.AlturaTexto, true);
        //        }
        //        else if (comprimentoItem > 3 && comprimentoItem <= 7)
        //        {
        //            if(cel.TipoCelulaPQ.Name == "DescricaoAtividade")
        //            {
        //                celula.FormataTexto(_numeroLinha, cel.TipoCelulaPQ.Id, cel.Fonte, cel.AlturaTexto, true);
        //            }
        //            else
        //            {
        //                celula.FormataTexto(_numeroLinha, cel.TipoCelulaPQ.Id, cel.Fonte, cel.AlturaTexto, false);
        //            }
        //        }
        //        else
        //        {
        //            celula.FormataTexto(_numeroLinha, cel.TipoCelulaPQ.Id, cel.Fonte, cel.AlturaTexto, false);
        //        }
               

        //        celula.FormatoConteudo(_numeroLinha, cel.TipoCelulaPQ.Id, cel.FormatoConteudo);
        //        celula.SetValor(_numeroLinha, cel.TipoCelulaPQ.Id, cel.ValorCelula);
        //        celula.SetCor(_numeroLinha, cel.TipoCelulaPQ.Id, linha.CorLinha);
        //        celula.AlinhamentoHorizontal(_numeroLinha, cel.TipoCelulaPQ.Id, cel.AlinhamentoHorizontal);
        //        celula.AlinhamentoVertical(_numeroLinha, cel.TipoCelulaPQ.Id, cel.AlinhamentoVertical);
        //        celula.EnvolveTexto(_numeroLinha, cel.TipoCelulaPQ.Id, cel.EnvolveTexto);
        //        celula.BordaAoRedor(_numeroLinha, cel.TipoCelulaPQ.Id);
        //    }
        //}

        //public void UsaLinha(LinhaVale linha, Celula celula)
        //{
        //    if(linha.LinhasFilhas.Count > 0)
        //    {
        //        foreach (var lin in linha.LinhasFilhas)
        //        {
        //            _numeroLinha++;
        //            Preencher(lin, celula);
        //            UsaLinha(lin, celula);
        //        }

               
        //    }
        //}

    //    protected override void PreencherCabecalho(LinhaVale item, Celula celula)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    }
}
