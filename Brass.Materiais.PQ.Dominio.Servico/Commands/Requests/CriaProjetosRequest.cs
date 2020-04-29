using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Entities;
using Brass.Materiais.PQ.RepoIO;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Dominio.Servico.Commands.Requests
{
    public class CriaProjetosRequest : Notifiable, IComando
    {

        readonly IRequestIO _repositorioIO;
        public CriaProjetosRequest(IRequestIO repositorioIO)
        {
            _repositorioIO = repositorioIO;
        }

        public Hub GetProjetos(string hubVPN)
        {
            var lista = _repositorioIO.GetPastas(hubVPN);

            var hub = new Hub();

            foreach (var nm in lista)
            {
                var nmProj = nm.Split('\\').Last();
                hub.AdicionaProjeto(nmProj);
            }

            return hub;
        }


        public void Validate()
        {
            //throw new NotImplementedException();
        }
    }
}
