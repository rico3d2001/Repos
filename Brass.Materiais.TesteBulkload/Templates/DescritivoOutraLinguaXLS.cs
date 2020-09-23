using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.DominioPQ.Spec.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.TesteBulkload.Templates
{
    public class DescritivoOutraLinguaXLS : LeitoraPlanilha<Descritivo>, ILeitoraPlanilha<Descritivo>
    {
        string _GUID_CLIENTE;
        Versao _versao;
        string _GUID_IDIOMA;
        List<Descritivo> _listaDescritivosPTBR_BRASS;

        public DescritivoOutraLinguaXLS(string GUID_CLIENTE, Versao versao, string GUID_IDIOMA, int numeroLinha, 
            List<Descritivo> listaDescritivosPTBR_BRASS) : base(numeroLinha)
        {
            _lista = new List<Descritivo>();
            _versao = versao;
            _GUID_CLIENTE = GUID_CLIENTE;
            _GUID_IDIOMA = GUID_IDIOMA;
            _listaDescritivosPTBR_BRASS = listaDescritivosPTBR_BRASS;
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

                

                var guidPTBR = _listaDescritivosPTBR_BRASS
                    .First(x => x.SiglaPTBR == celula.GetString(_numeroLinha, 1).Trim()).GUID;

                _lista.Add(new Descritivo(
                    _GUID_CLIENTE,
                     _versao,
                     _GUID_IDIOMA,
                     guidPTBR,
                    celula.GetString(_numeroLinha, 1).Trim(),
                    celula.GetString(_numeroLinha, 2).Trim(),
                    celula.GetString(_numeroLinha, 3).Trim(),
                    celula.GetString(_numeroLinha, 4).Trim()
                   ));
            }


        }
    }
}
