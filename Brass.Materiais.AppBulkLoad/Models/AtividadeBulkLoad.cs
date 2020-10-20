using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.InterfaceExcel.Comandos;
using Brass.Materiais.InterfaceExcel.Interface;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.AppBulkLoad.Models
{
    public class AtividadeBulkLoad : LeitoraPlanilha<Atividade>, ILeitoraPlanilha<Atividade>
    {
        IdentidadeAtividade _identidadeAtividade;
        Versao _versao;
        List<NivelAtividade> _niveisAtividade;
        RepoAtividade _repoAtividade;

        public AtividadeBulkLoad(IdentidadeAtividade identidadeAtividade, Versao versao, List<NivelAtividade> niveisAtividade, string conexao, int numeroLinha) : base(numeroLinha)
        {
            _identidadeAtividade = identidadeAtividade;

            _repoAtividade = new RepoAtividade(conexao);

            var lista = _repoAtividade.ObterTodas();
            if (lista.Count > 0)
            {
                _lista = lista;
            }
            else
            {
                _lista = new List<Atividade>();
            }

            _versao = versao;
            _niveisAtividade = niveisAtividade.OrderBy(x => x.Oredenador).ToList();
        }



        protected override void LerPorLinha(Celula celula)
        {
            var ultima = _lista.Last();
            

            var descricao = celula.GetString(_numeroLinha, 6);

            var teste = _lista.FirstOrDefault(x => x.Descricao == descricao);

            

            if (descricao == "Ar Condicionado tipo Split")
            {
                descricao = celula.GetString(_numeroLinha, 6);

                var clouna1 = celula.GetString(_numeroLinha - 1, 5);
                var cloluna2 = celula.GetString(_numeroLinha, 5);

                _lista.Remove(teste);

                _repoAtividade.Apagar(teste);
            }

            

            if (!string.IsNullOrEmpty(celula.GetString(_numeroLinha, 1)))
            {

                if (PermiteInsercao(celula, 1, descricao))
                {

                    var clouna1 = celula.GetString(_numeroLinha - 1, 1);
                    var cloluna2 = celula.GetString(_numeroLinha, 1);

                    InserAtividade(celula, 1);
                }
                else if (PermiteInsercao(celula, 2, descricao))
                {

                    var clouna1 = celula.GetString(_numeroLinha - 1, 2);
                    var cloluna2 = celula.GetString(_numeroLinha, 2);

                    InserAtividade(celula, 2);
                }
                else if (PermiteInsercao(celula, 3, descricao))
                {
                    var clouna1 = celula.GetString(_numeroLinha - 1, 3);
                    var cloluna2 = celula.GetString(_numeroLinha, 3);


                    InserAtividade(celula, 3);
                }
                else if (PermiteInsercao(celula, 4, descricao))
                {

                    var clouna1 = celula.GetString(_numeroLinha - 1, 4);
                    var cloluna2 = celula.GetString(_numeroLinha, 4);

                    InserAtividade(celula, 4);
                }
                else if (PermiteInsercao(celula, 5, descricao))
                {

                    var clouna1 = celula.GetString(_numeroLinha - 1, 5);
                    var cloluna2 = celula.GetString(_numeroLinha, 5);

                    InserAtividade(celula, 5);
                }
 
            }
        }

        private bool PermiteInsercao(Celula celula, int numeroColuna, string descricao)
        {
            return celula.GetString(_numeroLinha - 1, numeroColuna) != celula.GetString(_numeroLinha, numeroColuna) &&
                _lista.FirstOrDefault(x => x.Descricao == descricao) == null;
        }

        private void InserAtividade(Celula celula, int numeroColuna)
        {
            var descricao = celula.GetString(_numeroLinha, 6);

            

            Atividade atividadeSuperior = null;
            if (numeroColuna > 1)
            {
                var nivelAtividadeAnterior = _niveisAtividade[numeroColuna - 2].Nome;
                atividadeSuperior = _lista.Last(x => x.NivelAtividade == nivelAtividadeAnterior);
            }
            else
            {
                atividadeSuperior = null;
            }

            var atividadeEncontrada = _lista.FirstOrDefault(x => x.Descricao == descricao && x.GUID_PAI == atividadeSuperior.GUID);

            Atividade atividade = null;

            if (atividadeEncontrada != null)
            {
                atividade = atividadeEncontrada;

                var GUID_PAI = atividade.GUID_PAI;

                if (GUID_PAI != atividadeSuperior.GUID)
                {
                    atividade.GUID_PAI = GUID_PAI;
                }

                _repoAtividade.Modificar(atividade);

                _lista[_lista.FindIndex(x => x.GUID == atividade.GUID)] = atividade;

            }
            else
            {




                atividade = new Atividade(_identidadeAtividade,
                  _niveisAtividade[numeroColuna - 1].Nome,
                  atividadeSuperior != null ? atividadeSuperior.GUID : "",
                  _versao,
                  celula.GetString(_numeroLinha, numeroColuna),
                  celula.GetString(_numeroLinha, 6),
                  celula.GetString(_numeroLinha, 11));

                _repoAtividade.CatadastarAtividade(atividade);

            }

            _lista.Add(atividade);
        }
    }
}
