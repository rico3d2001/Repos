using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.DominioPQ.Spec.Entities;
using System.Collections.Generic;

namespace Brass.Materiais.TesteBulkload.Templates
{
    public class CodigoMaterialXLS : LeitoraPlanilha<CodigoMaterial>, ILeitoraPlanilha<CodigoMaterial>
    {
        string _GUID_CLIENTE;
        string _GUID_IDIOMA;


        public CodigoMaterialXLS(string GUID_CLIENTE, string GUID_IDIOMA, int numeroLinha) : base(numeroLinha)
        {
            _lista = new List<CodigoMaterial>();

            _GUID_CLIENTE = GUID_CLIENTE;
            _GUID_IDIOMA = GUID_IDIOMA;
        }


        //public List<CodigoMaterial> Ler(Worksheet wsPlanilha)
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
                _lista.Add(new CodigoMaterial(
                    _GUID_CLIENTE,
                    _GUID_IDIOMA,
                    celula.GetString(_numeroLinha, 1),
                    celula.GetString(_numeroLinha, 2)));
            }


        }
    }
}
