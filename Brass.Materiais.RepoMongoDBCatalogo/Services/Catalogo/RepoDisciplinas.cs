using Brass.Materiais.Nucleo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoDisciplinas : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<Disciplina> _repoDisciplinas;
        public RepoDisciplinas(string conectionString) : base(conectionString)
        {
            _repoDisciplinas = new BaseMDBRepositorio<Disciplina>(new ConexaoMongoDb("MontagemPQ", conectionString), "Disciplina");
        }

        public List<Disciplina> ObterTodasDisciplinas()
        {
            return _repoDisciplinas.Obter();
        }

        public void Cadastrar(Disciplina disciplina)
        {
            _repoDisciplinas.Inserir(disciplina);
        }
    }
}
