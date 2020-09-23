using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepositorioSQLitePlant.Common
{
    public class ConexaoSQLite
    {
        public static void BuildConnectionString(string endereco)
        {
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", endereco);
            }
        }

        public static SQLiteConnection OpenSqlite(string filename)
        {
            string ConnString = "Data Source=" + filename + ";Version=3;";

            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection(ConnString);
            m_dbConnection.Open();
            return m_dbConnection;
        }
    }
}
