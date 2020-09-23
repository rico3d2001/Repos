using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoComumPlantEF.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppBIM360.QuerySide.ObterAreasTagsQueryBIM360
{
    public class ObterAreasTagsQueryBIM360QueryHandler : Notifiable, IRequestHandler<ObterAreasTagsQueryBIM360Query, List<AreaPlanejada>>
    {
        BaseMDBRepositorio<Projeto> _repoProjetos;
        RepoAreasPlanejadas _repoAreasPlanejadas;
        List<AreaPlanejada> _areas;
        RepoEAP _repoEAP;
        public ObterAreasTagsQueryBIM360QueryHandler()
        {
            _repoEAP = new RepoEAP();
            _repoProjetos = new BaseMDBRepositorio<Projeto>("BIM", "Projetos");
            _repoAreasPlanejadas = new RepoAreasPlanejadas();//new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            
        }



        public Task<List<AreaPlanejada>> Handle(ObterAreasTagsQueryBIM360Query request, CancellationToken cancellationToken)
        {
            _areas = _repoAreasPlanejadas.EncontrarAreasPlanejadasPorProjeto(request.GuidProjeto);

            var projeto = _repoProjetos.Obter(request.GuidProjeto);

          
            var dataBaseProjeto = $"{projeto.Endereco}\\ProcessPower.dcf";

            BIM360DataContext bIM360DataContext = new BIM360DataContext(dataBaseProjeto, "BIM360", "");
            var pipeLinesRecordRepositorio = new PipeLineRecordRepositorio(bIM360DataContext);

            var linhas = pipeLinesRecordRepositorio.GetAll();

            Versao versao = new Versao(0, "Interface Configurador", "Teste", DateTime.Now);

            foreach (var linha in linhas)
            {
                var tag = linha.Tag;

                var tagSeperado = tag.Split('-');

                foreach (var parteDoTag in tagSeperado)
                {
                    if (compativelComormatoDeArea(parteDoTag))
                    {
                        var area = parteDoTag.Substring(0, 2);
                        var subArea = parteDoTag.Substring(2, 2);

                        if (areaNaoFoiColetada(area, subArea))
                        {
                            _areas.Add(new AreaPlanejada(projeto.GUID, area, subArea, projeto.Sigla, "", versao));
                        }

                    }

                }

            }

            if (projeto.GUID_CLIENTE == "89624309-b026-4c17-bab1-8c4f4d9cbc90")
            {
                var c = "c";
            }
            else
            {
                


               



                

               
            }

           

            if (_areas.Count() == 1)
            {
                var areaUnica = _areas.First();
                areaUnica.Nome = projeto.NomeProjeto;
                _repoAreasPlanejadas.Cadastrar(areaUnica);
                //_repoEAP.CadastrarEAPAreaUnica(areaUnica,projeto);
            }
            else
            {
                foreach (var area in _areas)
                {
                    _repoAreasPlanejadas.Cadastrar(area);
                    //_repoEAP.CadastrarEAPAreaUnica(area, projeto);
                }
            }



            return Task.FromResult(_areas);
        }







        private bool areaNaoFoiColetada(string area, string subArea)
        {
            var areas = _areas.Where(x => x.Area == area && x.SubArea == subArea);
            if (areas.Count() > 0)
            {
                return false;
            }

            return true;
        }

        private bool compativelComormatoDeArea(string parteDoTag)
        {
            if (parteDoTag.Length >= 4 && parteDoTag.Length <= 6)
            {
                int teste;
                if (int.TryParse(parteDoTag.Substring(0, 2), out teste) && int.TryParse(parteDoTag.Substring(2, 2), out teste))
                {
                    return true;
                }

                return false;

            }
            else
            {
                return false;
            }
        }
    }
}
