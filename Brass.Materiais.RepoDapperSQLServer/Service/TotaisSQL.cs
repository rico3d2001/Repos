using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class TotaisSQL
    {
        public static List<Dictionary<object, object>> GetTabela(string database, string tabela)
        {
            List<Dictionary<object, object>> lista = new List<Dictionary<object, object>>();

            using (var conexaoBD = new Conexao(database))
            {


                string qry = $"SELECT * FROM[{database}].[dbo].[{tabela}]";

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

        public static void GetViewPipe(string database, string guidProjeto)
        {

            //var listaColetasDoProjeto = _coletadosPipeRepositorio.Encontrar(Builders<Coletados>.Filter.Eq(x => x.GuidProjeto, guidProjeto));

            //if(listaColetasDoProjeto.Count > 0)
            //{
            //    var ultima = listaColetasDoProjeto.Last();
            //    Versao version = new Versao(ultima.Versao.Numero, ultima.Versao.Origem, "Atualização", DateTime.Now);
            //    _coleta = new Coletados(guidProjeto, version);
            //}
            //else
            //{

            //    Versao versao = new Versao(0, "Plant3d", "Incio do Projeto", DateTime.Now);
            //    _coleta = new Coletados(guidProjeto, versao);

            //}

            //_coletadosPipeRepositorio.Inserir(_coleta);



            RepoColetadosPipe repoColetadosPipe = new RepoColetadosPipe();

            List<string> excessoes = new List<string> { "Port_PNP","P3dConnector_PNP", "P3dLineGroup_PNP",
                "P3dPartConnection_PNP", "P3dDrawingLineGroupRelationship_PNP", "PnPTagRegistry_PNP", "PnPBase_PNP",
                "PnPTagRegistries_PNP", "PnPDrawings_PNP", "PnPTagEnlistedColumns_PNP", "PnPProjectCategories_PNP",
                "PnPProject_PNP", "PnPDrawingCategories_PNP","PnPPicklists_PNP","PnPPicklistValues_PNP","PnPProjectVariables_PNP",
                "PnPTagFormat_PNP","EngineeringItems_PNP","ColorSettings_PNP",
                "Equipment_PNP",
                "LayerColorGlobalSettings_PNP","LayerColorSchemeAssignment_PNP","PipeRunComponent_PNP","Support_PNP",
                "PnPWorkHistory_PNP","AssetOwnership_PNP","PnPDataLinks_PNP","PartPort_PNP",
                "SteelStructure_PNP","StructureMember_PNP","StructureRailing_PNP","StructureStair_PNP","BoltSet_PNP",
                "StructureLadder_PNP","P3dLineGroupPartRelationship_PNP","Buttweld_PNP","Thread_PNP"
            };

            var propriedadesBlanc = ExtraiPropriedadesBlanc();

            var propriedadesUnidade = ExtraiPropriedadesUnidade();



            //Pipe_PNP classeTeste = new Pipe_PNP();



            //var view = tipo + "_PNP";

            //List<Dictionary<string, string>> lista = new List<Dictionary<string, string>>();

            //List<BaseComponentesPlant> lista = new List<BaseComponentesPlant>();
            //List<Coletados> listaColetados = new List<Coletados>();
            

            Versao versao = new Versao(0, "Plant3d", "Incio do Projeto", DateTime.Now);

            using (var conexaoBD = new Conexao(database))
            {
                var qryContemTabela = $"select name from {database}.sys.views";  //where name like '%{view}%'";



                var views = conexaoBD.SQLServerConexao.Query(qryContemTabela).ToList();

                //if (readerContemTabela.Count > 0)
                foreach (var view in views)
                {
                    foreach (var itemView in view)
                    {
                        var nome = itemView.Value.ToString();

                        if (!(excessoes.Contains(nome)))
                        {
                           
                            string qry = $"SELECT * FROM[{database}].[dbo].[{nome}]";

                            var reader = conexaoBD.SQLServerConexao.Query(qry).ToList();

                            foreach (var rdr in reader)
                            {
                                //var classe = Activator.CreateInstance(tipo);
                                if (nome == "Pipe_PNP")
                                {
                                    var coletado = new Coletados(guidProjeto, versao, DefineBlanc(rdr, propriedadesBlanc));
                                   repoColetadosPipe.CadastrarColetado(coletado);
                                }
                                else
                                {
                                    var coletado = new Coletados(guidProjeto, versao, DefineUnidadePipe(rdr, propriedadesUnidade));
                                    repoColetadosPipe.CadastrarColetado(coletado);
                                }

                                    

                            }
                        }
                    }
                }



            }

            //var coletados = repoColetadosPipe.ObterUltimaColeta(guidProjeto);

            //return coletados;
        }

        private static List<string> ExtraiPropriedadesBlanc()
        {
            var propriedades = new List<string>();

            foreach (PropertyInfo prp in typeof(BlancPipe).GetProperties())
            {
                propriedades.Add(prp.Name);
            }

            return propriedades;
        }

        private static List<string> ExtraiPropriedadesUnidade()
        {
            var propriedades = new List<string>();

            foreach (PropertyInfo prp in typeof(UnidadePipe).GetProperties())
            {
                propriedades.Add(prp.Name);
            }

            return propriedades;
        }

        private static UnidadePipe DefineUnidadePipe(dynamic rdr, List<string> propriedades)
        {
            var classe = new UnidadePipe();




            foreach (var item in rdr)
            {
                if (propriedades.Contains(item.Key.ToString()))
                {
                    SetaValor(classe, item.Key.ToString(), item.Value);
                }

            }


            return classe;
        }

        private static BlancPipe DefineBlanc(dynamic rdr, List<string> propriedades)
        {
            var classe = new BlancPipe();

            


            foreach (var item in rdr)
            {
                if (propriedades.Contains(item.Key.ToString()))
                {
                    SetaValor(classe, item.Key.ToString(), item.Value);
                }

            }


            return classe;
        }

        private static void SetaValor(Object obj, string propriedade, Object valor)
        {

            PropertyInfo prop = obj.GetType().GetProperty(propriedade, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, valor, null);
            }

        }

        public static List<Dictionary<string, string>> GetView(string database, string tabela)
        {

            var view = tabela + "_PNP";

            List<Dictionary<string, string>> lista = new List<Dictionary<string, string>>();






            using (var conexaoBD = new Conexao(database))
            {
                var qryContemTabela = $"select name from {database}.sys.views where name like '%{view}%'";

                var readerContemTabela = conexaoBD.SQLServerConexao.Query(qryContemTabela).ToList();

                if (readerContemTabela.Count > 0)
                {

                    string qry = $"SELECT * FROM[{database}].[dbo].[{view}]";

                    var reader = conexaoBD.SQLServerConexao.Query(qry).ToList();

                    foreach (var rdr in reader)
                    {
                        var dic = new Dictionary<string, string>();
                        foreach (var item in rdr)
                        {
                            dic.Add(item.Key.ToString(), item.Value.ToString());
                        }


                        lista.Add(dic);
                    }
                }



            }

            return lista;
        }
    }
}
