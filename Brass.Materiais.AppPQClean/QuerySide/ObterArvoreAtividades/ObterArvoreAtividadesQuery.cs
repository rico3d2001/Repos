using Brass.Materiais.AppPQClean.ViewModel;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterArvoreAtividades
{
    public class ObterArvoreAtividadesQuery : IRequest<RamalArvoreAtividade>
    {
        public ObterArvoreAtividadesQuery(string guidProjeto, string guidDisciplina)
        {
            GuidProjeto = guidProjeto;
            GuidDisciplina = guidDisciplina;
        }

        public string GuidProjeto { get; set; }
        public string GuidDisciplina { get; set; }


    }
}
