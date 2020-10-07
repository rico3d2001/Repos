using Brass.Materiais.DominioPQ.BIM.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoProjetos : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<Projeto> _repoProjetos;


        public RepoProjetos(string conectionString) : base(conectionString)
        {
            _repoProjetos = new BaseMDBRepositorio<Projeto>(new ConexaoMongoDb("BIM", conectionString), "Projetos");

        }

        public List<Projeto> ObterTodos()
        {
           return _repoProjetos.Obter();
        }

        public void Modificar(Projeto projeto)
        {
            _repoProjetos.Atualizar(projeto);
        }

        public void Cadastrar(Projeto projeto)
        {
            _repoProjetos.Inserir(projeto);
        }

        public Projeto ObterProjeto(string guidProjeto)
        {
            return _repoProjetos.Obter(guidProjeto);
        }

        public List<Projeto> ObterProjetosVPN()
        {
            return _repoProjetos.Encontrar(
                Builders<Projeto>.Filter.Eq(x => x.Origem, "VPN"));
        }

        public void DefinirTipoVPN(Projeto projeto)
        {
            projeto.Origem = "VPN";
            _repoProjetos.Atualizar(projeto);
        }
    }
}
