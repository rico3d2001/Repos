using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.Dominio.Spec.Entidades;
using Brass.Materiais.Nucleo;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace Brass.Materiais.TesteBulkload.Templates
{
    public class DescritivoBrassXLS : LeitoraPlanilha<Descritivo>, ILeitoraPlanilha<Descritivo>
    {
        string _GUID_CLIENTE;
        Versao _versao;
        string _GUID_IDIOMA;
        string _GUID_DESCRITIVO_PTBR_VALE;

        public DescritivoBrassXLS(string GUID_CLIENTE, Versao versao, string GUID_IDIOMA, string GUID_DESCRITIVO_PTBR_VALE, int numeroLinha) : base(numeroLinha)
        {
            _lista = new List<Descritivo>();
            _versao = versao;
            _GUID_CLIENTE = GUID_CLIENTE;
            _GUID_IDIOMA = GUID_IDIOMA;
            _GUID_DESCRITIVO_PTBR_VALE = GUID_DESCRITIVO_PTBR_VALE;
        }


        //public List<Descritivo> Ler(Worksheet wsPlanilha)
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
                _lista.Add(new Descritivo(
                    _GUID_CLIENTE,
                     _versao,
                     _GUID_IDIOMA,
                     _GUID_DESCRITIVO_PTBR_VALE,
                    celula.GetString(_numeroLinha, 1).Trim(),
                    celula.GetString(_numeroLinha, 2).Trim(),
                    "",
                    ""
                   ));
            }


        }
    }
}
