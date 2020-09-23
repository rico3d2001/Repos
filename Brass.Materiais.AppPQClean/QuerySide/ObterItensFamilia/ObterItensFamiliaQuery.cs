using Brass.Materiais.AppPQClean.ViewModel;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItensFamilia
{
    public class ObterItensFamiliaQuery : IRequest<ItemParaAtivar[]> 
    {
        public ObterItensFamiliaQuery(string guidFamilia, string guidAtividade)
        {
            GuidFamilia = guidFamilia;
            GuidAtividade = guidAtividade;
        }

        public string GuidFamilia { get; private set; }
        public string GuidAtividade { get; set; }

        public void Validate()
        {
           
        }

        //public List<DimensaoFamilia> ObtemItensFamilia()
        //{
        //    var familiaItemRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");


        //    List<DimensaoFamilia> listaItens = new List<DimensaoFamilia>();



        //    var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
        //    var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
        //    var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
        //    var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");

        //    var familia = familiaItemRepositorio
        //        .Encontrar(Builders<Familia>
        //        .Filter.Eq(x => x.GUID, GuidFamilia))
        //        .First();


        //    var guidNomePropriedade = nomeTipoPropriedadeRepositorio
        //        .Encontrar(Builders<NomeTipoPropriedade>
        //        .Filter.Eq(x => x.NOME, "PartSizeLongDesc")).First().GUID;


        //    var descricoesDisponiveis = propriedadeItemRepositorio
        //        .Encontrar(Builders<PropriedadeItem>
        //        .Filter.Eq(x => x.GUID_TIPO, guidNomePropriedade));


        //    var todasRelacoesPropriedadeItem = relacaoPropriedadeItemRepositorio.Obter();


        //    var todosOsValoresTabelados = valorTabeladoRepositorio.Obter();

        //    var descricoes = (from guidFam in familia.IdsItens
        //                      join relPI in todasRelacoesPropriedadeItem on guidFam equals relPI.GUID_ITEM_ENG
        //                      join diam in descricoesDisponiveis on relPI.GUID_PROPRIEDADE equals diam.GUID
        //                      join val in todosOsValoresTabelados on diam.GUID_VALOR equals val.GUID
        //                      select new { Valor = val.VALOR, GUID = relPI.GUID_ITEM_ENG }).ToList();


        //    if (descricoes.Count() > 0)
        //    {
        //        foreach (var decricao in descricoes)
        //        {
        //            listaItens.Add(new DimensaoFamilia(decricao.Valor, decricao.GUID));
        //        }

        //    }

        //    return listaItens;
        //}

       


    }
}
