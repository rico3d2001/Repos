using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using SQLiteWithCSharp.Utility;
using Unity;
using Unity.Lifetime;

namespace Brass.Materiais.InjecaoDependencia
{
    public class DIContainer
    {
        private IUnityContainer _appContainer;

        private static DIContainer _instance = null;

        private DIContainer()
        {
            _appContainer = new UnityContainer();

            //ItemEngenhariaP3D
            _appContainer.RegisterType<DominioService<EngineeringItems>>(new ContainerControlledLifetimeManager());
            _appContainer.RegisterType<IRepoSQLiteService<EngineeringItems>,RepositorioService<EngineeringItems>>();

            //ItemEngenhariaP3D
            _appContainer.RegisterType<DominioService<PnPTables>>(new ContainerControlledLifetimeManager());
            _appContainer.RegisterType<IRepoSQLiteService<PnPTables>, RepositorioService<PnPTables>>();




        }

        public static DIContainer Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new DIContainer();
                }

                return _instance;
            }
        }

        public IUnityContainer AppContainer { get => _appContainer; }

    }
}
