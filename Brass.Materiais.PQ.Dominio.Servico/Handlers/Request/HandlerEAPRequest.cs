using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.PQ.Entities;
using Flunt.Notifications;

namespace Brass.Materiais.PQ.Dominio.Servico.Handlers.Request
{
    public class HandlerEAPRequest : Notifiable, IHandlerCommand<CriaEAPRequest, Area>
    {

        //O:\Ativos\BdB1922_NEXA_BONSUCESSO\3D\PLANT3D\BdB1922\Plant 3D Models
        public IComandoResult<Area> Handle(CriaEAPRequest command)
        {
            //Validação rápida para velocidade
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult<Area>(false, "Não foi possível requisitar areas.", null);
            }



            //var eap = command.GetEAP(@"O:\Ativos\BdB1922_NEXA_BONSUCESSO\3D\PLANT3D\BdB1922\Plant 3D Models");
            //var eap = command.GetEAP(@"\\192.168.20.239\eng\Ativos\BdB1922_NEXA_BONSUCESSO\3D\PLANT3D\BdB1922\Plant 3D Models");
            var eap = command.GetEAP(@"C:\Ativos\Bdb123-Projeto1\Plant 3D Models");

            return new CommandResult<Area>(true, "Areas requisitados com sucesso.", eap.Areas);
        }
    }
}
