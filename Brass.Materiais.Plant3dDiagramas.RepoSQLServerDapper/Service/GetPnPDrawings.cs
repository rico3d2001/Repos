using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Plant3dDiagramas.RepoSQLServerDapper.Service
{
    public class GetPnPDrawings
    {
        public static List<Dictionary<object, object>> GetItens(string siglaProjeto, string tipo)
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();


            //_bdb190101_PnId
            var database = "";

            switch (tipo)
            {
                case "Volumetrica":
                    database = "_" + siglaProjeto.ToLower() + "_Piping";
                    break;
                case "Processo":
                    database = "_" + siglaProjeto.ToLower() + "_PnId";
                    break;
            }
        

            using (var conexaoBD = new Conexao(database))
            {

                //string campoReturn = "Area";
                string qry =
                $"SELECT * FROM[{database}].[dbo].[PnPDrawings]";



                //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                //SQLiteDataReader rdr = command.ExecuteReader();

                var reader = conexaoBD.SQLServerConexao.Query(qry).ToList();

                foreach (var rdr in reader)
                {
                    var dic = new Dictionary<object, object>();
                    foreach (var item in rdr)
                    {
                        dic.Add(item.Key, item.Value);
                    }

                    //
                    //var teste = rdr.Read();
                    //while (rdr.Read())
                    //{
                    //    //linhas.Add(rdr["Area"].ToString());
                    //    dic.Add("Area", rdr["Area"].ToString());

                    //}



                    lista.Add(dic);
                }


            }

            return lista;
        }
    }
}
