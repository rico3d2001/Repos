using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoDapperSQLServer.Service;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppVPN.QuerySide.ObterAreasTags
{
    public class ObterAreasTagsQueryHandler : Notifiable, IRequestHandler<ObterAreasTagsQuery, List<NumeroAtivo>>
    {
        RepoProjetos _repoProjetos;
        RepoNumerosAtivos _repoAtivos;
        List<NumeroAtivo> _ativos;





        public Task<List<NumeroAtivo>> Handle(ObterAreasTagsQuery request, CancellationToken cancellationToken)
        {

            _repoProjetos = new RepoProjetos(request.TextoConexao);
            _repoAtivos = new RepoNumerosAtivos(request.TextoConexao);


            _ativos = new List<NumeroAtivo>();

            var projeto = _repoProjetos.ObterProjeto(request.GuidProjeto);


            var dataBaseProjeto = $"_{projeto.Sigla.ToLower()}_PnId";

            var linhas = LinhasPipeSQL.GetLinhasProjeto(dataBaseProjeto);

     

            foreach (var linha in linhas)
            {
                var tag = linha["Tag"].ToString();

                if (compativelComormatoDeArea(tag))
                {
                    var areaTag = AreaTag.ObterDoTag(projeto.GUID, tag);
                    var numeroAtivo = new NumeroAtivo(areaTag, TipoAtivo.ObterDoTag(tag));

                    if (areaNaoFoiColetada(numeroAtivo))
                    {
                        _ativos.Add(numeroAtivo);
                    }

                }

            }


            foreach (var ativo in _ativos)
            {
                _repoAtivos.Cadastrar(ativo);

            }




            return Task.FromResult(_ativos);
        }



        private bool areaNaoFoiColetada(NumeroAtivo numeroAtivo)
        {
            var ativos = _ativos.Where(x => x.Equals(numeroAtivo));
            if (ativos.Count() > 0)
            {
                return false;
            }

            return true;
        }

        private bool compativelComormatoDeArea(string tag)
        {
            var parteDoTagRefereAoAtivo = tag.Split('-').First();

            return parteDoTagRefereAoAtivo.Length == 6 ? true : false;


        }
    }
}
