using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItensPipePlant3d
{
    public class ObterItensPipePlant3dQueryHandler : Notifiable, IRequestHandler<ObterItensPipePlant3dQuery, ItemPQ[]>
    {

        BaseMDBRepositorio<ItemPQ> _repositorioItemPQPlant3d;
        BaseMDBRepositorio<Atividade> _repositorioAtividade;

        //teste
        BaseMDBRepositorio<NomeTipoPropriedade> _nomeTipoPropriedadeRepositorio;
        BaseMDBRepositorio<RelacaoPropriedadeItem> _relacaoPropriedadeItemRepositorio;
        BaseMDBRepositorio<PropriedadeItem> _propriedadeItemRepositorio;
        BaseMDBRepositorio<ValorTabelado> _valorTabeladoRepositorio;
        BaseMDBRepositorio<RelacaoFamiliaItem> _relacaoFamiliaItemRepositorio;
        BaseMDBRepositorio<Familia> _repositorioFamilias;
        BaseMDBRepositorio<Categoria> _categoriasRepositorio;

        BaseMDBRepositorio<ItemPipe> _repositorioItemPipe;

        public ObterItensPipePlant3dQueryHandler()
        {
            _repositorioItemPQPlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");
            _repositorioAtividade = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");


            //testes
            _nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            _repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
            _relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
            _propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
            _repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
            _relacaoFamiliaItemRepositorio = new BaseMDBRepositorio<RelacaoFamiliaItem>("Catalogo", "RelacaoFamiliaItem");
            _repositorioFamilias = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            _categoriasRepositorio = new BaseMDBRepositorio<Categoria>("Catalogo", "Categorias");

        }


        public Task<ItemPQ[]> Handle(ObterItensPipePlant3dQuery request, CancellationToken cancellationToken)
        {
            var itensPQ = obtemItensPQ(request);

            foreach (var itemPQ in itensPQ)
            {

                if (itemPQEstaCatalogado(itemPQ))
                {
                    if (itemPQNaoPossuiAtividadeDefinida(itemPQ))
                    {
                        var itemPipe = _repositorioItemPipe.Obter(itemPQ.ItemPipe.GUID);

                        if (atividadeEstaCadastrada(itemPipe))
                        {
                            confereAtividadeAoItemPQ(itemPQ, itemPipe);
                        }

                    }

                }


            }

            return Task.FromResult(itensPQ);
        }

        private ItemPQ[] obtemItensPQ(ObterItensPipePlant3dQuery request)
        {
            return _repositorioItemPQPlant3d
                .Encontrar(Builders<ItemPQ>.Filter.Eq(x => x.GuidProjeto, request.GuidProjeto)
                & Builders<ItemPQ>.Filter.Eq(x => x.SiglaUsuario, request.SiglaUsuario)
                & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.AreaDesenho.Area, request.Area)
                & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.AreaDesenho.SubArea, request.SubArea)

                ).OrderBy(x => x.SpecPart).ToArray();
        }

        private static bool itemPQNaoPossuiAtividadeDefinida(ItemPQ itemPQ)
        {
            return itemPQ.Atividade == null;
        }

        private static bool itemPQEstaCatalogado(ItemPQ itemPQ)
        {
            return itemPQ.ItemPipe != null;
        }

        private void confereAtividadeAoItemPQ(ItemPQ itemPQ, ItemPipe itemPipe)
        {
            var atividade = _repositorioAtividade.Obter(itemPipe.GUID_ATIVIDADE);
            itemPQ.Atividade = atividade;
            _repositorioItemPQPlant3d.Atualizar(itemPQ);
        }

        private static bool atividadeEstaCadastrada(ItemPipe itemPipe)
        {
            return !(itemPipe.GUID_ATIVIDADE == null || itemPipe.GUID_ATIVIDADE == "");
        }
    }
}
