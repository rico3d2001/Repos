using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.CatalogoPipe.Servico.Service
{
    public class CriaEstrutPipeRequest : Notifiable, IComando
    {
        RamalEstoqueService _ramalEstoqueService;
        public CriaEstrutPipeRequest(RamalEstoqueService ramalEstoqueService)
        {
            _ramalEstoqueService = ramalEstoqueService;
        }

        public List<RamalEstoque> ListaRamaisArvore()
        {
            List<RamalEstoque> ramaisEstoque = new List<RamalEstoque>();
            ramaisEstoque = _ramalEstoqueService.Listar();
            return ramaisEstoque;
        }

        public void Validate()
        {
            //throw new NotImplementedException();
        }
    }
}
