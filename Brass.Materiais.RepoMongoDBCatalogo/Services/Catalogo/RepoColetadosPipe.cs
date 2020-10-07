using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.Nucleo.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoColetadosPipe : RepositorioAbstratoGeral
    {
        //Coletado _coleta;
        BaseMDBRepositorio<Coletado> _coletadosPipeRepositorio;

      




        public RepoColetadosPipe(string conectionString) : base(conectionString)
        {
            
            _coletadosPipeRepositorio = new BaseMDBRepositorio<Coletado>(new ConexaoMongoDb("Coletados", conectionString), "ColetadosPipe");


        }

        public void DeletaColetados(string guidProjeto)
        {
            _coletadosPipeRepositorio.ApagarVarios(Builders<Coletado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));
        }

        public int Contar(string guidProjeto)
        {
          return (int) _coletadosPipeRepositorio.Contar(Builders<Coletado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));
        }

        //public int ContarTudo()
        //{
        //    return _coletadosPipeRepositorio.Obter();
        //}

        public List<Coletado> Todos()
        {
            return _coletadosPipeRepositorio.Obter();
        }

        public List<Coletado> ObterColetadosDaArea(string guidProjeto)
        {

            return _coletadosPipeRepositorio.Encontrar(
                Builders<Coletado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));

        }

        public bool NaoHouveColetaAinda(string guidProjeto)
        {
            var possuiUmRegistro = _coletadosPipeRepositorio.PossuiUmRegistro(Builders<Coletado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));

            return possuiUmRegistro ? false : true;
        }

        public bool JaHouveColeta(string guidProjeto)
        {
            var possuiUmRegistro = _coletadosPipeRepositorio.PossuiUmRegistro(Builders<Coletado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));

            return possuiUmRegistro ? true : false;
        }

        //public List<Coletados> ObterTubos(string guidProjeto, int numeroVersao)
        //{
        //    return _coletadosPipeRepositorio.Encontrar(
        //        Builders<Coletados>.Filter.Eq(x => x.GuidProjeto, guidProjeto)
        //        & Builders<Coletados>.Filter.Eq(x => x.Versao.Numero, numeroVersao)
        //        & Builders<Coletados>.Filter.Eq(x => x.ComponentePlant.PnPClassName, "PIPE"));

        //}

        //public List<Coletados> ObterComponentes(string guidProjeto, int numeroVersao)
        //{
        //    return _coletadosPipeRepositorio.Encontrar(
        //        Builders<Coletados>.Filter.Eq(x => x.GuidProjeto, guidProjeto)
        //        & Builders<Coletados>.Filter.Eq(x => x.Versao.Numero, numeroVersao)
        //        & !(Builders<Coletados>.Filter.Eq(x => x.ComponentePlant.PnPClassName, "PIPE")));

        //}





        public void Cadastrar (Coletado coletado)
        {
            _coletadosPipeRepositorio.Inserir(coletado);
        }

        //public void CadastrarBlancPipe(BlancPipe blancPipe)
        //{
        //    //_coleta.AdicionBlanc(blancPipe);
        //    //_coletadosPipeRepositorio.Atualizar(_coleta);

        //}

        //public void CadastrarUnidadePipe(UnidadePipe unidadePipe)
        //{
        //    //_coleta.AdicionUnidade(unidadePipe);
        //    //_coletadosPipeRepositorio.Atualizar(_coleta);
        //}
    }
}
