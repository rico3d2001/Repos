using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepositorioSQLitePlant.Service
{
    public class EngineeringItemsService : RepositorioService<EngineeringItems>
    {


        public EngineeringItemsService() : base(Storage.ConnectionString)
        {

        }

        // you can write extended methods here
    }
}
