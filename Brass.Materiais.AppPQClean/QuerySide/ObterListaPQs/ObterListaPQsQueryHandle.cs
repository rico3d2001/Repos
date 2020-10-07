using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterListaPQs
{
    public class ObterListaPQsQueryHandle : Notifiable, IRequestHandler<ObterListaPQsQuery, List<EstadoApp>>
    {
        RepoResumo _repoResumo;
        RepoPQ _repoDataPQ;
        RepoProjetos _repoProjetos;

       


        public Task<List<EstadoApp>> Handle(ObterListaPQsQuery request, CancellationToken cancellationToken)
        {

            _repoResumo = new RepoResumo(request.TextoConexao);//new BaseMDBRepositorio<Resumo>("BIM_TESTE", "ResumoItensPQPlant3d");
            _repoDataPQ = new RepoPQ(request.TextoConexao); //new BaseMDBRepositorio<DataPQ>("BIM_TESTE", "PQPipeVale");
            _repoProjetos = new RepoProjetos(request.TextoConexao);

            var listaResult = new List<EstadoApp>();



            var listaResumos = _repoResumo.ObterTodosResumos(request.IdentidadeEstado);




            foreach (var resumo in listaResumos)
            {

               // var projeto = _repoProjetos.ObterProjeto(resumo.IdentidadePQ.IdentidadeEstado.GuidProjeto);


                var pq = _repoDataPQ.ObterPQ(resumo.IdentidadePQ);

                if (pq != null)
                {
                    listaResult.Add(new EstadoApp(resumo, pq.CabecalhoPQ));
                }
                




            }

            return Task.FromResult(listaResult);
        }
    }
}
