using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObterFamilias
{
    public class ObterItensFamiliaQueryHandler : Notifiable, IHandlerCommand<ObterItensFamiliaQuery, DimensaoFamilia>
    {
        BaseMDBRepositorio<Familia> _familiasRepositorio;

        public ObterItensFamiliaQueryHandler(BaseMDBRepositorio<Familia> familiasRepositorio) 
        {

            _familiasRepositorio = familiasRepositorio;
        }

        public IComandoResult<DimensaoFamilia> Handle(ObterItensFamiliaQuery query)
        {

            var dimensoes = query.ObtemItensFamilia();

            return new CommandResult<DimensaoFamilia>(true, "Familias requisitados com sucesso.", dimensoes);

        }
    }
}
