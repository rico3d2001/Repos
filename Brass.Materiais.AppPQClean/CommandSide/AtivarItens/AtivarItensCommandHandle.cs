using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.AtivarItens
{
    public class AtivarItensCommandHandle : Notifiable, IRequestHandler<AtivarItensCommand>
    {


       


        public async Task<Unit> Handle(AtivarItensCommand command, CancellationToken cancellationToken)
        {
            var atividadeRepositorio = new RepoAtividade(command.TextoConexao);
            var repoProjetos = new RepoProjetos(command.TextoConexao);
            var repositorioItemPipe = new RepoItemPipe(command.TextoConexao);

            foreach (var itemParaAtivar in command.ItensParaAtivar)
            {

                var atividadePai = atividadeRepositorio.ObterPorGuid(itemParaAtivar.GuidAtividadePai);
  
                if (atividadePai != null)
                {

                    var itemPipe = repositorioItemPipe.ObterPorGuid(itemParaAtivar.GuidItem);

                    if(itemPipe != null)
                    {
                        var versao = new Versao(0, "Brass usuario", "Acrescimo  permitido Vale", DateTime.Now);

                        var identidadeAtividade = new IdentidadeAtividade("", itemParaAtivar.GuidDisciplina, ""); //null,"RRP", itemParaAtivar.GuidDisciplina);



                        var atividade = new Atividade(
                            identidadeAtividade,
                            "WWW",
                            itemParaAtivar.GuidAtividadePai,
                            versao,
                            itemParaAtivar.CodigoAtividade,
                            itemParaAtivar.DecricaoAtividade,
                            "");

                        atividadeRepositorio.CatadastarAtividade(atividade);



                        itemPipe.GUID_ATIVIDADE = atividade.GUID;

                        repositorioItemPipe.Modificar(itemPipe);
                    }

                 

                }


            }


            return Unit.Value;

        }
    }
}
