using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo.ViewModel;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo
{
    public class ObtemArvoreCatalogoQueryHandler : Notifiable, IRequestHandler<ObtemArvoreCatalogoQuery, RamalArvoreCatalogo[]>
    {

        //RepoRamalEstoque _repoRamalEstoque;
        RepoCatalogo _repoCatalogo;
        RepoTipoDeItem _repoTipoDeItem;
        RepoCategoria _repoCategoria;
        RepoFamilia _repoFamilia;

       



        public Task<RamalArvoreCatalogo[]> Handle(ObtemArvoreCatalogoQuery request, CancellationToken cancellationToken)
        {
            _repoCatalogo = new RepoCatalogo(request.TextoConexao);
            _repoTipoDeItem = new RepoTipoDeItem(request.TextoConexao);
            _repoCategoria = new RepoCategoria(request.TextoConexao);
            _repoFamilia = new RepoFamilia(request.TextoConexao);

            List<RamalArvoreCatalogo> ramalArvoreCatalogos = new List<RamalArvoreCatalogo>();

            var catalogos = _repoCatalogo.ObterPorGuidDisciplina(request.GuidDisciplina);


            foreach (var catalogo in catalogos)
            {
                var ramalCatalogo = new RamalArvoreCatalogo(catalogo.NOME, catalogo.GUID, "", 0);

                ramalArvoreCatalogos.Add(ramalCatalogo);


              
                var categorias = _repoCategoria.ObterPorCatalogo(catalogo);
                foreach (var categoria in categorias)
                {
                 
                    var tipoItemEng = _repoTipoDeItem.ObterPorGuid(categoria.GUID_TIPO);
                    var ramalCategoria = new RamalArvoreCatalogo(tipoItemEng.NOME, categoria.GUID, catalogo.GUID, 1);
                    ramalCatalogo.Adiciona(ramalCategoria);

                     
                    var familias = _repoFamilia.ObterPorCategoria(categoria);
                    foreach (var familia in familias)
                    {
                        var ramalFamilia = new RamalArvoreCatalogo(familia.PartFamilyLongDesc.VALOR, familia.GUID, categoria.GUID, 2);
                        ramalCategoria.Adiciona(ramalFamilia);
                    }
                }
            }



            //var ramal = _ramalEstoqueRepositorio.Obter();

            //return new CommandResult<RamalArvoreCatalogo>(true, "Areas requisitados com sucesso.", ramais);
            return Task.FromResult(ramalArvoreCatalogos.ToArray());
        }
    }
}
