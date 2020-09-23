using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoSPE
    {
        BaseMDBRepositorio<ItemSPE> _repoAreasSPE;
        RepoAtividade _repoAtividade;

        public RepoSPE()
        {
            _repoAtividade = new RepoAtividade();
            _repoAreasSPE = new BaseMDBRepositorio<ItemSPE>("Catalogo", "SPE");
        }

        public List<ItemSPE> ObterAtividadesPorCodigos(string guidAtividade)
        {
            List<ItemSPE> areasDistintas = new List<ItemSPE>();

            var atividadeVVV = _repoAtividade.ObterPorGuid(guidAtividade);
            var atividadeUU = _repoAtividade.ObterPorGuid(atividadeVVV.GUID_PAI);
            var atividadeTT = _repoAtividade.ObterPorGuid(atividadeUU.GUID_PAI);
            var atividadeK = _repoAtividade.ObterPorGuid(atividadeTT.GUID_PAI);


            var atividadesSPE = _repoAreasSPE.Encontrar(
                Builders<ItemSPE>.Filter.Eq(x => x.Nivel_VVV, atividadeVVV.Codigo)
                & Builders<ItemSPE>.Filter.Eq(x => x.Nivel_UU, atividadeUU.Codigo)
                & Builders<ItemSPE>.Filter.Eq(x => x.Nivel_TT, atividadeTT.Codigo)
                & Builders<ItemSPE>.Filter.Eq(x => x.Nivel_K, atividadeK.Codigo))
                .OrderBy(x => x.Descricao).ToList();

            foreach (var area in atividadesSPE)
            {
                if (area.Nivel_WWW != "000" &&  ItemNaoFoiColetado(areasDistintas, area))
                {
                    areasDistintas.Add(area);
                }
            }
           
            return areasDistintas;
        }

        private static bool ItemNaoFoiColetado(List<ItemSPE> areasDistintas, ItemSPE area)
        {
            return areasDistintas.FirstOrDefault(x => x.Descricao == area.Descricao) == null;
        }
    }
}
