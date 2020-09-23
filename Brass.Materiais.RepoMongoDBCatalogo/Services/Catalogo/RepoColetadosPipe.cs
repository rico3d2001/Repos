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
    public class RepoColetadosPipe
    {
        Coletados _coleta;
        BaseMDBRepositorio<Coletados> _coletadosPipeRepositorio;

      




        public RepoColetadosPipe()
        {
            _coletadosPipeRepositorio = new BaseMDBRepositorio<Coletados>("Coletados", "ColetadosPipe");

            //var listaColetasDoProjeto = _coletadosPipeRepositorio.Encontrar(Builders<Coletados>.Filter.Eq(x => x.GuidProjeto, guidProjeto));

            //if(listaColetasDoProjeto.Count > 0)
            //{
            //    var ultima = listaColetasDoProjeto.Last();
            //    Versao version = new Versao(ultima.Versao.Numero, ultima.Versao.Origem, "Atualização", DateTime.Now);
            //    _coleta = new Coletados(guidProjeto, version);
            //}
            //else
            //{
                
            //    Versao versao = new Versao(0, "Plant3d", "Incio do Projeto", DateTime.Now);
            //    _coleta = new Coletados(guidProjeto, versao);
                
            //}

            //_coletadosPipeRepositorio.Inserir(_coleta);

        }

        public List<Coletados> ObterUltimaColeta(string guidProjeto, int numeroVersao)
        {
            return _coletadosPipeRepositorio.Encontrar(
                Builders<Coletados>.Filter.Eq(x => x.GuidProjeto, guidProjeto)
                & Builders<Coletados>.Filter.Eq(x => x.Versao.Numero, numeroVersao));

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





        public void CadastrarColetado(Coletados coletado)
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
