using Brass.Materiais.Dominio.Servico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Commnads
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
