using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.GestaoCatalogo.Service;
using Brass.Materiais.InjecaoDependencia;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace WinAlimentaBanco
{
    public partial class Form1 : Form
    {
        private string _conectionString;
        private string _endereco;
        private string _idioma;
        private string _pais;
        private List<EngineeringItems> _itensEngenhariaP3D;
        private InjetaItemCompleto _injetaPropriedade;

        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);

       
        }

        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                resultLabel.Text = "Canceled";
            }
            else
            {
                resultLabel.Text = e.Result.ToString();
            }
        }

       

        private void CmboxBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selecionado = CmboxBanco.SelectedItem.ToString();
            switch (selecionado)
            {
                case "Local":
                    _conectionString = "name=DataBaseContext";
                    break;
                case "Azure":
                    _conectionString = "Azure";
                    break;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            worker.WorkerReportsProgress = true;

            e.Result = progressoInsercao((int)e.Argument, worker, e);

            //e.Result = progressoSincronizacao((int)e.Argument, worker, e);

        }

     

        private long progressoSincronizacao(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {

            string nomeCatalogo = _endereco.Split('\\').Last().Split('.').First();
            _injetaPropriedade = new InjetaItemCompleto(_endereco, _idioma, _pais, _conectionString);

            if (_itensEngenhariaP3D == null)
            {
                _itensEngenhariaP3D = capturarItensEngenhariaPlant3d();
            }



            int mult = _itensEngenhariaP3D.Count() / 100;

            if ((n <= 0))
            {
                throw new ArgumentException(
                    "value must be >= 0 and <= 91", "n");
            }

            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
               


                for (int i = 0; i <= _itensEngenhariaP3D.Count(); i++)
                {
                    //if (_itensEngenhariaP3D[i].GUID_ITEM == null)
                    //{
                    //    using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
                    //    {
                    //        dominioService.Start(string.Format("Data Source={0};Version=3;", _endereco));

                    //        string guidItem = _injetaPropriedade.PegaItemEngenhariaBanco(nomeCatalogo, _itensEngenhariaP3D[i].PnPID).GUID;

                    //        _itensEngenhariaP3D[i].GUID_ITEM = guidItem;

                    //        //resultLabel.Text = _itensEngenhariaP3D[i].PnPID.ToString();

                    //        dominioService.Update(_itensEngenhariaP3D[i]);

                            


                    //    }
                    //}

                    var local = i / mult;
                    result = Convert.ToInt64(local);
                    worker.ReportProgress(local);



                }








            }

            return result;

           





            






        }

        private long progressoInsercao(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {





            int mult = _itensEngenhariaP3D.Count() / 100;

            if ((n <= 0))
            {
                throw new ArgumentException(
                    "value must be >= 0 and <= 91", "n");
            }

            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                for (int i = 1; i <= _itensEngenhariaP3D.Count() - 1; i++)
                {
                    _injetaPropriedade.InjetarUnitario(_itensEngenhariaP3D[i]);
                    var resto = i % mult;
                    if (resto == 0)
                    {

                        var local = i / mult;
                        result = Convert.ToInt64(local);
                        worker.ReportProgress(local);
                    }

                }
            }

            return result;
        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

      

        private void btnInserirDados_Click(object sender, EventArgs e)
        {
            _injetaPropriedade = new InjetaItemCompleto(_endereco, _idioma, _pais, _conectionString);
            _itensEngenhariaP3D = capturarItensEngenhariaPlant3d();

            backgroundWorker1.RunWorkerAsync(10);


            //string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string idioma = "Inglês";
            //string pais = "USA";
            //string conexao = "name=DataBaseContext"



            //if (!(string.IsNullOrEmpty(_endereco) || string.IsNullOrEmpty(_idioma) || string.IsNullOrEmpty(_pais)))
            //{

            //    if (backgroundWorker1.IsBusy != true)
            //    {
            //        // Start the asynchronous operation.
            //        backgroundWorker1.RunWorkerAsync();
            //    }


            //    //InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(_endereco, _idioma, _pais, _conectionString);
            //    //injetaPropriedade.Injetar(backgroundWorker1);
            //}


        }

        private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        {


            List<EngineeringItems> listaResult;

            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(string.Format("Data Source={0};Version=3;", _endereco));

                listaResult = (List<EngineeringItems>)dominioService.GetAll();


            }

            return listaResult;

        }

        private void btnPegaCatalogo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtBoxCatalogo.Text = openFileDialog1.FileName;


                _endereco = txtBoxCatalogo.Text;


            }

        }

        private void cmboxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            _idioma = cmboxIdioma.SelectedItem.ToString();
        }

        private void cmboxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pais = cmboxPais.SelectedItem.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            _conectionString = "Local";//"name=DataBaseContext";
            //_endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat";
            //txtBoxCatalogo.Text = _endereco;
            _idioma = "Inglês";
            _pais = "USA";

            CmboxBanco.SelectedText = "Local";
            cmboxIdioma.SelectedText = _idioma;
            cmboxPais.SelectedText = _pais;

            ConexaoSQLite.BuildConnectionString(_endereco);

        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.backgroundWorker1.CancelAsync();

            // Disable the Cancel button.
            btnParar.Enabled = false;
        }

        private void btnUpdateSQLite_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(10);
            //string nomeCatalogo = _endereco.Split('\\').Last().Split('.').First();
            //_injetaPropriedade = new InjetaItemCompleto(_endereco, _idioma, _pais, _conectionString);

            //if (_itensEngenhariaP3D == null)
            //{
            //    _itensEngenhariaP3D = capturarItensEngenhariaPlant3d();
            //}





            //foreach (var item in _itensEngenhariaP3D)
            //{
            //    if (item.PnPID > 16434)
            //    {
            //        using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            //        {
            //            dominioService.Start(string.Format("Data Source={0};Version=3;", _endereco));

            //            string guidItem = _injetaPropriedade.PegaItemEngenhariaBanco(nomeCatalogo, item.PnPID).GUID;

            //            item.GUID_ITEM = guidItem;

            //            resultLabel.Text = item.PnPID.ToString();

            //            dominioService.Update(item);


            //        }
            //    }



            //}






        }
    }
}
