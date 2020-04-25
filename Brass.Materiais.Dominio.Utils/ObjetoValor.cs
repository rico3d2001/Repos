using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Utils
{
    public abstract class ObjetoValor : Notifiable, IValidatable
    {
        public abstract void Validate();

    }
}
