using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class DiametrosPipeSQL
    {
        public static string GetMinimumDiameter(String filename, string pnpid,string database)
        {
            string minDia = String.Empty;

           

            using (var conexaoBD = new Conexao(database))
            {

                string qry = @"select MIN(port2.NominalDiameter) from Port_PNP port2
                                            inner join PartPort_PNP papo2 on papo2.Port = port2.PnPID
                                            where papo2.Part = " + pnpid;

             
                var readerBranchsize = conexaoBD.SQLServerConexao.Query(qry).ToList();


                if (readerBranchsize[0].GetType() != typeof(DBNull))
                {
                    minDia = readerBranchsize[0].ToString();
                }

            }

            return minDia;
        }
    }
}
