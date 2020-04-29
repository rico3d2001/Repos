using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Service.Utils
{
    public interface IHandler<T, U> where T : IComando
    {
        IComandoResult<U> Handle(T command);
    }
}
