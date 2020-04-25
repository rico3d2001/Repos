using Brass.Materiais.Dominio.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brass.Materiais.WindowsForms
{
    public partial class FormMateriais : Form
    {
        public FormMateriais()
        {
            InitializeComponent();
        }

        private void btnCarregarTabela_Click(object sender, EventArgs e)
        {
            string baseURL = "https://localhost:44320/";
            string api = "api/ItensEng";
            var hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;

            List<ItemEngenhariaP3D> lista = new List<ItemEngenhariaP3D>();

            using (var client = new HttpClient(hndlr))
            {
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetAsync(api);

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var str = readTask.Result;

                    lista = JsonConvert.DeserializeObject<ItemEngenhariaP3D[]>(str).ToList();

                }


            }

            dataGridItensEng.DataSource = lista;


        }
    }
}
