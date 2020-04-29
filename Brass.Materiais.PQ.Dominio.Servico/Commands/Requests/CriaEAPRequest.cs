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
    public class CriaEAPRequest : Notifiable, IComando
    {

        readonly IRequestIO _repositorioIO;
        public CriaEAPRequest(IRequestIO repositorioIO)
        {
            _repositorioIO = repositorioIO;
        }
        public EAP GetEAP(string raiz)
        {
            var eap = new EAP();


            var pastas = _repositorioIO.GetPastas(raiz);

            foreach (var pasta in pastas)
            {
                var area = new Area(pasta);
                eap.AdicionaArea(area);
                AddArea(area);
            }


            return eap;
        }

        private void AddArea(Area area)
        {

            var lista = _repositorioIO.GetPastas(area.GetPasta());

            foreach (var pasta in lista)
            {
                var area_adicional = new Area(pasta);
                area.AdicionaArea(area_adicional);
                AddArea(area_adicional);
            }

        }



        public void Validate()
        {
            //throw new NotImplementedException();
        }
    }
}
