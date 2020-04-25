using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCarregaItensEstoque
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            worker.WorkerReportsProgress = true;

            e.Result = progressoeTransferencia((int)e.Argument, worker, e);

            //e.Result = progressoSincronizacao((int)e.Argument, worker, e);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private long progressoeTransferencia(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            PropriedadesItemService propriedadesItemService = new PropriedadesItemService();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            ItemEngenhariaService itemEngenhariaService = new ItemEngenhariaService();

            int mult = 70000 / 100;

            var catalogos = itemEngenhariaService.ObterCatalogos();

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
                foreach (var catalogo in catalogos)
                {
                    var categorias = itemEngenhariaService.ObterCategorias(catalogo.GUID);

                    foreach (var categoria in categorias)
                    {
                        var tipos = itemEngenhariaService.ObterTiposItem(catalogo.GUID, categoria.GUID);

                        foreach (var tipo in tipos)
                        {
                            //itemEngenhariaEstoqueService.CarregaItensPorTipoItem(catalogo.GUID, categoria.GUID, tipo.GUID);
                            List<ItemTubulacaoEstoque> tubulacaoEstoques = new List<ItemTubulacaoEstoque>();

                            var ids = propriedadesItemService.ObterPropriedadesID(catalogo.GUID, categoria.GUID, tipo.GUID);

                            //foreach (var id in ids)
                            for (int i = 1; i <= ids.Count() - 1; i++)
                            {

                                ItemTubulacaoEstoque itemTubulacaoEstoque = new ItemTubulacaoEstoque(ids[i].PnPID, ids[i].GUID_CATALOG, ids[i].GUID, categoria.GUID, tipo.GUID);

                                var props = propriedadesItemService.ObterPropriedadesItemDTO(ids[i], categoria.GUID, tipo.GUID);

                                foreach (var prop in props)
                                {

                                    foreach (var item in props)
                                    {
                                        string valor = item.VALOR_PROPRIEDADE.Replace('"', '¨');
                                        itemTubulacaoEstoque.GetType().GetProperty(item.PROPRIEDADE).SetValue(itemTubulacaoEstoque, valor);
                                    }


                                }

                                itemEngenhariaEstoqueService.InserirItem(itemTubulacaoEstoque);


                                var local = i / mult;
                                result = Convert.ToInt64(local);
                                worker.ReportProgress(local);


                            }
                        }
                    }
                }
            }

            return result;
        }

        private void btnCargaTabelaItens_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(10);
        }
    }
}
