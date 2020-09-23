using AutoMapper;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.Dominio.Servico.Service
{
    public class CriaItensEngPlant3d
    {
       
        private EngineeringItemsService _engineeringItemsService;
        private IMapper _mapper;


        public CriaItensEngPlant3d(string endereco)
        {
            _engineeringItemsService = new EngineeringItemsService();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EngineeringItems, ItemEngenhariaP3D>());

            //teste
            //config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();

            ConexaoSQLite.BuildConnectionString(endereco);

            _engineeringItemsService = new EngineeringItemsService();
        }

        public List<ItemEngenhariaP3D> ObtemPlant3dData()
        {
             var engineeringItems = _engineeringItemsService.GetAll().ToList();
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
