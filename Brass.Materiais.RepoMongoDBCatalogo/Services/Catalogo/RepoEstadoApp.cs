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
    public class RepoEstadoApp
    {
        BaseMDBRepositorio<EstadoApp> _repoEstadoApp;

        public RepoEstadoApp()
        {
            _repoEstadoApp = new BaseMDBRepositorio<EstadoApp>("BIM_TESTE", "EstadosApps");
        }

        public void CadastrarEstado(EstadoApp estado)
        {
            estado.ResumoAtivo = false;

            _repoEstadoApp.Inserir(estado);
        }

        public EstadoApp ObterEstadoPorProjetoUsuarioDisciplina(IdentidadeEstado identidadeEstado)
        {
            var estados = _repoEstadoApp
           .Encontrar(Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadeEstado.GuidProjeto)
           & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.SiglaUsuario)
           & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadeEstado.GuidDisciplina));

            return estados.Count == 1 ? estados.First() : null;
        }

        public EstadoApp ObterEstadoPorIdentidadePQ(IdentidadeEstado identidadeEstado)
        {
            List<EstadoApp> estados = new List<EstadoApp>();

            if (identidadeEstado.GuidProjeto != "none")
            {
                estados = _repoEstadoApp
                   .Encontrar(Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadeEstado.GuidProjeto)
                   & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.SiglaUsuario)
                   & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadeEstado.GuidDisciplina));
            }
            else
            {
                estados = _repoEstadoApp
                   .Encontrar(Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.SiglaUsuario)
                   & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadeEstado.GuidDisciplina));
            }
        

            return estados.Count == 1 ? estados.First() : null;
        }

        public void AtivaResumoDoEstado(IdentidadePQ identidadePQ)
        {
            var estados = _repoEstadoApp
                   .Encontrar(Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidProjeto, identidadePQ.IdentidadeEstado.GuidProjeto)
                   & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadePQ.IdentidadeEstado.SiglaUsuario)
                   & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, identidadePQ.IdentidadeEstado.GuidDisciplina));

            var estadoEncontrado = estados.First();
            estadoEncontrado.ResumoAtivo = true;
            estadoEncontrado.IdentidadePQ.NumeroPQ = identidadePQ.NumeroPQ;

            _repoEstadoApp.Atualizar(estadoEncontrado);
        }

        public EstadoApp ObterEstadoPorUsuarioDisciplina(string siglaUsuario, string guidDisciplina)
        {
            var estados = _repoEstadoApp
           .Encontrar(Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, siglaUsuario)
           & Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.GuidDisciplina, guidDisciplina));

            return estados.Count == 1 ? estados.First() : null;
        }

        public EstadoApp ObterEstadoPorUsuario(string guidUsuario)
        {
            var estados = _repoEstadoApp
           .Encontrar(Builders<EstadoApp>.Filter.Eq(x => x.IdentidadePQ.IdentidadeEstado.SiglaUsuario, guidUsuario));

            return estados.Count == 1 ? estados.First() : null;
        }

        //public EstadoApp ObterPorGuid(string guid)
        //{
        //    return _repoEstadoApp.Obter(guid);
        //}

        public void Modificar(EstadoApp estado)
        {
            _repoEstadoApp.Atualizar(estado);
        }


    }
}
