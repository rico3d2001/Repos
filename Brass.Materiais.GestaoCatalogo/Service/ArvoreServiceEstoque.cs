using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using System.Collections.Generic;

namespace Brass.Materiais.GestaoCatalogo.Service
{
    public class ArvoreServiceEstoque 
    {
        ArvoresServiceAramazen _arvoresServiceAramazen;
        RamalEstoqueService _ramalEstoqueService;
        public ArvoreServiceEstoque(ArvoresServiceAramazen arvoresServiceAramazen, RamalEstoqueService ramalEstoqueService)
        {
            _arvoresServiceAramazen = arvoresServiceAramazen;
            _ramalEstoqueService = ramalEstoqueService;
        }

        public void CarregaRamaisEstoque()
        {
            

            List<RamalEstoque> ramals = _arvoresServiceAramazen.ExtraiArvoreAramzen();

            _ramalEstoqueService.Carregar(ramals);

        }

        public List<RamalEstoque> ListaRamaisArvore()
        {
            List<RamalEstoque> ramaisEstoque = new List<RamalEstoque>();
            ramaisEstoque = _ramalEstoqueService.Listar();
            return ramaisEstoque;
        }

    }
}
