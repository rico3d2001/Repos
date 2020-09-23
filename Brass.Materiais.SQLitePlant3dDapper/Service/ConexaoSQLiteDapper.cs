using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.SQLitePlant3dDapper.Service
{
    public class ConexaoSQLiteDapper //: IDisposable
    {
        private SQLiteConnection _conection;


        private string _filename;
       

        public ConexaoSQLiteDapper(string filename)
        {
            _filename = filename;
    
            //__CATALOGO_BRASS
        }



        public IDbConnection SQLiteConexao
        {
            get
            {
                if (_conection == null)
                {
                    string conectionString = string.Format("Data Source={0};Version=3;", _filename);
                    _conection = new SQLiteConnection(conectionString);
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

        //public void Dispose()
        //{
        //    _conection.Close();
        //}
    }
}
