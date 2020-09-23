using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.CriarPlanilhaPQ
{
    public class CriarPlanExcelPQCommandHandle : Notifiable, IRequestHandler<CriarPlanExcelPQCommand>
    {

        BaseMDBRepositorio<DataPQ> _repoPQPipeVale;


        public CriarPlanExcelPQCommandHandle()
        {
            _repoPQPipeVale = new BaseMDBRepositorio<DataPQ>("BIM_TESTE", "PQPipeVale");
        }

        public async Task<Unit> Handle(CriarPlanExcelPQCommand command, CancellationToken cancellationToken)
        {
    
            //var pq = _repoPQPipeVale.Obter(command.GuidPQ);

            //criaListaLinhas(command.Planilha, pq);

            //var escritoArquivo = new EscritorArquivo<LinhaVale>(new PadraoPlanilhaPQVale(command.Planilha));

            //escritoArquivo.Escrever(command.NomeArquivo, command.NomePlanilha);



            return Unit.Value;
        }

        public void criaListaLinhas(PlanilhaPQ<LinhaVale> planilha, DataPQ dataPQ) //List<ItemPQPlant3d> itens, PlanilhaPQ<LinhaVale> planilha)
        {
            
            foreach (var linha in dataPQ.ListaDataPQ)
            {
               
                LinhaVale linhaValeItem = new LinhaVale(16777215);
                if (linha.TT == "00")
                {
                    linhaValeItem = new LinhaVale(39423);
                }
                else if (linha.UU == "00")
                {
                    linhaValeItem = new LinhaVale(52479);
                }
                else if (linha.VVV == "000")
                {
                    linhaValeItem = new LinhaVale(9299711);
                }
                else if (linha.WWW == "000")
                {
                    linhaValeItem = new LinhaVale(10092543);
                }


                linhaValeItem.PrencheCelula(CelulaVale.Item, linha.Item);

                linhaValeItem.PrencheCelula(CelulaVale.Area, linha.Area);
                linhaValeItem.PrencheCelula(CelulaVale.SubArea, linha.SubArea);

                linhaValeItem.PrencheCelula(CelulaVale.K, linha.K);
                linhaValeItem.PrencheCelula(CelulaVale.TT, linha.TT);
                linhaValeItem.PrencheCelula(CelulaVale.UU,linha.UU);
                linhaValeItem.PrencheCelula(CelulaVale.VVV, linha.VVV);
                linhaValeItem.PrencheCelula(CelulaVale.WWW,linha.WWW);
                linhaValeItem.PrencheCelula(CelulaVale.DescricaoAtividade, linha.DescricaoAtividade);

                linhaValeItem.PrencheCelula(CelulaVale.Unidade, linha.Unidade);
                linhaValeItem.PrencheCelula(CelulaVale.CMS, linha.CMS);

                linhaValeItem.PrencheCelula(CelulaVale.CM_K, linha.CM_K);
                linhaValeItem.PrencheCelula(CelulaVale.CM_TT, linha.CM_TT);
                linhaValeItem.PrencheCelula(CelulaVale.CM_UU, linha.CM_UU);

                linhaValeItem.PrencheCelula(CelulaVale.Sequencial, linha.Sequencial);

                linhaValeItem.PrencheCelula(CelulaVale.Quantidade, linha.Quantidade);

                linhaValeItem.PrencheCelula(CelulaVale.ProvisaoEng, linha.ProvisaoEng);



                planilha.AddLinha(linhaValeItem);

            }


        }






    }
}
