using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;

namespace Brass.Materiais.TesteBulkload.Templates.ItensXLS
{
    public class IntensObitidosSPEXLS : LeitoraPlanilha<ItemSPE>, ILeitoraPlanilha<ItemSPE>
    {
        BaseMDBRepositorio<ItemSPE> _repoSPE;
        SPEBook _book;
        public IntensObitidosSPEXLS(int numeroLinha, SPEBook book) : base(numeroLinha)
        {
            _repoSPE = new BaseMDBRepositorio<ItemSPE>("Catalogo", "SPE");
            _book = book;
        }

        protected override void LerPorLinha(Celula celula)
        {
            ItemSPE item = new ItemSPE(
                celula.GetString(_numeroLinha, 1),
                celula.GetString(_numeroLinha, 2),
                celula.GetString(_numeroLinha, 3),
                celula.GetString(_numeroLinha, 4),
                celula.GetString(_numeroLinha, 5),
                celula.GetString(_numeroLinha, 6),
                celula.GetString(_numeroLinha, 7),
                celula.GetString(_numeroLinha, 8),
                celula.GetString(_numeroLinha, 9),
                celula.GetString(_numeroLinha, 10),
                celula.GetString(_numeroLinha, 11),
                celula.GetString(_numeroLinha, 12),
                _book
                );

            _repoSPE.Inserir(item);


        }


    }
}
