using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.Nucleo;
using Brass.Materiais.PQ.Entities.Montagens;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.TesteBulkload.Templates.MontagensXLS
{
    public class MontagemXLS : LeitoraPlanilha<Atividade>, ILeitoraPlanilha<Atividade>
    {
       

       
        string _GUID_DISCIPLINA;
        string _GUID_IDIOMA;
        string _GUID_CLIENTE;
        Versao _versao;
        List<NivelAtividade> _niveisAtividade;

        //Atividade _atividade_K;
        //Atividade _atividade_TT;
        //Atividade _atividade_UU;
        //Atividade _atividade_VVV;
        //Atividade _atividade_WWW;


        public MontagemXLS(string guidDisciplia, string guidCliente, string guidIdioma, Versao versao, int numeroLinha, List<NivelAtividade> niveisAtividade) : base(numeroLinha)
        {
            _lista = new List<Atividade>();
            _versao = versao;
            _niveisAtividade = niveisAtividade.OrderBy(x => x.Oredenador).ToList();
             _GUID_DISCIPLINA = guidDisciplia;
            _GUID_IDIOMA = guidIdioma;
            _GUID_CLIENTE = guidCliente;

            //_atividade_K = null;
            //_atividade_TT = null;
            //_atividade_UU = null;
            //_atividade_VVV = null;
            //_atividade_WWW = null;


        }

        protected override void LerPorLinha(Celula celula)
        {
            if (!string.IsNullOrEmpty(celula.GetString(_numeroLinha, 1)))
            {
               
                if (celula.GetString(_numeroLinha - 1, 1) != celula.GetString(_numeroLinha, 1))
                {
                    InserAtividade(celula, 1);
                }
                else if(celula.GetString(_numeroLinha - 1, 2) != celula.GetString(_numeroLinha, 2))
                {
                    InserAtividade(celula, 2);
                }
                else if (celula.GetString(_numeroLinha - 1, 3) != celula.GetString(_numeroLinha, 3))
                {
                    InserAtividade(celula, 3);
                }
                else if (celula.GetString(_numeroLinha - 1, 4) != celula.GetString(_numeroLinha, 4))
                {
                    InserAtividade(celula, 4);
                }
                else if (celula.GetString(_numeroLinha - 1, 5) != celula.GetString(_numeroLinha, 5))
                {
                    InserAtividade(celula, 5);
                }


            }
        }

        private void InserAtividade(Celula celula, int numeroColuna)
        {
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
            
                

            var atividade = new Atividade(
           _niveisAtividade[numeroColuna - 1].Nome,
           atividadeSuperior != null ? atividadeSuperior.GUID : "",
           _GUID_CLIENTE,
           _GUID_DISCIPLINA,
           _GUID_IDIOMA,
           _versao,
           celula.GetString(_numeroLinha, numeroColuna),
           celula.GetString(_numeroLinha, 6));

            _lista.Add(atividade);
        }
    }
}
