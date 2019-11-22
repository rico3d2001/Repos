using Brass.Materiais.Dominio.ValueObjects.Linguagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Descricoes
{
    public class GrupoDescricoes: ValueObject
    {
        public GrupoDescricoes(Idioma idioma, DescricaoFamilia descricaoFamilia, DescricaoDimensao descricaoDimensao, DescricaoCurta descricaoCurta, DescricaoLonga descricaoLonga)
        {
            Idioma = idioma;
            DescricaoFamilia = descricaoFamilia;
            DescricaoDimensao = descricaoDimensao;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
        }

        public Idioma Idioma { get; set; }
        public DescricaoFamilia DescricaoFamilia { get; set; }
        public DescricaoDimensao DescricaoDimensao { get; set; }
        public DescricaoCurta DescricaoCurta { get; set; }
        public DescricaoLonga DescricaoLonga { get; set; }
    }

}
