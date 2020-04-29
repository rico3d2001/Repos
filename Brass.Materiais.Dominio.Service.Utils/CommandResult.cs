using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Service.Utils
{
    public class CommandResult<T> : IComandoResult<T>
    {


        public CommandResult()
        {

        }

        public CommandResult(bool sucess, string message, List<T> result)
        {
            Result = result == null ? new List<T>() : result;
            Sucess = sucess;
            Message = message;
        }

        public virtual bool Sucess { get; set; }
        public virtual string Message { get; set; }
        public virtual List<T> Result { get; set; }
    }
}
