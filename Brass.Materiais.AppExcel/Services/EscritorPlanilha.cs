using Brass.Materiais.AppExcel.Interfaces;
using Brass.Materiais.AppExcel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Services
{
    public abstract class EscritorPlanilha<T> : IEscritoraPlanilha
    {

        protected PlanilhaPQ<T> _planilha;



        protected int _numeroLinha;
        public EscritorPlanilha(PlanilhaPQ<T> planilha)
        {
            _planilha = planilha;

        }


        public void Escrever(Worksheet wsPlanilha)
        {
            var celula = new Celula(wsPlanilha);

            foreach (var item in _planilha.Linhas)
            {
                EscreverPorLinha(item, celula);
                _numeroLinha++;
            }

        }

        protected abstract void PreencherCabecalho(T item, Celula celula);

        protected abstract void EscreverPorLinha(T item, Celula celula);

    }
}
