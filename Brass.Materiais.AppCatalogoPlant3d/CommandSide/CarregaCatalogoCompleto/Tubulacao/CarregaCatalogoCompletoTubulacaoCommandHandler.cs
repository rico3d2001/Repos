using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.Nucleo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Brass.Materiais.ServicoDominio.Fabrica;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Tubulacao
{
    public class CarregaCatalogoCompletoTubulacaoCommandHandler : Notifiable, IRequestHandler<CarregaCatalogoCompletoTubulacaoCommand>
    {

      
  
        public async Task<Unit> Handle(CarregaCatalogoCompletoTubulacaoCommand command, CancellationToken cancellationToken)
        {

            RepoDisciplinas repoDisciplinas = new RepoDisciplinas(command.Conexao);
            Disciplina disciplina = repoDisciplinas.ObterPorGuid(command.GuidDisciplina);

            var construtorCatalogo = new ConstrutorCatalogo(
                command.Endereco.Split('\\').Last().Split('.').First(),
                command.Lingua,
                command.Pais,
                disciplina,
                command.Conexao);

            construtorCatalogo.InjetarDoSQLitePlant3d(command.EngineeringItems);

            return Unit.Value;
        }

   




    }
}
