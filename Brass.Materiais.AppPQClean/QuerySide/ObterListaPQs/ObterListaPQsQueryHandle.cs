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

        public ObterListaPQsQueryHandle()
        {
            _repoResumo = new RepoResumo();//new BaseMDBRepositorio<Resumo>("BIM_TESTE", "ResumoItensPQPlant3d");
            _repoDataPQ = new RepoPQ(); //new BaseMDBRepositorio<DataPQ>("BIM_TESTE", "PQPipeVale");
            _repoProjetos = new RepoProjetos();
        }


        public Task<List<EstadoApp>> Handle(ObterListaPQsQuery request, CancellationToken cancellationToken)
        {

            var listaResult = new List<EstadoApp>();



            var listaResumos = _repoResumo.ObterTodosResumos(request.IdentidadeEstado);
            
                

            
            foreach (var resumo in listaResumos)
            {

                var projeto = _repoProjetos.ObterProjeto(resumo.IdentidadePQ.IdentidadeEstado.GuidProjeto);

               //if (resumo.GuidPQ != null)
                //{
                    var pq = _repoDataPQ.ObterPQ(resumo.IdentidadePQ);

                    
                    listaResult.Add(new EstadoApp(resumo, projeto, pq.CabecalhoPQ));
                //}
                //else
                //{
                //    IdentidadePQ identidadePQ = new IdentidadePQ(request.IdentidadeEstado,-1);
                //    listaResult.Add(new EstadoApp(request.IdentidadeEstado, "Resumo sem PQ", projeto,false));
                //}

                
            }

            return Task.FromResult(listaResult);
        }
    }
}
