using Brass.Materiais.AppCatalogoPlant3d.Service;
using Brass.Materiais.AspNetCoreInjecaoDependencia;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Brass.Materiais.WindowsFormsAppNetCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Inglês";
            string pais = "USA";
            //string conexao = "name=DataBaseContext";






            var injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, "Local");

            var itensEngenhariaP3D = capturarItensEngenhariaPlant3d();
        }

        private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        {

            string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat";

            List<EngineeringItems> listaResult;

            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(string.Format("Data Source={0};Version=3;", endereco));

                listaResult = (List<EngineeringItems>)dominioService.GetAll();


            }

            return listaResult;

        }
    }
}
