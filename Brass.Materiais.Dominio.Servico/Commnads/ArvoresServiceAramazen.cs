using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.RepoSQLServerDapper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class ArvoresServiceAramazen
    {
        private ItemEngenhariaService _itemEngenhariaService;
        public List<RamalEstoque> ExtraiArvoreAramzen()
        {
            _itemEngenhariaService = new ItemEngenhariaService();

            var catalogos = _itemEngenhariaService.ObterCatalogos();


            var ramaisCatalogos = new List<RamalEstoque>();

            foreach (var catalogo in catalogos)
            {
                ramaisCatalogos.Add(new RamalEstoque(catalogo.NOME, catalogo.GUID, string.Empty,1));
            }

            ramaisCatalogos = ramaisCatalogos.OrderBy(x => x.name).ToList();

            foreach (var ramalCatalogo in ramaisCatalogos)
            {
                adicionaRamalCategoria(ramalCatalogo.guid, ramaisCatalogos);
            }

            return ramaisCatalogos;
        }

        private void adicionaRamalCategoria(string guidcatalogo, List<RamalEstoque> ramaisCatalogos)
        {
            var listaCategorias = _itemEngenhariaService.ObterCategorias(guidcatalogo);//new ArquivoEstoqueService().ObterPorConfiguracao(guidcatalogo);

            var cat = ramaisCatalogos.First(x => x.guid == guidcatalogo);

            if (cat != null)
            {
                foreach (var categoria in listaCategorias)
                {
                    var ramal = new RamalEstoque(categoria.NOME, categoria.GUID, guidcatalogo,1);
                    adicionaRamalTipoItem(guidcatalogo, ramal);
                    cat.Adiciona(ramal);

                }
            }
        }

        private void adicionaRamalTipoItem(string guidCatalogo, RamalEstoque categoria)
        {
            //var listaPlanilhas = new TemplateEstoqueService().ObterPorArquivo(arquivo.id);
            var listaTipos = _itemEngenhariaService.ObterTiposItem(guidCatalogo, categoria.guid);



            foreach (var tipo in listaTipos)
            {
                categoria.Adiciona(new RamalEstoque(tipo.NOME, tipo.GUID, categoria.guid,2));
            }
        }
    }
}
