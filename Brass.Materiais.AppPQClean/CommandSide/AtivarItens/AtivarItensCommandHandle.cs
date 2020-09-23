using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
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

        BaseMDBRepositorio<Atividade> _atividadeRepositorio;
        //BaseMDBRepositorio<ItemPQPlant3d> _repoItemPQPlant3d;
        BaseMDBRepositorio<Projeto> _repoProjetos;
        BaseMDBRepositorio<ItemPipe> _repositorioItemPipe;

        public AtivarItensCommandHandle()
        {
            _atividadeRepositorio = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
            //_repoItemPQPlant3d = new BaseMDBRepositorio<ItemPQPlant3d>("BIM_TESTE", "ItemPQPlant3d");
            _repoProjetos = new BaseMDBRepositorio<Projeto>("BIM", "Projetos");
            _repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
        }


        public async Task<Unit> Handle(AtivarItensCommand command, CancellationToken cancellationToken)
        {
            //var projeto = _repoProjetos.Obter(command.ItensParaAtivar[0].GuidProjeto);

            foreach (var itemParaAtivar in command.ItensParaAtivar)
            {

                var atividadesPai = _atividadeRepositorio.Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID, itemParaAtivar.GuidAtividadePai));
                //Builders<Atividade>.Filter.Eq(x => x.NivelAtividade, "VVV")
                //& Builders<Atividade>.Filter.Eq(x => x.GUID, itemParaAtivar.GuidAtividadePai));

                

                if (atividadesPai.Count == 1)
                {

                    var itemPipe = _repositorioItemPipe.Obter(itemParaAtivar.GuidItem);

                    if(itemPipe != null)
                    {
                        var versao = new Versao(0, "Brass usuario", "Acrescimo  permitido Vale", DateTime.Now);

                        var atividade = new Atividade(
                            "WWW",
                            itemParaAtivar.GuidAtividadePai,
                            itemParaAtivar.GuidDisciplina,
                            "",
                            "PtBr",
                            versao,
                            itemParaAtivar.CodigoAtividade,
                            itemParaAtivar.DecricaoAtividade);

                        _atividadeRepositorio.Inserir(atividade);



                        itemPipe.GUID_ATIVIDADE = atividade.GUID;

                        _repositorioItemPipe.Atualizar(itemPipe);
                    }

                 

                }


            }


            /*
                NivelAtividade = nivelAtividade;
            GUID_CLIENTE = gUID_CLIENTE;
            GUID_PAI = gUID_PAI;
            GUID_DISCIPLINA = gUID_DISCIPLINA;
            GUID_IDIOMA = gUID_IDIOMA;
            Versao = versao;
            Codigo = codigo;
            Descricao = descricao;
             */


            ////.Obter(command.GuidAtividade);
            //if (atividadesPai.Count == 1)
            //{
            //    var atividadePai = atividadesPai.First();

            //    //var atividade = 

            //    //var itemParaAtivar = _repoItemPQPlant3d.Obter(command.GuidItem);



            //    //_repoItemPQPlant3d.Atualizar(itemParaAtivar);
            //}



            return Unit.Value;


        }
    }
}
