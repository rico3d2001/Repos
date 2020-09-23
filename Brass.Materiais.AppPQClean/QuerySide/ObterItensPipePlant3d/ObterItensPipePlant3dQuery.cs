using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItensPipePlant3d
{
    public class ObterItensPipePlant3dQuery : IRequest<ItemPQ[]> 
    {
        public ObterItensPipePlant3dQuery(string guidProjeto, string siglaUsuario, string area, string subArea)
        {
            GuidProjeto = guidProjeto;
            SiglaUsuario = siglaUsuario;
            Area = area;
            SubArea = subArea;
        }

        public string GuidProjeto { get; set; }
        public string SiglaUsuario { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
    }
}
