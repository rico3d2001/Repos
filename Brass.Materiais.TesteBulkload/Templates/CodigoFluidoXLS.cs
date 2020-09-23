using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.DominioPQ.Spec.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using System.Collections.Generic;

namespace Brass.Materiais.TesteBulkload.Templates
{
    public class CodigoFluidoXLS : LeitoraPlanilha<CodigoFluido>, ILeitoraPlanilha<CodigoFluido>
    {

        string _GUID_CLIENTE;
        Versao _versao;

        public CodigoFluidoXLS( string GUID_CLIENTE, Versao versao, int numeroLinha):base(numeroLinha)
        {
            _lista = new List<CodigoFluido>();
            _versao = versao;
            _GUID_CLIENTE = GUID_CLIENTE;
        }


        //public List<CodigoFluido> Ler(Worksheet wsPlanilha)
        //{
        //    var celula = new Celula(wsPlanilha);

        //    do
        //    {
        //        LerPorLinha(celula);
        //        _numeroLinha++;

        //    } while (!Fim(celula));

        //    return _lista;

        //}

        protected override void LerPorLinha(Celula celula)
        {
            if (!string.IsNullOrEmpty(celula.GetString(_numeroLinha, 1)))
            {
                _lista.Add(new CodigoFluido(
                    _GUID_CLIENTE,
                    celula.GetString(_numeroLinha, 1),
                    celula.GetString(_numeroLinha, 2),
                    celula.GetString(_numeroLinha, 3),
                    _versao));
            }


        }




    }
}
