using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360
{
    public class CadastroItensDiagramasBIM360
    {
        RepoItemPQ _repositorioItemPQPlant3d;
        RepoItemModelado _repoItemModelado;
        RepoItemDiagramasPlant3d _repoRepoItemDiagramasPlant3d;
        List<ItemPQ> _listaItensDiagrama;
        List<ItemPQ> _itensPQIncluidos;
        //List<string> _tiposDeItensConformeInicioDaDescricao;
        List<ItemModelado> _itensModeladosQueJaForamIncluidosEmItemDiagrama;
        List<ItemModelado> _listaDeItensModeladosDoProjeto;



        public CadastroItensDiagramasBIM360(string guidProjeto)
        {
            _repoItemModelado = new RepoItemModelado();

            //var listaItensDiagrama = 

            //DataBaseProjeto = dataBaseProjeto;
            //GuidProjeto = guidProjeto;

            _repositorioItemPQPlant3d = new RepoItemPQ();
            _repoRepoItemDiagramasPlant3d = new RepoItemDiagramasPlant3d();
            //_repoItemModelado = new RepoItemModelado();

            //_listaItensDiagrama = _repositorioItemPQPlant3d.ObterItensPQPorProjeto(guidProjeto);
            _listaItensDiagrama = _repoRepoItemDiagramasPlant3d.ObterItensPQPorProjeto(guidProjeto);


            _listaDeItensModeladosDoProjeto = _repoItemModelado.ObterItensModeladosDoProjeto(guidProjeto);

            //_listaItensDiagrama = _repositorioItemPQPlant3d.ObterItensPQPorProjeto(guidProjeto);
            //_listaDeItensModeladosDoProjeto = _repoItemModelado.ObterItensModeladosDoProjeto(guidProjeto);


            //_tiposDeItensConformeInicioDaDescricao = new List<string>
            //{
            //    "TUBO","PIPE","VÁLVULA"
            //};

            _itensModeladosQueJaForamIncluidosEmItemDiagrama = new List<ItemModelado>();
            _itensPQIncluidos = new List<ItemPQ>();

        }

        //public string DataBaseProjeto { get; set; }
        //public string GuidProjeto { get; set; }



        public void CadastrarItens(AreaTag areaPlanejada)
        {

            var listaItensExistentesDiagramaParaArea = _listaItensDiagrama.Where(x =>
                       x.ItemTag.NumeroAtivo.AreaTag.Equals(areaPlanejada)).ToList();

            foreach (var itemDiagramaParaProcessar in listaItensExistentesDiagramaParaArea)
            {
                DefineItensComBaseNoItemDoDiagrama(areaPlanejada, itemDiagramaParaProcessar);
            }





        }


        public List<ItemModelado> ObtemItensModeladosNaoIncluidosEmItemDiagrama()
        {
            var itensModeladosNaoIncluidosEmItemDiagrama = new List<ItemModelado>();

            foreach (var item in _listaDeItensModeladosDoProjeto)
            {
                var itemEncontrado = _itensModeladosQueJaForamIncluidosEmItemDiagrama
                     .FirstOrDefault(x => x.GUID == item.GUID);

                if (itemEncontrado == null)
                {
                    var tipoItemModelado = item.DescricaoLongaDimensionada.Split(',').First().Split('.').First().Split(' ').First().Trim();

                    //switch (tipoItemModelado)
                    //{
                    //    case "TUBO":
                    //        itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
                    //        break;
                    //    case "PIPE":
                    //        itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
                    //        break;
                    //    case "VÁLVULA":
                    //        itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
                    //        break;
                    //    default:
                    //        string tg = "";
                    //        break;
                    //}

                    itensModeladosNaoIncluidosEmItemDiagrama.Add(item);

                }
            }

            return itensModeladosNaoIncluidosEmItemDiagrama;
        }



        private void DefineItensComBaseNoItemDoDiagrama(AreaTag areaPlanejada, ItemPQ itemDiagramaParaProcessar)
        {
            //var tipoItemDiag = ObterTipoDeItemPelaDescricao(itemDiagramaParaProcessar);

            //if (TipoDeItemEstaConfomeNomeCadastrado(tipoItemDiag))
            //{
                string descricao = itemDiagramaParaProcessar.SpecPart;

                var itensModeladosComDescricaoConformeItemDiagrama = obterItensModeladosComMesmaDecricaoDeItensDoDiagrama(areaPlanejada, descricao);

                if (ItemNaoFoiCadastrado(areaPlanejada, descricao))
                {
                    CadastrarItemPQ(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);
                }
                else
                {
                    ModificarCadastroDeItemPQ(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);
                }
            //}
        }

        private void ModificarCadastroDeItemPQ(ItemPQ itemDiagramaParaProcessar, List<ItemModelado> itensModeladosComDescricaoConformeItemDiagrama)
        {
            if (ExistemItensModeladosComDescricaoConformeDiagrama(itensModeladosComDescricaoConformeItemDiagrama))
            {
                ModificarItemIncluidoItensModelados(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);

            }

        }

        private void ModificarItemIncluidoItensModelados(ItemPQ itemDiagramaParaProcessar, List<ItemModelado> itensModeladosComDescricaoConformeItemDiagrama)
        {
            incluirItensModeladosNoItemDiagrama(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);

            itemDiagramaParaProcessar.CorAvanco = "green";

            _repositorioItemPQPlant3d.ModificarItemPQ(itemDiagramaParaProcessar);
        }

        private void CadastrarItemPQ(ItemPQ itemDiagramaParaProcessar, List<ItemModelado> itensModeladosComDescricaoConformeItemDiagrama)
        {
            if (ExistemItensModeladosComDescricaoConformeDiagrama(itensModeladosComDescricaoConformeItemDiagrama))
            {
                SalvarItemDiagramaComModelos(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);

            }
            else
            {
                SalvarItemDiagamaQueNaoPossuiNadaModelado(itemDiagramaParaProcessar);
            }
        }

        private void SalvarItemDiagamaQueNaoPossuiNadaModelado(ItemPQ itemDiagramaParaProcessar)
        {
            salvarItemDiagrama(itemDiagramaParaProcessar, "yellow");
        }

        private void SalvarItemDiagramaComModelos(ItemPQ itemDiagramaParaProcessar, List<ItemModelado> itensModeladosComDescricaoConformeItemDiagrama)
        {
            incluirItensModeladosNoItemDiagrama(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);
            salvarItemDiagrama(itemDiagramaParaProcessar, "green");
        }

        private void salvarItemDiagrama(ItemPQ itemDiagramaParaProcessar, string corAvanco)
        {
            itemDiagramaParaProcessar.CorAvanco = corAvanco;
            _repositorioItemPQPlant3d.InserirItem(itemDiagramaParaProcessar);
            _itensPQIncluidos.Add(itemDiagramaParaProcessar);
        }

        private void incluirItensModeladosNoItemDiagrama(ItemPQ itemDiagramaParaProcessar, List<ItemModelado> itensModeladosComDescricaoConformeItemDiagrama)
        {
            foreach (var modeladoEncontrouDescricaoItemDiagrama in itensModeladosComDescricaoConformeItemDiagrama)
            {

                _itensModeladosQueJaForamIncluidosEmItemDiagrama.Add(modeladoEncontrouDescricaoItemDiagrama);

                itemDiagramaParaProcessar.AdicionaItemModelado(modeladoEncontrouDescricaoItemDiagrama);

            }
        }

        private static bool ExistemItensModeladosComDescricaoConformeDiagrama(List<ItemModelado> itensModeladosComDescricaoConformeItemDiagrama)
        {
            return itensModeladosComDescricaoConformeItemDiagrama.Count() > 0;
        }

        private List<ItemModelado> obterItensModeladosComMesmaDecricaoDeItensDoDiagrama(AreaTag areaPlanejada, string descricao)
        {

            return _listaDeItensModeladosDoProjeto
          .Where(x => x.ItemTag.NumeroAtivo.AreaTag.Equals(areaPlanejada.Area)
          && x.DescricaoLongaDimensionada == descricao).ToList();
        }

        private bool ItemNaoFoiCadastrado(AreaTag areaPlanejada, string descricao)
        {
            var item = _itensPQIncluidos.FirstOrDefault(x =>
                            x.ItemTag.NumeroAtivo.AreaTag.Equals(areaPlanejada)
                            && x.SpecPart == descricao);

            return item == null ? true : false;
        }

        //private bool TipoDeItemEstaConfomeNomeCadastrado(string tipoItemDiag)
        //{
        //    return _tiposDeItensConformeInicioDaDescricao.Exists(x => x == tipoItemDiag);
        //}

        private static string ObterTipoDeItemPelaDescricao(ItemPQ itemDiagramaParaProcessar)
        {
            return itemDiagramaParaProcessar.SpecPart.Split(',').First().Split('.').First().Split(' ').First().Trim();
        }
    }
}
