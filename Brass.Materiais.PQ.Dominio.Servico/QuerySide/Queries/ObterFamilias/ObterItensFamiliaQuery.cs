using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObterFamilias
{
    public class ObterItensFamiliaQuery : IComando
    {
        public ObterItensFamiliaQuery(string guidFamilia)
        {
            GuidFamilia = guidFamilia;
        }

        public string GuidFamilia { get; private set; }

        public void Validate()
        {
           
        }

        public List<DimensaoFamilia> ObtemItensFamilia()
        {
            var familiaItemRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");


            //var familia = familiaItemRepositorio
            //.Encontrar(Builders<Familia>
            //.Filter.Eq(x => x.GUID, guidFamilia));

            List<DimensaoFamilia> listaItens = new List<DimensaoFamilia>();



            var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
            var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
            var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");

            var familia = familiaItemRepositorio
                .Encontrar(Builders<Familia>
                .Filter.Eq(x => x.GUID, GuidFamilia))
                .First();


            var guidNomePropriedade = nomeTipoPropriedadeRepositorio
                .Encontrar(Builders<NomeTipoPropriedade>
                .Filter.Eq(x => x.NOME, "PartSizeLongDesc")).First().GUID;


            var descricoesDisponiveis = propriedadeItemRepositorio
                .Encontrar(Builders<PropriedadeItem>
                .Filter.Eq(x => x.GUID_TIPO, guidNomePropriedade));


            var todasRelacoesPropriedadeItem = relacaoPropriedadeItemRepositorio.Obter();


            var todosOsValoresTabelados = valorTabeladoRepositorio.Obter();

            var descricoes = (from guidFam in familia.IdsItens
                              join relPI in todasRelacoesPropriedadeItem on guidFam equals relPI.GUID_ITEM_ENG
                              join diam in descricoesDisponiveis on relPI.GUID_PROPRIEDADE equals diam.GUID
                              join val in todosOsValoresTabelados on diam.GUID_VALOR equals val.GUID
                              select new { Valor = val.VALOR, GUID = relPI.GUID_ITEM_ENG }).ToList();


            if (descricoes.Count() > 0)
            {
                foreach (var decricao in descricoes)
                {
                    listaItens.Add(new DimensaoFamilia(decricao.Valor, decricao.GUID));
                }

            }

            return listaItens;
        }

       


    }
}
