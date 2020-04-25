using Brass.Materiais.Dominio.Formatacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.ValoresCodigo
{
    public class Sigla:ValueObject
    {
        private IFormatacao _formatacao;
        

        public Sigla(string valor, int numeroCaracteres, IFormatacao formatacao)
        {
            _formatacao = formatacao;
            Valor = _formatacao.Formatar(valor, numeroCaracteres);
            //DimensaoMilimetro = dimensaoMilimetro;
        }

        public string Valor { get; private set; }
        public IFormatacao Formato { get; private set; }

        //public double? DimensaoMilimetro { get; private set; }

    }
}
