using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterEAP
{
    public class ObterEAPQuery : IRequest<EAP>
    {
        public ObterEAPQuery(string guidProjeto, string banco, string collection, string conectionString) //string tipo, string banco, string collection)
        {
            GuidProjeto = guidProjeto;
            //Tipo = tipo;
            Banco = banco;
            Collection = collection;
            TextoConexao = conectionString;
        }

        public string TextoConexao { get; set; }
        public string Banco { get; set; }
        public string Collection { get; set; }

        public string GuidProjeto { get; set; }

       
        //public string Tipo { get; set; }
    }
}
