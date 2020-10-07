using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp
{
    public class AddAreaEstadoAppCommand : Notifiable, IRequest
    {
        public AddAreaEstadoAppCommand(string area, string subArea, string ativo, IdentidadeEstado identidadeEstado, string conectionString)
        {
            TextoConexao = conectionString;
            IdentidadeEstado = identidadeEstado;
            Area = area;
            SubArea = subArea;
            Ativo = ativo;
        }

        public IdentidadeEstado IdentidadeEstado { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Ativo { get; set; }
        public string TextoConexao { get; set; }
    }
}
