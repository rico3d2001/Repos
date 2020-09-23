using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQ.CommandSide.AtivarDimensionados
{
    public class AtivarDimensionadosCommandHandle : Notifiable, IRequestHandler<AtivarDimensionadosCommand>
    {
        BaseMDBRepositorio<Atividade> _atividadeRepositorio;
        BaseMDBRepositorio<ItemPQ> _repoItemPQPlant3d;
        BaseMDBRepositorio<Projeto> _repoProjetos;

        public AtivarDimensionadosCommandHandle()
        {
            _atividadeRepositorio = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
            _repoItemPQPlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");
           
        }


        public async Task<Unit> Handle(AtivarDimensionadosCommand command, CancellationToken cancellationToken)
        {
            foreach (var dimensionado in command.Dimensionados)
            {
                var atividadesPai = _atividadeRepositorio.Encontrar(
                    Builders<Atividade>.Filter.Eq(x => x.NivelAtividade, "VVV")
                    & Builders<Atividade>.Filter.Eq(x => x.Codigo, dimensionado.CodigoPai));

                if (atividadesPai.Count == 1)
                {
                    //var atividadePai = atividadesPai.First()


                    //var versao = new Versao(0, "Brass usuario", "Acrescimo  permitido Vale", DateTime.Now);

                    //var atividade = new Atividade(
                    //    "WWW",
                    //    dimensionado.GuidAtividadePai,
                    //    itemParaAtivar.GuidDisciplina,
                    //    projeto.GUID_CLIENTE,
                    //    "PtBr",
                    //    versao,
                    //    itemParaAtivar.CodigoAtividade,
                    //    itemParaAtivar.DecricaoAtividade);

                    //_atividadeRepositorio.Inserir(atividade);

                    //var item = _repoItemPQPlant3d.Obter(itemParaAtivar.GuidItem);

                    //item.Atividade = atividade;

                    //_repoItemPQPlant3d.Atualizar(item);
                }
            }

            return Unit.Value;
        }
    }
}
