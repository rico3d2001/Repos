using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class ProjetosSQL
    {
        // SELECT name, database_id, create_date FROM sys.databases

        public static List<Dictionary<object, object>> GetProjetos()
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(""))
            {

                string qry = $"SELECT name, database_id, create_date FROM sys.databases";

                var reader = conexaoBD.SQLServerConexao.Query(qry).ToList();

                foreach (var rdr in reader)
                {
                    var dic = new Dictionary<object, object>();
                    foreach (var item in rdr)
                    {
                        dic.Add(item.Key, item.Value);
                    }

                    lista.Add(dic);
                }


            }

            return lista;
        }



        public static List<Dictionary<object, object>> GetTabelaProjeto(string database)
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(database))
            {
                string qry = $"SELECT * FROM[{database}].[dbo].[PnPProject]";
                

                var reader = conexaoBD.SQLServerConexao.Query(qry).ToList();

                foreach (var rdr in reader)
                {
                    var dic = new Dictionary<object, object>();
                    foreach (var item in rdr)
                    {
                        dic.Add(item.Key, item.Value);
                    }

                    lista.Add(dic);
                }


            }

            return lista;
        }


    }
}
