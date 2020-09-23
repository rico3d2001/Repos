using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.Nucleo.ValueObjects;

namespace Brass.Materiais.TesteBulkload.Templates
{
    public class AreasPlanejadaXLS : LeitoraPlanilha<AreaPlanejada>, ILeitoraPlanilha<AreaPlanejada>
    {
        string _GUID_PROJETO;
       
        Versao _versao;

        public AreasPlanejadaXLS(int numeroLinha, string gUID_PROJETO, Versao versao) :base(numeroLinha)
        {
            _GUID_PROJETO = gUID_PROJETO;
 
            _versao = versao;
        }


        protected override void LerPorLinha(Celula celula)
        {
            //só para outro funcionar eu comentei



            //if (!string.IsNullOrEmpty(celula.GetString(_numeroLinha, 1)))
            //{
            //    _lista.Add(new AreaPlanejada(
            //        _GUID_PROJETO,
            //        celula.GetString(_numeroLinha, 1),
            //        celula.GetString(_numeroLinha, 2),
            //        celula.GetString(_numeroLinha, 3),
            //        _versao));
            //}
        }
    }
}
