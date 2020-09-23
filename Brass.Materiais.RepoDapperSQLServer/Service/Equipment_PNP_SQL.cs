using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class Equipment_PNP_SQL
    {
        public static List<Dictionary<object, object>> GetAllEquipment_PNP(string database, string conexao)
        {

            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(conexao))
            {

                string qry = $"SELECT * FROM [_{database.ToLower()}_Piping].[dbo].[Equipment_PNP]";

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
