using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.ServicoDominio.Services.CommandSide
{
    public class CadastroItensDiagramas
    {
        RepoItemPQ _repositorioItemPQPlant3d;
        RepoItemModelado _repoItemModelado;
        RepoItemDiagramasPlant3d _repoRepoItemDiagramasPlant3d;
        List<ItemPQ> _listaItensDiagrama;
        List<ItemPQ> _itensPQIncluidos;
        List<ItemModelado> _itensModeladosQueJaForamIncluidosEmItemDiagrama;
        List<ItemModelado> _listaDeItensModeladosDoProjeto;
        


        public CadastroItensDiagramas(string guidProjeto, string conectionString)
        {
            _repoItemModelado = new RepoItemModelado(conectionString);

    
            _repositorioItemPQPlant3d = new RepoItemPQ(conectionString);
            _repoRepoItemDiagramasPlant3d = new RepoItemDiagramasPlant3d(conectionString);

            _listaItensDiagrama = _repoRepoItemDiagramasPlant3d.ObterItensPQPorProjeto(guidProjeto);


            _listaDeItensModeladosDoProjeto = _repoItemModelado.ObterItensModeladosDoProjeto(guidProjeto);



            _itensModeladosQueJaForamIncluidosEmItemDiagrama = new List<ItemModelado>();
            _itensPQIncluidos = new List<ItemPQ>();

        }

   
        public void CadastrarItens(NumeroAtivo ativo)
        {

            var listaItensExistentesDiagramaParaArea = _listaItensDiagrama.Where(x =>
                       x.ItemTag.NumeroAtivo.Equals(ativo)).ToList();

            foreach (var itemDiagramaParaProcessar in listaItensExistentesDiagramaParaArea)
            {
                 DefineItensComBaseNoItemDoDiagrama(ativo, itemDiagramaParaProcessar);
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
          

                    itensModeladosNaoIncluidosEmItemDiagrama.Add(item);

                }
            }

            return itensModeladosNaoIncluidosEmItemDiagrama;
        }
        
        
        
        private void DefineItensComBaseNoItemDoDiagrama(NumeroAtivo ativo, ItemPQ itemDiagramaParaProcessar)
        {
        

                string descricao = itemDiagramaParaProcessar.SpecPart;

                var itensModeladosComDescricaoConformeItemDiagrama = obterItensModeladosComMesmaDecricaoDeItensDoDiagrama(ativo, descricao);

                if (ItemNaoFoiCadastrado(ativo, descricao))
                {
                    CadastrarItemPQ(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);
                }
                else
                {
                    ModificarCadastroDeItemPQ(itemDiagramaParaProcessar, itensModeladosComDescricaoConformeItemDiagrama);
                }
           
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

        private List<ItemModelado> obterItensModeladosComMesmaDecricaoDeItensDoDiagrama(NumeroAtivo ativo, string descricao)
        {
            return _listaDeItensModeladosDoProjeto
          .Where(x => x.ItemTag.NumeroAtivo.Equals(ativo) 
                      && x.DescricaoLongaDimensionada == descricao).ToList();
        }

        private bool ItemNaoFoiCadastrado(NumeroAtivo ativo, string descricao)
        {
            var item = _itensPQIncluidos.FirstOrDefault(x => (x.ItemTag.NumeroAtivo.Equals(ativo))
                            && x.SpecPart == descricao);

            return item == null ? true : false;
        }

     

        
    }
}
