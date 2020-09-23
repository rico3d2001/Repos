using Brass.Materiais.AppCatalogoPlant3d.Service;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Flunt.Notifications;
using MediatR;
using SQLiteWithCSharp.Utility;
using System.Collections.Generic;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Tubulacao
{
    public class CarregaCatalogoCompletoTubulacaoCommand : Notifiable, IRequest
    {
        public CarregaCatalogoCompletoTubulacaoCommand(string endereco, string idioma, string pais, string conexao, string guidDisciplina)
        {
            Endereco = endereco;
            Idioma = idioma;
            Pais = pais;
            Conexao = conexao;
            GuidDisciplina = guidDisciplina;
            ConexaoSQLite.BuildConnectionString(endereco);
            EngineeringItems = capturarItensEngenhariaPlant3d();
        }

        public string Endereco { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }
        public string Conexao { get; set; }
        public string GuidDisciplina { get; set; }
        public List<EngineeringItems> EngineeringItems { get; private set; }

        private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        {


            List<EngineeringItems> listaResult;

            var repoSQLiteService = new RepositorioService<EngineeringItems>();
            var dominioService = new DominioService<EngineeringItems>(repoSQLiteService);


            dominioService.Start(Storage.ConnectionString);

            listaResult = (List<EngineeringItems>)dominioService.GetAll();

            dominioService.Dispose();


            return listaResult;

        }

        

    }
}
