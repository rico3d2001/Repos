using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppPQClean.CommandSide.CriarPlanilhaPQ
{
    public class CriarPlanExcelPQCommand : Notifiable, IRequest
    {
        PlanilhaPQ<LinhaVale> _planilhaVale;



        public CriarPlanExcelPQCommand(string guidPQ, string cliente, string nomeArquivo, string nomePlanilha, string disciplina)
        {
            GuidPQ = guidPQ;
            selectPlanilha(disciplina);
            Cliente = cliente;
            NomeArquivo = nomeArquivo;
            NomePlanilha = nomePlanilha;
            Disciplina = disciplina;
        }


        private void selectPlanilha(string disciplina)
        {
            switch (disciplina)
            {
                case "Tubulacao":
                    _planilhaVale = new PlanPIPEVale();
                    break;
            }
        }

        public PlanilhaPQ<LinhaVale> Planilha { get => _planilhaVale; }

        public string Cliente { get; set; }
        public string NomeArquivo { get; set; }
        public string NomePlanilha { get; set; }
        public string  Disciplina { get; set; }
        public string GuidPQ { get; set; }


    }
}
