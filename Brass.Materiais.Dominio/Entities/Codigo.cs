using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class Codigo:Entidade
    {
        public Codigo(string gUID_CLIENTE, string gUID_PROPRIEDADE, string gUID_NOME, string nome, string gUID_VALOR, string valor, string gUID_CODIGO, bool codificado)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            GUID_PROPRIEDADE = gUID_PROPRIEDADE;
            GUID_NOME = gUID_NOME;
            Nome = nome;
            GUID_VALOR = gUID_VALOR;
            Valor = valor;
            GUID_CODIGO = gUID_CODIGO;
            Codificado = codificado;
        }

        public string GUID_CLIENTE { get; set; }
        public string GUID_PROPRIEDADE { get; set; }
        public string GUID_NOME { get; set; }
        public string Nome { get; set; }
        public string GUID_VALOR { get; set; }
        public string  Valor { get; set; }
        public string GUID_CODIGO { get; set; }
        public bool Codificado { get; set; }
        public string Valor_Codigo { get; set; }
        
    }
}
