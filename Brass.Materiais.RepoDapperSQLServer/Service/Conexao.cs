using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class Conexao: IDisposable
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

                    //string conectionString = $"data source=192.168.20.240;"
                    // + "persist security info=True;"
                    // + "user id = BrassDataBase; password = brass2019; MultipleActiveResultSets = True;";

                    //if (_dataBase != ""){
                    //    conectionString = $"data source=192.168.20.240;initial catalog={_dataBase};"
                    //   + "persist security info=True;"
                    //   + "user id = BrassDataBase; password = brass2019; MultipleActiveResultSets = True;";
                    //}

                    string conectionString = $"Data Source=P00940\\SQLEXPRESS;Integrated Security=True";
                    //+ "user id = BrassDataBase; password = brass2019; MultipleActiveResultSets = True;";

                    if (_dataBase != "")
                    {
                        conectionString = $"Data Source=P00940\\SQLEXPRESS;Initial Catalog={_dataBase};Integrated Security=True";
                        //+ "user id = BrassDataBase; password = brass2019; MultipleActiveResultSets = True;";
                    }



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
