using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Service.Utils
{
    public interface IComandoResult<T>
    {

        List<T> Result { get; set; }
        bool Sucess { get; set; }
        string Message { get; set; }



    }
}
