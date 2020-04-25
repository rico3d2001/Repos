using Brass.Materiais.RepositorioSQLitePlant.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Fabricas
{
    public class AbstractFactory
    {

        public AbstractFactory()
        {
            BuildConnectionString();
        }


        protected void BuildConnectionString()
        {
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", @"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat");
            }
        }
    }
}
