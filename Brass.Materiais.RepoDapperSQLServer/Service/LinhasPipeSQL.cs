using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class LinhasPipeSQL
    {
        public static List<string> GetLinhas(string arquivoCAD, string database)
        {
            List<string> linhas = new List<string>();

            string valorQuery = ConvertToRelativePath(arquivoCAD);

            using (var conexaoBD = new Conexao(database))
            {
               
                string campoReturn = "Tag";
                string qry =
                "select lg.Tag from P3dDrawingLineGroupRelationship_PNP dlgr " +
                "inner join PnPDrawings_PNP dr on dr.PnPID = dlgr.Drawing " +
                "inner join P3dLineGroup_PNP lg on lg.PnPID = dlgr.LineGroup " +
                "where dr.PnPRelativePath = '" + valorQuery + "'";  // + "' and lg.Tag is not null";



                //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                //SQLiteDataReader rdr = command.ExecuteReader();

                var rdrs = conexaoBD.SQLServerConexao.Query(qry).ToList();

                foreach (var rdr in rdrs)
                {
                    linhas.Add(rdr[campoReturn].ToString());
                }

                //while (rdr.Read())
                //{
                   // linhas.Add(rdr[campoReturn].ToString());

                //}
            }

            return linhas;
        }


        
        public static List<Dictionary<object, object>> GetItens(string database) //string arquivoCAD, string database)
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(database))
            {

                string qry =
                "SELECT PnPDrawings.Area, PnPDrawings.[Dwg Name], PnPDrawings.Path, PipeLines.PnPID, PipeLines.[Spec Part], PipeLines.Tag"
                + " FROM PnPDrawings INNER JOIN PipeLines ON PnPDrawings.Area = PipeLines.AREA";

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

        public static List<Dictionary<object, object>> GetLinhasProjeto(string database)
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(database))
            {

                var qryContemTabela = $"select name from {database}.sys.tables where name like '%PipeLines%'";

                var readerContemTabela = conexaoBD.SQLServerConexao.Query(qryContemTabela).ToList();

                if(readerContemTabela.Count > 0)
                {
                    string qry = $"SELECT [PnPID],[Spec Part],[Tag] FROM[{database}].[dbo].[PipeLines]";

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

                


            }

            return lista;
        }

        public static List<Dictionary<object, object>> GetItensArea(string database,string area) 
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(database))
            {

                //string qry = $"SELECT [AREA],[PnPID],[Spec Part],[Tag] FROM[{database}].[dbo].[PipeLines] WHERE [AREA] = '{area}'";
                //string qry = $"SELECT[AREA],[PnPID],[Spec Part],[Tag] FROM[{database}].[dbo].[PipeLines] WHERE[Tag] LIKE '%{area}%'";
                string qry = $"SELECT [PnPID],[Spec Part],[Tag] FROM[{database}].[dbo].[PipeLines] WHERE[Tag] LIKE '%{area}%'";

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


        private static string ConvertToRelativePath(string arquivoCAD)
        {
            string[] palavras = arquivoCAD.Split('\\');
            int intStart = 0;
            string relativePath = "";
            for (int i = 0; i < palavras.Length; i++)
            {
                if ("Plant 3D Models" == palavras[i])
                    intStart = i;

                if (i == intStart)
                {
                    relativePath = palavras[i];
                }
                if (i > intStart)
                {
                    relativePath = relativePath + "\\" + palavras[i];
                }
            }

            return relativePath;
        }
    }
}
