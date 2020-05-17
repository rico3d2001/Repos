using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class RecuperaClientesRequest : Notifiable, IComando
    {

     

       

        

        public void Validate()
        {
            //throw new NotImplementedException();
        }
    }
}

