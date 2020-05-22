using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;

namespace Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObtemArvoreCatalogo
{
    public class ObtemArvoreCatalogoQueryHandler : Notifiable, IHandlerCommand<ObtemArvoreCatalogoQuery, RamalArvoreCatalogo>
    {

        BaseMDBRepositorio<RamalArvoreCatalogo> _ramalEstoqueRepositorio;

        public ObtemArvoreCatalogoQueryHandler(BaseMDBRepositorio<RamalArvoreCatalogo> ramalEstoqueRepositorio) //BaseMDBRepositorio<Catalogo> catalogoRepositorio, BaseMDBRepositorio<Familia> familiasRepositorio)
        {

            _ramalEstoqueRepositorio = ramalEstoqueRepositorio;
    }

        public IComandoResult<RamalArvoreCatalogo> Handle(ObtemArvoreCatalogoQuery query)
        {

            var ramais = _ramalEstoqueRepositorio.Obter();

            return new CommandResult<RamalArvoreCatalogo>(true, "Areas requisitados com sucesso.", ramais);

        }
    }
}
