using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.RepoIO
{
    public interface IRequestIO
    {
        List<string> GetPastas(string raiz);
    }
}
