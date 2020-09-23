using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoItemModelado
    {
        BaseMDBRepositorio<ItemModelado> _repositorioItemModelado;
        public RepoItemModelado()
        {
            _repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM_TESTE", "ItensModelados");
        }

        public void InserirItemModelado(ItemModelado itemModel)
        {
            _repositorioItemModelado.Inserir(itemModel);
        }

        public List<ItemModelado> ObterItensModeladosDoProjeto(string guidProjeto)
        {
            return _repositorioItemModelado.Encontrar(
                   Builders<ItemModelado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));
        }

        public void CadastraColetado(AreaPlanejada areaPlanejada, Coletados coletado, string tag, AreaTag areaTagModelo)
        {


            if (coletado.ComponentePlant.PnPClassName == "Pipe")
            {
                _repositorioItemModelado.Inserir(ItemModelado.ConstroiItemModeladoDoTubo((BlancPipe)coletado.ComponentePlant, tag, areaTagModelo));
                
            }
            else
            {
                _repositorioItemModelado.Inserir(ItemModelado.ConstroiItemModeladoDeValvula((UnidadePipe)coletado.ComponentePlant, tag, areaTagModelo));
                
            }

            
        }

    }
}
