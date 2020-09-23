using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppNetCoreUtil
{
    public class Response
    {
        public Response(object data, bool hasError = false)
        {
            this.Data = data;
            this.HasError = hasError;
        }

        public bool HasError { get; set; }
        public object Data { get; set; }
    }
}
