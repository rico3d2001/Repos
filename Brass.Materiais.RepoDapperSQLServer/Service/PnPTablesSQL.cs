using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class PnPTablesSQL
    {
        public static List<Dictionary<object, object>> GetAllPnPTables()
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(""))
            {

                string qry = $"SELECT * FROM[_bdb1922_Piping].[dbo].[PnPTables]";

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
