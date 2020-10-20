using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.ServicoDominio.Fabrica;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.ServicoDominio.Services.CommandSide
{
    public class CadastroItensSomenteModelados
    {
        List<ItemModelado> _itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama;
        List<ItemModelado> _listaItensModeladosAindaNaoAnalizados;
        RepoItemPipe _repoItemPipe;
        RepoItemPQ _repositorioItemPQPlant3d;
        //Projeto _projeto;
        string _connectionString;

        public CadastroItensSomenteModelados(List<ItemModelado> itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama, string guidProjeto, string textoConexao)
        {
            _connectionString = textoConexao;
            //GuidProjeto = guidProjeto;
            RepoProjetos repoProjetos = new RepoProjetos(_connectionString);
             var projeto = repoProjetos.ObterProjeto(guidProjeto);



            _repoItemPipe = new RepoItemPipe(_connectionString);
            _repositorioItemPQPlant3d = new RepoItemPQ(_connectionString);

            _itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama = itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama;
            _listaItensModeladosAindaNaoAnalizados = new List<ItemModelado>(itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama);


        }

      

        public void CadastrarItens(NumeroAtivo ativo, string conexao)
        {

            var construtorItemPQDiagrama = new ConstrutorItemPQDiagrama(conexao);

            var itensModeladosNaoIncluidosEmItemDiagramaParaArea = _itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama
               .Where(x => x.ItemTag.NumeroAtivo.Equals(ativo)).ToList();

            foreach (var itemModelado in itensModeladosNaoIncluidosEmItemDiagramaParaArea)
            {
 
                if (ItemModeladoAindaNaoFoiAnalizado(itemModelado))
                {
                    var itemParaAnalize = _listaItensModeladosAindaNaoAnalizados.FirstOrDefault(x => x.GUID == itemModelado.GUID);

                    var itemPipe = _repoItemPipe.ObterPorDescricaoComplexa(itemParaAnalize.DescricaoLongaDimensionada, "");

                   

                    var itemPQPlant3D = construtorItemPQDiagrama.ConstruirItemPQSomenteModelado(itemParaAnalize, itemPipe); 

                    UneAoItemModeladoAquelesComDescricaoIgual(ativo, itemParaAnalize, itemPQPlant3D);

                        SalvaItemPQ(itemPQPlant3D);
                    
                }
            }
        }

        private void UneAoItemModeladoAquelesComDescricaoIgual(NumeroAtivo ativo, ItemModelado itemParaAnalize, ItemPQ itemPQPlant3D)
        {
            var itensDescricaoIgual = _listaItensModeladosAindaNaoAnalizados
              .Where(x => x.ItemTag.NumeroAtivo.Equals(ativo)
                       && x.DescricaoLongaDimensionada == itemParaAnalize.DescricaoLongaDimensionada).ToList();

            foreach (var itemDescricaoIgual in itensDescricaoIgual)
            {


                itemPQPlant3D.AdicionaItemModelado(itemDescricaoIgual);


                _listaItensModeladosAindaNaoAnalizados.Remove(itemDescricaoIgual);


            }
        }

        private bool ItemModeladoAindaNaoFoiAnalizado(ItemModelado itemModelado)
        {
            return _listaItensModeladosAindaNaoAnalizados.Exists(x => x.GUID == itemModelado.GUID) ? true : false;
        }

        private void SalvaItemPQ(ItemPQ itemPQPlant3D)
        {
            _repositorioItemPQPlant3d.InserirItem(itemPQPlant3D);
        }

        //private ItemPQ CriaItemPQ(AreaPlanejada areaPlanejada, ItemModelado itemParaAnalize)
        //{
        //    var areaTag = AreaTag.Criar(GuidProjeto, areaPlanejada, itemParaAnalize.ItemTag.AreaDesenho.Area, itemParaAnalize.ItemTag.AreaDesenho.SubArea);

        //    ItemTag itemTag =
        //        new ItemTag(GuidProjeto, areaTag, "3D", itemParaAnalize.ItemTag.TagCompleto, "");


        //    var itemPipe = _repoItemPipe.Obter(itemParaAnalize.DescricaoLongaDimensionada, "");

        //    ItemPQ itemPQPlant3D =
        //     new ItemPQ(GuidProjeto, "RRP", itemTag, itemParaAnalize.PnPID,
        //     itemParaAnalize.DescricaoLongaDimensionada, itemPipe);

        //    itemPQPlant3D.CorAvanco = "red";

        //    return itemPQPlant3D;
        //}

        


        //public Projeto projeto { get; set; }
    }
}
