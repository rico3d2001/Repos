using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaValoresTabelasDoArquivoCatalogo.Mecanica
{
    public class CarregaValoresTabeladosMecanicaCommandHandle : Notifiable, IRequestHandler<CarregaValoresTabeladosMecanicaCommand>
    {
        public Task<Unit> Handle(CarregaValoresTabeladosMecanicaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
