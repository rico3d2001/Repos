using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360
{
    public class CadastroItensSomenteModeladosBIM360
    {
        List<ItemModelado> _itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama;
        List<ItemModelado> _listaItensModeladosAindaNaoAnalizados;
        RepoItemPipe _repoItemPipe;
        RepoItemPQ _repositorioItemPQPlant3d;


        public CadastroItensSomenteModeladosBIM360(List<ItemModelado> itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama, string guidProjeto)
        {

            GuidProjeto = guidProjeto;



            _repoItemPipe = new RepoItemPipe();
            _repositorioItemPQPlant3d = new RepoItemPQ();

            _itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama = itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama;
            _listaItensModeladosAindaNaoAnalizados = new List<ItemModelado>(itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama);


        }



        public void CadastrarItens(AreaPlanejada areaPlanejada)
        {



            var itensModeladosNaoIncluidosEmItemDiagramaParaArea = _itensModeladosDeTodoProjetoNaoIncluidosEmItemDiagrama
               .Where(x => x.ItemTag.AreaDesenho.Area == areaPlanejada.Area && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea).ToList();

            foreach (var itemModelado in itensModeladosNaoIncluidosEmItemDiagramaParaArea)
            {

                if (ItemModeladoAindaNaoFoiAnalizado(itemModelado))
                {
                    var itemParaAnalize = _listaItensModeladosAindaNaoAnalizados.FirstOrDefault(x => x.GUID == itemModelado.GUID);

                    var itemPipe = _repoItemPipe.ObterPorDescricaoComplexa(itemParaAnalize.DescricaoLongaDimensionada, "");
                    //if(itemPipe != null)
                    //{
                    var itemPQPlant3D = ItemPQ.CriaItemPQSomenteModelado(areaPlanejada, itemParaAnalize, itemPipe);

                    UneAoItemModeladoAquelesComDescricaoIgual(areaPlanejada, itemParaAnalize, itemPQPlant3D);

                    SalvaItemPQ(itemPQPlant3D);
                    //}
                    //else
                    //{
                    //throw new Exception("Item somente modelado não possui cadastro");
                    //}

                }
            }
        }

        private void UneAoItemModeladoAquelesComDescricaoIgual(AreaPlanejada areaPlanejada, ItemModelado itemParaAnalize, ItemPQ itemPQPlant3D)
        {
            var itensDescricaoIgual = _listaItensModeladosAindaNaoAnalizados
              .Where(x =>
              (x.ItemTag.AreaDesenho.Area == areaPlanejada.Area && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea) &&
              x.DescricaoLongaDimensionada == itemParaAnalize.DescricaoLongaDimensionada).ToList();

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




        public string GuidProjeto { get; set; }
    }
}
