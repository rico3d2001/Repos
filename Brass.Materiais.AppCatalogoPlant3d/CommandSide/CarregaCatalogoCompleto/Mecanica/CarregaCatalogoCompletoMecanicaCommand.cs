using Brass.Materiais.AppNetCoreUtil;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Mecanica
{
    public class CarregaCatalogoCompletoMecanicaCommand : Notifiable, IRequest<Response>
    {
        public CarregaCatalogoCompletoMecanicaCommand(string nomeCatalogo, string idioma, string pais, string guidDisciplina, string conexao)
        {
            NomeCatalogo = nomeCatalogo;
            Idioma = idioma;
            Pais = pais;
            GuidDisciplina = guidDisciplina;
            TextoConexao = conexao;
            //QueryEquipment_PNP_SQL = Equipment_PNP_SQL.GetAllEquipment_PNP(nomeCatalogo,conexao);
        }

        public string NomeCatalogo { get; set; }
        public string NomeCategoria { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }
        public string GuidDisciplina { get; set; }
        public List<Dictionary<object, object>> QueryEquipment_PNP_SQL { get; set; }
        public string TextoConexao { get; set; }

    }
}
