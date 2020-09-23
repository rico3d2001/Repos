using AutoMapper;
using Brass.Materiais.DominioPQ.Catalogo.ValueObjects;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;

namespace Brass.Materiais.Dominio.Servico.Service
{
    public class TabelasPlant3dServices
    {
        private PnPTablesService _pnpTablesService;
        private IMapper _mapper;

        public TabelasPlant3dServices(string endereco)
        {
            _pnpTablesService = new PnPTablesService();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PnPTables, TabelaP3D>());

            //teste
            //config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();

            ConexaoSQLite.BuildConnectionString(endereco);

            _pnpTablesService = new PnPTablesService();
        }
    }
}
