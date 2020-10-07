using Brass.Materiais.AppPQClean.ViewModel;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterArvoreAtividades
{
    public class ObterArvoreAtividadesQuery : IRequest<RamalArvoreAtividade>
    {
        public ObterArvoreAtividadesQuery(string guidProjeto, string guidDisciplina, string conectionString)
        {
            GuidProjeto = guidProjeto;
            GuidDisciplina = guidDisciplina; 
            TextoConexao = conectionString;
        }

        public string GuidProjeto { get; set; }
        public string GuidDisciplina { get; set; }
        public string TextoConexao { get; set; }

    }
}
