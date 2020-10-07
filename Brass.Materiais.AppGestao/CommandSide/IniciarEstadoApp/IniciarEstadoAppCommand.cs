using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppGestao.CommandSide.IniciarEstadoApp
{
    public class IniciarEstadoAppCommand : Notifiable, IRequest
    {
        public IniciarEstadoAppCommand(IdentidadeEstado identidadeEstado, string conectionString)
        {
            TextoConexao = conectionString;
            IdentidadeEstado = new IdentidadeEstado(null, identidadeEstado.SiglaUsuario, identidadeEstado.GuidDisciplina);
        }

        public IdentidadeEstado IdentidadeEstado { get; set; }
        public string TextoConexao { get; set; }


    }
}
