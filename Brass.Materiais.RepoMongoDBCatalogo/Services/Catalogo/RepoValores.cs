using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoValores : RepositorioAbstratoGeral
    {
        private static RepoValores _instance;

        List<PropriedadeItem> _descricoesDisponiveis;

        BaseMDBRepositorio<ValorTabelado> _valorTabeladoRepositorio;

        private RepoValores(string conectionString) : base(conectionString)
        {
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>(new ConexaoMongoDb("Catalogo", conectionString), "ValorTabelado");
        }

        private RepoValores(List<PropriedadeItem> descricoesDisponiveis, string conectionString) : base(conectionString)
        {
            _descricoesDisponiveis = descricoesDisponiveis;
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>(new ConexaoMongoDb("Catalogo", conectionString), "ValorTabelado");
        }

        public object ObterTodos()
        {
            throw new NotImplementedException();
        }

        public static RepoValores Instancia(string connectioString)
        {
            
                if (_instance == null)
                {
                    _instance = new RepoValores(connectioString);
                }
                return _instance;
            
        }

        public static RepoValores InstanciaPorPropriedadeDefinida(string nomePropriedade, string connectioString)
        {
            if (_instance == null)
            {
                _instance = new RepoValores(new RepoPropriedadeItem(connectioString).ObterPropriedadesDisponiveis(nomePropriedade), connectioString);
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

            var relacoesPropItemPipe = new RepoRelacaoPropriedadeItem(_conectionString).ObterRelacoesEntrePropriedadeItem(itemDaFamilia);

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

        //public List<ValorTabelado> ObterValoresPorDescricao(string descricao)
        //{
        //    return _valorTabeladoRepositorio.Encontrar(
        //      Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, descricao));

        //}
    }
}
