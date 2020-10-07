﻿using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaValoresTabelasDoArquivoCatalogo.Tubulacao
{
    public class CarregaValoresTabeladosTubulacaoCommand : Notifiable, IRequest
    {

        OrganizaCatalogoTubulacaoSQLiteMongoDB _organizaCatalogoSQLiteMongoDB;

        public CarregaValoresTabeladosTubulacaoCommand(string endereco, string idioma, string pais, string guidDisciplina, string conexao)
        {
            Endereco = endereco;
            Idioma = idioma;
            Pais = pais;
            Conexao = conexao;
            GuidDisciplina = guidDisciplina;
            //ConexaoSQLite.BuildConnectionString(endereco);

            _organizaCatalogoSQLiteMongoDB = new OrganizaCatalogoTubulacaoSQLiteMongoDB(endereco, GuidDisciplina, conexao);

            EngineeringItems = _organizaCatalogoSQLiteMongoDB.CapturarItensEngenhariaPlant3d();
        }

        public string Endereco { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }
        public string Conexao { get; set; }
        public string GuidDisciplina { get; set; }

        public List<EngineeringItems> EngineeringItems { get; private set; }

        //private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        //{


        //    List<EngineeringItems> listaResult;

        //    var repoSQLiteService = new RepositorioService<EngineeringItems>();
        //    var dominioService = new DominioService<EngineeringItems>(repoSQLiteService);


        //    dominioService.Start(Storage.ConnectionString);

        //    listaResult = (List<EngineeringItems>)dominioService.GetAll();

        //    dominioService.Dispose();


        //    return listaResult;

        //}

    }
}