using Brass.Materiais.Dominio.Servico.Fabricas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.UnitTest
{
    [TestClass]
    public class UnitTestTubos
    {

        [TestMethod]
        public void MontagemCodigoBrass_Montar_Acertivo()
        {
            //string SIGLA_PECA = "TUB";
            //string SIGLA_MATERIAL = "053";
            //string SIGLA_ESPESSURA = "005";
            //string SIGLA_FAB = "SC";
            //string SIGLA_EXT = "PL";
            //string SIGLA_REVEST = "a";
            //string SIGLA_DIAMETRO = "P102";

            //DataBaseContext dataBaseContext = new DataBaseContext();

            var montagemCodigo = new MontagemItemEngenharia();



            //CodigoEspecificacao codigo = montagemCodigo.MontarItem(SIGLA_PECA, SIGLA_MATERIAL, SIGLA_FAB, SIGLA_EXT, SIGLA_REVEST, SIGLA_ESPESSURA, SIGLA_DIAMETRO);

            //Assert.AreEqual(codigo.Obter(SIGLA_DIAMETRO).DimensaoMilimetro, 21.3);

        }


        [TestMethod]
        public void MontagemItemTubo_Montar_Acertivo()
        {
            //string PECA = "TUB";
            //string MATERIAL = "053";
            //string SCH = "005";
            //string FAB = "SC";
            //string EXT = "PL";
            //string REVEST = "SR";
            //double ESP = 1.65;
            //double ØEXT = 21.3;
            //string DN = "1/2";
            //double PESO = 0.8;
            //string DIMENSOES = "ASME B36.10";

            //MontagemItemTubo montagemItemTubo = new MontagemItemTubo();

            //montagemItemTubo.Montar(PECA, MATERIAL, SCH, FAB, EXT, REVEST, ESP, ØEXT, DN, PESO, DIMENSOES);

        }
    }
}
