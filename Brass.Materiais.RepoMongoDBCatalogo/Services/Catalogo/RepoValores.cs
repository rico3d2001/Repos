using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoValores
    {
        private static RepoValores _instance;

        List<PropriedadeItem> _descricoesDisponiveis;

        BaseMDBRepositorio<ValorTabelado> _valorTabeladoRepositorio;

        private RepoValores()
        {
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
        }

        private RepoValores(List<PropriedadeItem> descricoesDisponiveis)
        {
            _descricoesDisponiveis = descricoesDisponiveis;
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
        }

        
        public static RepoValores Instancia()
        {
            
                if (_instance == null)
                {
                    _instance = new RepoValores();
                }
                return _instance;
            
        }

        public static RepoValores InstanciaPorPropriedadeDefinida(string nomePropriedade)
        {
            if (_instance == null)
            {
                _instance = new RepoValores(new RepoPropriedadeItem().ObterPropriedadesDisponiveis(nomePropriedade));
            }
            return _instance;
        }


        public string ObterPorItemPipe(ItemPipe itemDaFamilia)
        {
            var propriedadeItem = obterPropriedadeItem(_descricoesDisponiveis, itemDaFamilia);

            var valor = _valorTabeladoRepositorio.Encontrar(
                 Builders<ValorTabelado>.Filter.Eq(x => x.GUID, propriedadeItem.GUID_VALOR)).First();

            return valor.VALOR;
        }

        private PropriedadeItem obterPropriedadeItem(List<PropriedadeItem> obterPropiedadeDescritivaDimensionada, ItemPipe itemDaFamilia)
        {
            PropriedadeItem propriedadeItem = null;

            var relacoesPropItemPipe = new RepoRelacaoPropriedadeItem().ObterRelacoesEntrePropriedadeItem(itemDaFamilia);

            foreach (var relacao in relacoesPropItemPipe)
            {
                propriedadeItem = obterPropiedadeDescritivaDimensionada.FirstOrDefault(x => x.GUID == relacao.GUID_PROPRIEDADE);

                if (propriedadeItem != null) break;

            }

            return propriedadeItem;
        }

        public void CadastrarValor(ValorTabelado valorTabelado)
        {
            _valorTabeladoRepositorio.Inserir(valorTabelado);
        }

        public ValorTabelado ObterDescricao(string descricao)
        {
            var valores = _valorTabeladoRepositorio.Encontrar(
              Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, descricao));

            return valores.Count() == 1 ? valores.First() : null;
        }
    }
}
