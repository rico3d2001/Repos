using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.ServicoDominio.Fabrica;
using System.Collections.Generic;

namespace Brass.Materiais.ServicoDominio.Services.CommandSide
{
    public class ColecaoItensDiagrama
    {

         RepoItemDiagramasPlant3d _repoItemPQ;
        RepoLinhas _repoLinhas;
     
        Projeto _projeto;
        string _dataBaseProjeto;
        

        public ColecaoItensDiagrama(string guidProjeto, string conexao)
        {
            _repoLinhas = new RepoLinhas(conexao);

            RepoProjetos repoProjetos = new RepoProjetos(conexao);
            
            _projeto = repoProjetos.ObterProjeto(guidProjeto);
            _repoItemPQ = new RepoItemDiagramasPlant3d(conexao);
           


        }

     


       


        public void ColetarItensDiagrama(NumeroAtivo ativo, string conexao)
        {
            //var collection = LinhasPipeSQL.GetItensArea(_dataBaseProjeto, ativo.AreaTag.Area + ativo.AreaTag.SubArea + ativo.Sigla);

            List<Linha> linhas = _repoLinhas.ObterDoNumeroAtivo(ativo);

            var construtorItemPQDiagrama = new ConstrutorItemPQDiagrama(conexao);

            foreach (var linha in linhas)
            {
               

                if (itemPQNaoEstaCadastradoNestaArea(linha))
                {
                    //string specPart = item["Spec Part"] == null ? "" : item["Spec Part"].ToString();



                    if(linha.Descricao != "")
                    {
                        //string tag = item["Tag"].ToString();
                        //string pnPID = item["PnPID"] == null ? "" : item["PnPID"].ToString();



                        var itemPipe = linha.Descricao == "" ? null : new RepoItemPipe(conexao).ObterPorDescricaoComplexa(linha.Descricao, "");

                        

                         var itemPQ = construtorItemPQDiagrama.ConstruirItemPQDoDiagrama(itemPipe, linha);

                        _repoItemPQ.InserirItemDiagramaPlant3d(itemPQ);
                    }
                   




                }

            }
        }

       

      

        private bool itemPQNaoEstaCadastradoNestaArea(Linha linha)
        {
            //var itemPQ = _repoItemPQ.ObterItemPQ(ativo.AreaTag.Area, ativo.AreaTag.SubArea, ativo.Sigla, item["Spec Part"].ToString());
            var itemPQ = _repoItemPQ.ObterItemPQ(linha.NumeroAtivo.AreaTag.Area, linha.NumeroAtivo.AreaTag.SubArea, linha.NumeroAtivo.Sigla, linha.Descricao);
            return itemPQ == null;
        }

        



    }
}
