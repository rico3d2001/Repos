using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoItemModelado : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<ItemModelado> _repositorioItemModelado;
        public RepoItemModelado(string conectionString) : base(conectionString)
        {
            _repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>(new ConexaoMongoDb("BIM_TESTE", conectionString), "ItensModelados");
        }

        public void InserirItemModelado(ItemModelado itemModel)
        {
            _repositorioItemModelado.Inserir(itemModel);
        }

        public List<ItemModelado> ObterItensModeladosDoProjeto(string guidProjeto)
        {
            return _repositorioItemModelado.Encontrar(
                   Builders<ItemModelado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));
        }

        public void Cadastrar(ItemModelado itemModelado) //, NumeroAtivo numeroAtivo)
        {
            

            _repositorioItemModelado.Inserir(itemModelado);


        }

    }
}
