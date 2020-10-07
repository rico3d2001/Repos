using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoResumo : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<Resumo> _repoResumo;
        RepoPQ _repoPQ;

        public RepoResumo(string conectionString) : base(conectionString)
        {
            _repoResumo = new BaseMDBRepositorio<Resumo>(new ConexaoMongoDb("BIM_TESTE", conectionString), "ResumoItensPQPlant3d");

            _repoPQ = new RepoPQ(_conectionString);
        }

        public Resumo ObterPorGuid(string guidResumo)
        {
            return _repoResumo.Obter(guidResumo);
        }







        //public Resumo ObterPorGuid(string guid)
        //{
        //    return _repoResumo.Obter(guid);
        //}

        //public Resumo ObterPorUsuarioDisciplinaProjeto(string guidUsuario,string guidDisciplina,string guidProjeto)
        //{

        //}

        public void AdicionarItensAoResumoEncontrado(Resumo resumo, List<ItemPQ> itens)
        {
            resumo.IncluirListaDeItens(itens);
            _repoResumo.Atualizar(resumo);
        }

        public void CadastarResumo(Resumo resumo)
        {
            _repoResumo.Inserir(resumo);
        }

        public Resumo ObterResumo(IdentidadePQ identidadePQ)
        {
            var resumos = _repoResumo
                  .Encontrar(Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadePQ.IdentidadeEstado.GuidProjeto)
                  & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadePQ.IdentidadeEstado.SiglaUsuario)
                  & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadePQ.IdentidadeEstado.GuidDisciplina)
                  & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.NumeroPQ, identidadePQ.NumeroPQ));

            return resumos.Count() == 1 ? resumos.First() : null;
        }

        public List<Resumo> ObterTodosResumos(IdentidadeEstado identidadeEstado)
        {
           return  _repoResumo
                 .Encontrar(Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadeEstado.GuidProjeto)
                 & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.SiglaUsuario)
                 & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadeEstado.GuidDisciplina));
        }

        public Resumo ObterResumoDoProjetoSemPQ(IdentidadePQ identidadePQ)
        {
            //if (_repoPQ.NaoComtemPQs(identidadePQ.IdentidadeEstado))
            //{
                var resumos = _repoResumo
                 .Encontrar(Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadePQ.IdentidadeEstado.GuidProjeto)
                 & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadePQ.IdentidadeEstado.SiglaUsuario)
                 & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadePQ.IdentidadeEstado.GuidDisciplina)
                 & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.NumeroPQ, -1)
                 & Builders<Resumo>.Filter.Eq(x => x.EstaAtivo, true)
                 & Builders<Resumo>.Filter.Eq(x => x.PQEstaEmitida, false));

                return resumos.Count() == 1 ? resumos.First() : null;
            //}

        }

        public void Modificar(Resumo resumoEncontrado)
        {
            _repoResumo.Atualizar(resumoEncontrado);
        }

        public Resumo ObterResumoAtivoOndePQNaoFoiEmitida(IdentidadePQ identidadePQ)
        {
            var resumos = _repoResumo
                .Encontrar(
                Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadePQ.IdentidadeEstado.GuidProjeto)
                & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadePQ.IdentidadeEstado.SiglaUsuario)
                & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadePQ.IdentidadeEstado.GuidDisciplina)
                & Builders<Resumo>.Filter.Eq(x => x.IdentidadePQ.NumeroPQ, identidadePQ.NumeroPQ)
                & Builders<Resumo>.Filter.Eq(x => x.EstaAtivo, true)
                & Builders<Resumo>.Filter.Eq(x => x.PQEstaEmitida, false)
                );

            return resumos.Count() == 1 ? resumos.First() : null;

        }

    }
}
