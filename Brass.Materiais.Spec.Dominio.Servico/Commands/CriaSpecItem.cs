using AutoMapper;
using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using Brass.Materiais.RepositorioSQLitePlant.Service.Spec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Spec.Dominio.Servico.Commands
{
    public class CriaSpecItem
    {
        SpecEngineeringItens _specEngineeringItens;
        private IMapper _mapper;

        public CriaSpecItem(string endereco)
        {
            _specEngineeringItens = new SpecEngineeringItens();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EngineeringItems, ItemEngenhariaP3D>());

            //teste
            //config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();

            ConexaoSQLite.BuildConnectionString(endereco);

            //_engineeringItemsService = new EngineeringItemsService();
        }

        public List<ItemEngenhariaP3D> ObtemPlant3dData()
        {
            var engineeringItems = _specEngineeringItens.GetAll().ToList();
            return _mapper.Map<List<ItemEngenhariaP3D>>(engineeringItems);
        }

        public void BuildConnectionString()
        {
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", @"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat");
            }
        }

    }
}
