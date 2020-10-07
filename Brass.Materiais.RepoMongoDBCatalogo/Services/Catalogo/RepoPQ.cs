using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoPQ : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<DataPQ> _repoPQs;
        BaseMDBRepositorio<Resumo> _repoResumos;

        public RepoPQ(string conectionString) : base(conectionString)
        {
            _repoPQs = new BaseMDBRepositorio<DataPQ>(new ConexaoMongoDb("BIM_TESTE", conectionString), "PQPipeVale");
            _repoResumos = new BaseMDBRepositorio<Resumo>(new ConexaoMongoDb("BIM_TESTE", conectionString), "ResumoItensPQPlant3d");
        }



        public List<DataPQ> ObterPQsAtivas(IdentidadePQ identidadePQ)
        {
            return _repoPQs.Encontrar(
                Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadePQ.IdentidadeEstado.GuidProjeto)
                 & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadePQ.IdentidadeEstado.SiglaUsuario)
                 & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadePQ.IdentidadeEstado.GuidDisciplina)
                 //& Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.NumeroPQ, identidadePQ.NumeroPQ)
                 & Builders<DataPQ>.Filter.Eq(x => x.EstaAtiva, true));
        }

        public DataPQ ObterUltimaPQAtivaDoHub(IdentidadeEstado identidadeEstado)
        {
            var pqs = _repoPQs
                     .Encontrar(Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadeEstado.GuidProjeto)
                     & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.SiglaUsuario)
                     & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadeEstado.GuidDisciplina)
                     & Builders<DataPQ>.Filter.Eq(x => x.EstaAtiva, true)
                     & Builders<DataPQ>.Filter.Eq(x => x.EstaEmitida, false));

            var pqsOrdenadas = pqs.OrderBy(x => x.IdentidadePQ.NumeroPQ);

            return pqsOrdenadas.Count() > 0 ? pqsOrdenadas.Last() : null;
        }

        public DataPQ ObterUlitmaPQEmitida(IdentidadeEstado identidadeEstado)
        {
            var pqs = _repoPQs
                    .Encontrar(Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadeEstado.GuidProjeto)
                    & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.SiglaUsuario)
                    & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadeEstado.GuidDisciplina)
                    & Builders<DataPQ>.Filter.Eq(x => x.EstaAtiva, false)
                    & Builders<DataPQ>.Filter.Eq(x => x.EstaEmitida, true));

            var pqsOrdenadas = pqs.OrderBy(x => x.IdentidadePQ.NumeroPQ);

            return pqsOrdenadas.Count() > 0 ? pqsOrdenadas.Last() : null;
        }

        internal bool NaoComtemPQs(IdentidadeEstado identidadeEstado)
        {
            var pqs = _repoPQs
                 .Encontrar(Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadeEstado.GuidProjeto)
                 & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.SiglaUsuario)
                 & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadeEstado.GuidDisciplina));

            return pqs.Count > 0 ? false : true;
        }
    

        public DataPQ ObterPQ(IdentidadePQ identidadePQ)
        {
            var pqs = _repoPQs
                    .Encontrar(Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadePQ.IdentidadeEstado.GuidProjeto)
                    & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadePQ.IdentidadeEstado.SiglaUsuario)
                    & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadePQ.IdentidadeEstado.GuidDisciplina)
                    & Builders<DataPQ>.Filter.Eq(x => x.IdentidadePQ.NumeroPQ, identidadePQ.NumeroPQ));

            return pqs.Count() == 1 ? pqs.First() : null;
        }

        public void Modificar(DataPQ dataPQ)
        {
            _repoPQs.Atualizar(dataPQ);
        }

        public void CadastrarPQ(DataPQ dataPQ)
        {
            _repoPQs.Inserir(dataPQ);
        }

        public void EmitirPQ(DataPQ dataPQ)
        {
           var resumos =  _repoResumos.Encontrar(Builders<Resumo>.Filter.Eq(x => x.GuidPQ, dataPQ.GUID));

            if(resumos.Count == 1)
            {
                var resumo = resumos.First();
                resumo.EstaAtivo = false;
                resumo.PQEstaEmitida = true;
                dataPQ.EstaAtiva = false;
                dataPQ.EstaEmitida = true;

                _repoPQs.Atualizar(dataPQ);
                _repoResumos.Atualizar(resumo);
            }

           

        }
    }
}
