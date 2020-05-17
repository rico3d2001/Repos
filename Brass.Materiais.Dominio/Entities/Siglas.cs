using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Dominio.ValueObjects.Siglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class Siglas: Entidade
    {
            public Siglas(string definicao, string gUID_CLIENTE)
            {
                Definicao = definicao;
                GUID_CLIENTE = gUID_CLIENTE;
                Lista = new List<SiglaCodigo>();
            }

            public void AdicionaSigla(SiglaCodigo sigla)
            {
                Lista.Add(sigla);
            }

            public List<SiglaCodigo> Lista { get; private set; }
            public string Definicao { get; set; }
            public string GUID_CLIENTE { get; set; }
        
    }
}
