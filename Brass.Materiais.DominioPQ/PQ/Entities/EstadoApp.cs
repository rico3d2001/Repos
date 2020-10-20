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

            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(null, siglaUsuario,guidDisciplina), -1);
           
        }


        public EstadoApp(Resumo resumo, CabecalhoPQ cabecalhoPQ)
        {
            IdentidadePQ = resumo.IdentidadePQ;
            PQEstaEmitida = resumo.PQEstaEmitida;
            ResumoAtivo = resumo.EstaAtivo;
            NumeroPQCliente = cabecalhoPQ.NumeroCliente;

        }

        public void Reset(IdentidadeEstado identidadeEstado)
        {
            IdentidadePQ = new IdentidadePQ(
                new IdentidadeEstado(null, IdentidadePQ.IdentidadeEstado.SiglaUsuario, identidadeEstado.GuidDisciplina), -1);
            ResumoAtivo = false;
            PQEstaEmitida = false;
            NumeroPQCliente = "";
            Operacao = "";
            NumeroAtivo = null;

        }

        


        public IdentidadePQ IdentidadePQ { get; set; }
        public NumeroAtivo NumeroAtivo { get; set; }
        public bool ResumoAtivo { get; set; }
        public string NumeroPQCliente { get; set; }
        public bool PQEstaEmitida { get; set; }
        public string Operacao { get; set; }
        //public string DescricaoParaAtivar { get; set; }



    }
}

