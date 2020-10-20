using Brass.Materiais.AppPQClean.ViewModel;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterArvoreAtividades
{
    public class ObterArvoreAtividadesQueryHandle : Notifiable, IRequestHandler<ObterArvoreAtividadesQuery, RamalArvoreAtividade>
    {

        RepoAtividade _repoAtividade;


        List<Atividade> _atividades;

      


       


        public Task<RamalArvoreAtividade> Handle(ObterArvoreAtividadesQuery request, CancellationToken cancellationToken)
        {

            _repoAtividade = new RepoAtividade(request.TextoConexao);

            _atividades = _repoAtividade.ObterPorEstado(request.GuidProjeto,request.GuidDisciplina);

            var ramais = ExtraiArvoreCatalogoEstoque();

            return Task.FromResult(ramais);
        }


        public RamalArvoreAtividade ExtraiArvoreCatalogoEstoque()
        {
            
            RamalArvoreAtividade ramalBase = new RamalArvoreAtividade("Atividades", Guid.NewGuid().ToString(), "", 0, "");

           


            //var atividadesPai = _atividades.Where(x => x.GUID_PAI == "" && x.Codigo == "M").ToList();

            var atividadesPai = _atividades.Where(x => x.GUID_PAI == "" && x.Codigo != "D").ToList();

            foreach (var atividade in atividadesPai)
            {
                var codigoTronco = atividade.Codigo;
                ramalBase.Adiciona(new RamalArvoreAtividade(atividade.Descricao, atividade.GUID, atividade.GUID_PAI, 1, codigoTronco));
            }

         

            foreach (var ramalCatalogo in ramalBase.children)
            {


                adicionaRamalAtividade(ramalCatalogo.guid, ramalCatalogo);
            }

            return ramalBase;
        }

        private void adicionaRamalAtividade(string guidPai, RamalArvoreAtividade ramalParam)
        {

            var atividades = _atividades.Where(x => x.GUID_PAI == guidPai).ToList();

            foreach (var atividade in atividades)
            {
                var codigoRamal = ramalParam.Codigo + "-" + atividade.Codigo;
                var ramal = new RamalArvoreAtividade(atividade.Descricao, atividade.GUID, atividade.GUID_PAI, 0, codigoRamal);

                if (atividade.NivelAtividade != "WWW")
                {
                    ramalParam.Adiciona(ramal);

                    adicionaRamalAtividade(atividade.GUID, ramal);
                }

            }


        }






    }
}
