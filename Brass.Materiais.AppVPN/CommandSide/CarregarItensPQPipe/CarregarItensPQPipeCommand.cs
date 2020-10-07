using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoDapperSQLServer.Service;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.ServicoDominio.Services.CommandSide;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public class CarregarItensPQPipeCommand : Notifiable, IRequest
    {
        
        public IdentidadeEstado IdentidadeEstado { get; set; }
        public string DataBaseProjetoPiping { get; set; }
        public string DataBaseProjetoPnId { get; set; }
        public string TextoConexao { get; set; }

        public List<Coletado> Coletados { get; set; }

        public CarregarItensPQPipeCommand(IdentidadeEstado identidadeEstado, string conectionString)//string dataBaseProjeto, string guidProjeto)
        {
            TextoConexao = conectionString;

            RepoProjetos repoProjetos = new RepoProjetos(conectionString);

            var projeto = repoProjetos.ObterProjeto(identidadeEstado.GuidProjeto);

            IdentidadeEstado = identidadeEstado;

            DataBaseProjetoPnId = $"_{projeto.Sigla.ToLower()}_PnId";
            DataBaseProjetoPiping = $"_{projeto.Sigla.ToLower()}_Piping";

            var repoColetadosPipe = new RepoColetadosPipe(conectionString);

           
  
            if (repoColetadosPipe.NaoHouveColetaAinda(IdentidadeEstado.GuidProjeto))
            {
            TotaisSQL.GetViewPipe(DataBaseProjetoPiping, IdentidadeEstado.GuidProjeto, conectionString);
            LinhasPipeSQL.ColetaLinhasProjeto(DataBaseProjetoPnId, IdentidadeEstado.GuidProjeto, conectionString);
            }








        }





    }
}
