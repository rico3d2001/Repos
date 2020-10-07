using Brass.Materiais.AppCatalogoP3D.ViewModel;
using MediatR;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterFamiliaParaAdicao
{
    public class ObterFamiliaParaAdicaoQuery : IRequest<ItemParaAdicionar[]>
    {
        public ObterFamiliaParaAdicaoQuery(string guidFamilia, string conectionString)
        {
            TextoConexao = conectionString;
            GuidFamilia = guidFamilia;
        }

        public string GuidFamilia { get; set; }
        public string TextoConexao { get; set; }
    }
}
