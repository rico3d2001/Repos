using Brass.Materiais.AppPQClean.ViewModel;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterResumoPipe
{
    public class ObterResumoPipeQueryHandle : Notifiable, IRequestHandler<ObterResumoPipeQuery, ResumoViewModel>
    {
        //BaseMDBRepositorio<Resumo> _resumoRepositorio;
        RepoResumo _resumoRepositorio;
        //RepoItemPQ _repoItemPQ;

        public ObterResumoPipeQueryHandle()
        {
            _resumoRepositorio = new RepoResumo();
            //_repoItemPQ = new RepoItemPQ();

        }

        public Task<ResumoViewModel> Handle(ObterResumoPipeQuery request, CancellationToken cancellationToken)
        {

            ResumoViewModel resumoViewModel = new ResumoViewModel();
            //_itensRepositorio = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");

            var resumo = _resumoRepositorio.ObterResumoAtivoOndePQNaoFoiEmitida(request.IdentidadePQ);

            if(resumo != null)
            {
                resumoViewModel.IdentidadePQ = resumo.IdentidadePQ;
                resumoViewModel.Versao = resumo.Versao;
                resumoViewModel.EstaAtivo = resumo.EstaAtivo;
                resumoViewModel.PQEstaEmitida = resumo.PQEstaEmitida;

                foreach (var itemPQ in resumo.Itens)
                {
                    resumoViewModel.AdicionaItem(itemPQ);
                }
            }
          

           
            return Task.FromResult(resumoViewModel);



        }
    }
}
