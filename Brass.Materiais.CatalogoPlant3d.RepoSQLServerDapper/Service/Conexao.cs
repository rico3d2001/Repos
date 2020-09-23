using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Plant3dDiagramas.RepoSQLServerDapper.Service
{
    class Conexao : IDisposable
    {
        private SqlConnection _conection;


        private string _dataBase;

        public Conexao(string dataBase)
        {
            _dataBase = dataBase;

            //__CATALOGO_BRASS
        }



        public IDbConnection SQLServerConexao
        {
            get
            {
                if (_conection == null)
                {
                    string conectionString = $"data source=192.168.20.240;initial catalog={_dataBase};"
                        + "persist security info=True;"
                        + "user id = BrassDataBase; password = brass2019; MultipleActiveResultSets = True;";
                    //string conectionString = "Server=tcp:rico3d.database.windows.net,1433;"
                    //    + "Initial Catalog=CatalogoBRASS;Persist Security Info=False;"
                    //    + "User ID=rico3d;Password=PqpTnc@16;"
                    //    + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    _conection = new SqlConnection(conectionString);
                    _conection.Open();
                }
                else if (_conection.State == ConnectionState.Closed)
                {
                    _conection.Open();
                }

                return _conection;

            }

            //get { return _instancia ?? (_instancia = new Conexao()); }
        }

        public void Dispose()
        {
            _conection.Close();
        }
    }
    
    
}
