using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.Dominio.Spec.Entidades;
using Brass.Materiais.Nucleo;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace Brass.Materiais.TesteBulkload.Templates
{
    public class EstruturaDescricaoXLS : LeitoraPlanilha<EstruturaDescricao>, ILeitoraPlanilha<EstruturaDescricao>
    {
        string _GUID_CLIENTE;
        Versao _versao;


        public EstruturaDescricaoXLS(string GUID_CLIENTE, Versao versao, int numeroLinha) : base(numeroLinha)
        {
            _lista = new List<EstruturaDescricao>();
            _versao = versao;
            _GUID_CLIENTE = GUID_CLIENTE;
        }


        //public List<EstruturaDescricao> Ler(Worksheet wsPlanilha)
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
                _lista.Add(new EstruturaDescricao(
                    _GUID_CLIENTE,
                    _versao,
                    celula.GetString(_numeroLinha, 2),
                    celula.GetString(_numeroLinha, 3),
                    celula.GetString(_numeroLinha, 4),
                    celula.GetString(_numeroLinha, 5)
                    ));
            }


        }
    }
}
