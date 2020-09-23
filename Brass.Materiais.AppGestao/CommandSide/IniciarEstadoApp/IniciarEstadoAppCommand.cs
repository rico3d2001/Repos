using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppGestao.CommandSide.IniciarEstadoApp
{
    public class IniciarEstadoAppCommand : Notifiable, IRequest
    {
        public IniciarEstadoAppCommand(IdentidadeEstado identidadeEstado)
        {
            IdentidadeEstado = new IdentidadeEstado(identidadeEstado.SiglaUsuario, identidadeEstado.GuidDisciplina);
        }

        public IdentidadeEstado IdentidadeEstado { get; set; }
        
    }
}
