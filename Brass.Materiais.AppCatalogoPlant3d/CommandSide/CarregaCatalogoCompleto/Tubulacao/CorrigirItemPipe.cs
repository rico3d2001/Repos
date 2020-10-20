using Brass.Materiais.AppCatalogoPlant3d.Service;
using Brass.Materiais.Nucleo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Brass.Materiais.ServicoDominio.Fabrica;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Tubulacao
{
    public class CorrigirItemPipe
    {


        public static void Fazer(string conexao, string guidDisciplina, string endereco, string lingua, string pais)
        {

            ConexaoSQLite.BuildConnectionString(endereco);

            var repoSQLiteService = new RepositorioService<EngineeringItems>();
            var dominioService = new DominioService<EngineeringItems>(repoSQLiteService);

            dominioService.Start(Storage.ConnectionString);

            var engineeringItems = (List<EngineeringItems>)dominioService.GetAll();

            dominioService.Dispose();


            RepoDisciplinas repoDisciplinas = new RepoDisciplinas(conexao);
            Disciplina disciplina = repoDisciplinas.ObterPorGuid(guidDisciplina);

            var construtorCatalogo = new ConstrutorCatalogo(
                endereco.Split('\\').Last().Split('.').First(),
                lingua,
                pais,
                disciplina,
                conexao);

            //construtorCatalogo.IncluirDiametroNominal(engineeringItems);

            construtorCatalogo.IncluirPeso(engineeringItems);

        }

       
    }
}
