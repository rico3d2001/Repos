using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoAtividade: RepositorioAbstratoGeral
    {

        BaseMDBRepositorio<Atividade> _atividadesRepositorio;

        public RepoAtividade(string conectionString) : base(conectionString)
        {
            
            _atividadesRepositorio = new BaseMDBRepositorio<Atividade>(new ConexaoMongoDb("MontagemPQ", conectionString), "Atividade");
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

        public string ObterSiglaPrimeiraAtividade(ItemPipe itemPipe)
        {

            if (itemPipe.GUID_ATIVIDADE == null) return "X";

            try
            {
                var atividadeWWW = _atividadesRepositorio.Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID, itemPipe.GUID_ATIVIDADE)).FirstOrDefault();
                if (atividadeWWW == null) return "X";
                var atividadeVVV = _atividadesRepositorio.Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID, atividadeWWW.GUID_PAI)).FirstOrDefault();
                if (atividadeVVV == null) return "X";
                var atividadeUU = _atividadesRepositorio.Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID, atividadeVVV.GUID_PAI)).FirstOrDefault();
                if (atividadeUU == null) return "X";
                var atividadeTT = _atividadesRepositorio.Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID, atividadeUU.GUID_PAI)).FirstOrDefault();
                if (atividadeTT == null) return "X";
                var atividadeK = _atividadesRepositorio.Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID, atividadeTT.GUID_PAI)).FirstOrDefault();
                if (atividadeK == null) return "X";

                return atividadeK.Codigo;
            }
            catch (Exception)
            {

                throw;
            }

           
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
            RepoProjetos repoProjetos = new RepoProjetos(_conectionString);

            var projeto = repoProjetos.ObterProjeto(guidProjeto);

            return _atividadesRepositorio.Encontrar(
            Builders<Atividade>.Filter.Eq(x => x.GUID_CLIENTE, projeto.GUID_CLIENTE)
            & Builders<Atividade>.Filter.Eq(x => x.GUID_DISCIPLINA, guidDisciplina));
        }

        public void Apagar(Atividade atividade)
        {
            _atividadesRepositorio.Remover(atividade);
        }

        public Atividade ObterPorGuid(string guid)
        {
            return _atividadesRepositorio.Obter(guid);
        }

        public void CatadastarAtividade(Atividade atividade)
        {
            _atividadesRepositorio.Inserir(atividade);
        }

        public List<Atividade> ObterListaPorIdentidade(IdentidadeAtividade identidadeAtividade)
        {
            return _atividadesRepositorio
               .Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID_CLIENTE, identidadeAtividade.GUID_CLIENTE)
                           & Builders<Atividade>.Filter.Eq(x => x.GUID_IDIOMA, identidadeAtividade.GUID_IDIOMA)
                           & Builders<Atividade>.Filter.Eq(x => x.GUID_DISCIPLINA, identidadeAtividade.GUID_DISCIPLINA));
        }
    
    }
}
