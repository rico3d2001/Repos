using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.Entities
{
    public class EstadoApp : Entidade
    {

        public EstadoApp()
        {

        }

        public EstadoApp(string siglaUsuario, string guidDisciplina)
        {

            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(siglaUsuario,guidDisciplina), -1);
           
        }


        public EstadoApp(Resumo resumo, Projeto projeto, CabecalhoPQ cabecalhoPQ)
        {
            IdentidadePQ = resumo.IdentidadePQ;
            PQEstaEmitida = resumo.PQEstaEmitida;
            ResumoAtivo = resumo.EstaAtivo;
       

            NumeroPQCliente = cabecalhoPQ.NumeroCliente;

            NomeProjeto = projeto.NomeProjeto;
            SiglaProjeto = projeto.Sigla;
            Origem = projeto.Origem;
            Endereco = projeto.Endereco;


    

        }

        public void Reset(IdentidadeEstado identidadeEstado)
        {
            IdentidadePQ = new IdentidadePQ(
                new IdentidadeEstado(IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.GuidDisciplina), -1);
            ResumoAtivo = false;
            PQEstaEmitida = false;
            NumeroPQCliente = "";
            SiglaProjeto = "";
            Origem = "";
            Endereco = "";
            Operacao = "";
            NomeProjeto = "";
            NumeroArea = "";
            NumeroSubArea = "";

        }

        //public EstadoApp(IdentidadeEstado identidadeEstado, string numeroCliente, Projeto projeto, bool pQEstaEmitida)
        //{
        //    IdentidadePQ = new IdentidadePQ(identidadeEstado, -1);
        //    NumeroPQCliente = numeroCliente;
        //    PQEstaEmitida = pQEstaEmitida;
        //    NomeProjeto = projeto.NomeProjeto;
        //    SiglaProjeto = projeto.Sigla;
        //}


        public IdentidadePQ IdentidadePQ { get; set; }
        public string NumeroArea { get; set; }
        public string NumeroSubArea { get; set; }
        
     
        public bool ResumoAtivo { get; set; }

        public string NumeroPQCliente { get; set; }
        public bool PQEstaEmitida { get; set; }

        public string NomeProjeto { get; set; }
        public string SiglaProjeto { get; set; }
        public string Operacao { get; set; }
        public string Origem { get; set; }
        public string Endereco { get; set; }


    }
}

