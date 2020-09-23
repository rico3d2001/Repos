using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoAtividade
    {

        BaseMDBRepositorio<Atividade> _atividadesRepositorio;

        public RepoAtividade()
        {
            _atividadesRepositorio = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
        }

        public Atividade ObterDoItemCatalogado(ItemPipe itemDaFamilia)
        {
            Atividade atividade = null;

            if (itemDaFamilia.GUID_ATIVIDADE != null && itemDaFamilia.GUID_ATIVIDADE != "")
            {

                atividade = _atividadesRepositorio.Obter(itemDaFamilia.GUID_ATIVIDADE);
            }

            return atividade;
        }

        public List<Atividade> ObterTodas()
        {
            return _atividadesRepositorio.Obter();
        }

        public Atividade ObterDoNivelVVVporDescicao(string descricao)
        {
            var atividades = _atividadesRepositorio.Encontrar(
                          Builders<Atividade>.Filter.Eq(x => x.NivelAtividade, "VVV")
                          & Builders<Atividade>.Filter.Eq(x => x.Descricao, descricao));

            return atividades.Count() == 1 ? atividades.First() : null;
        }

        public void Modificar(Atividade atividade)
        {
            _atividadesRepositorio.Atualizar(atividade);
        }

        public List<Atividade> ObterPorEstado(string guidProjeto, string guidDisciplina)
        {
            RepoProjetos repoProjetos = new RepoProjetos();

            var projeto = repoProjetos.ObterProjeto(guidProjeto);

            return _atividadesRepositorio.Encontrar(
            Builders<Atividade>.Filter.Eq(x => x.GUID_CLIENTE, projeto.GUID_CLIENTE)
            & Builders<Atividade>.Filter.Eq(x => x.GUID_DISCIPLINA, guidDisciplina));
        }

        public Atividade ObterPorGuid(string guid)
        {
            return _atividadesRepositorio.Obter(guid);
        }
    
    }
}
