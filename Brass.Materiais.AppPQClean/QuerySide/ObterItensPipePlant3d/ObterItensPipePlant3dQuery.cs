using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItensPipePlant3d
{
    public class ObterItensPipePlant3dQuery : IRequest<ItemPQ[]> 
    {
        public ObterItensPipePlant3dQuery(string guidProjeto, string area, string subArea, string ativo, int pagina, int limite, string conectionString)
        {

            TextoConexao = conectionString;

            GuidProjeto = guidProjeto;
 
            Area = area;
            SubArea = subArea;
            Ativo = ativo;
            Pagina = pagina;
            Limite = limite;

          
        }

        public string TextoConexao { get; set; }
        public string GuidProjeto { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Ativo { get; set; }

        public int Pagina { get; set; }
        public int Limite { get; set; }

        
    }
}
