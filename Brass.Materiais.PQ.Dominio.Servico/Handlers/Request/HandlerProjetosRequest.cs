using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.PQ.Entities;
using Flunt.Notifications;

namespace Brass.Materiais.PQ.Dominio.Servico.Handlers.Request
{
    public class HandlerProjetosRequest : Notifiable, IHandlerCommand<CriaProjetosRequest, Projeto>
    {
        public IComandoResult<Projeto> Handle(CriaProjetosRequest command)
        {

            //Validação rápida para velocidade
            command.Validate();


            if (command.Invalid)
            {
                return new CommandResult<Projeto>(false, "Não foi possível requisitar projetos.", null);
            }



            //var hub = command.GetProjetos("O:\\Ativos");
            var hub = command.GetProjetos(@"C:\Ativos");

            return new CommandResult<Projeto>(true, "Projetos requisitados com sucesso.", hub.Projetos);



        }


    }
}
