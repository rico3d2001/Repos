using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoDoSPE
{
    public class CarregaCatalogoDoSPECommand : Notifiable, IRequest
    {
        public CarregaCatalogoDoSPECommand(string nomeCatalogo, string idioma, string pais, string conexao, string guidDisciplina)
        {
            NomeCatalogo = nomeCatalogo;
            Idioma = idioma;
            Pais = pais;
            Conexao = conexao;
            GuidDisciplina = guidDisciplina;
        }

        public string NomeCatalogo { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }
        public string Conexao { get; set; }
        public string GuidDisciplina { get; set; }
    }
}
