using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class ModelPipeSQL
    {
        public static List<Dictionary<object, object>> GetItens(string database)
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(database))
            {

              
                string qry = $"SELECT * FROM[{database}].[dbo].[PnPDrawings]";

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
