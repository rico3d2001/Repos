using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;

namespace Brass.Materiais.Dominio.ValueObjects.Descricoes
{
    public class DescricaoCurta : ValueObject
    {
        public DescricaoCurta(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
