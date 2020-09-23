using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.DominioPQ.Spec.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using System.Collections.Generic;

namespace Brass.Materiais.TesteBulkload.Templates
{
    public class ClassePressaoXLS : LeitoraPlanilha<ClassePressao>, ILeitoraPlanilha<ClassePressao>
    {
        string _GUID_CLIENTE;
        Versao _versao;

        public ClassePressaoXLS(string GUID_CLIENTE, Versao versao, int numeroLinha) : base(numeroLinha)
        {
            _lista = new List<ClassePressao>();
            _versao = versao;
            _GUID_CLIENTE = GUID_CLIENTE;
        }


        //public List<ClassePressao> Ler(Worksheet wsPlanilha)
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
                _lista.Add(new ClassePressao(
                    _GUID_CLIENTE,
                    celula.GetString(_numeroLinha, 1),
                    celula.GetString(_numeroLinha, 2),
                    _versao));
            }


        }
    }
}
