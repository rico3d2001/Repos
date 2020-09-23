using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.InjecaoDependencia;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using System.Collections.Generic;
using System.Data.SQLite;
using Unity;

namespace Brass.Materiais.SQLitePlant3dDapper.Service
{
    public class TotaisSQLite
    {

        public void Teste()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string conexao = "name=DataBaseContext";

            //ConexaoSQLite.BuildConnectionString(endereco);

          

       
            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<PnPTables>>())
            {
                dominioService.Start(Storage.ConnectionString);

                var tabelasx = dominioService.GetAll();
            }

         
        }



        public static List<Dictionary<object, object>> GetTabela(string database, string tabela)
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            //using (var conexaoBD = new ConexaoSQLiteDapper(database))
            //{


            //    //string qry = $"SELECT * FROM[{database}].[dbo].[{tabela}]";
            //    string qry = $"SELECT * FROM {tabela}";

            //    var reader = conexaoBD.SQLiteConexao.Query(qry).ToList();

            //    foreach (var rdr in reader)
            //    {
            //        var dic = new Dictionary<object, object>();
            //        foreach (var item in rdr)
            //        {
            //            dic.Add(item.Key, item.Value);
            //        }


            //        lista.Add(dic);
            //    }


            //}

            return lista;
        }



        public static List<Dictionary<object, object>> GetView(string database, string tabela)
        {



            string end = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string conexao = "name=DataBaseContext";

            ConexaoSQLite.BuildConnectionString(end);




            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<PnPTables>>())
            {
                dominioService.Start(Storage.ConnectionString);

                var tabelasx = dominioService.GetAll();
            }



            var view = tabela + "_PNP";

            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();






           // using (var conexaoBD = new ConexaoSQLiteDapper(database))
            //{
                // var qryContemTabela = $"select name from {database}.sys.views where name like '%{view}%'";
                //string qryContemTabela = $"SELECT * FROM {view}";

                //var readerContemTabela = conexaoBD.SQLiteConexao.Query(qryContemTabela).ToList();

                //if (readerContemTabela.Count > 0)
                //{

                //string qry = $"SELECT * FROM[{database}].[dbo].[{view}]";
                string qry = $"SELECT * FROM {view}";

                string conectionString = string.Format("Data Source={0};Version=3;", database);
            string endereco = @"Data Source=C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat;Version=3;";
            var conection = new SQLiteConnection(endereco);

                //var reader = conexaoBD.SQLiteConexao.Query(qry).ToList();

                //    foreach (var rdr in reader)
                //    {
                //        var dic = new Dictionary<object, object>();
                //        foreach (var item in rdr)
                //        {
                //            dic.Add(item.Key, item.Value);
                //        }


                //        lista.Add(dic);
                //    }
                //}



           // }

            return lista;
        }
    }
}
