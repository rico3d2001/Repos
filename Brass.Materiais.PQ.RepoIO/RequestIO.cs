using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.RepoIO
{
    public class RequestIO : IRequestIO
    {

        public List<string> GetPastas(string pasta)
        {
            return Directory.GetDirectories(pasta).ToList();
        }

        public bool HaPastas(string pasta)
        {
            return Directory.GetDirectories(pasta).Count() == 0 ? false : true;
        }
    }
}
