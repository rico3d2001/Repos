using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.InterfaceExcel.Comandos;
using Brass.Materiais.InterfaceExcel.Interface;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppBulkLoad.Models
{
    public class SPEBulkLoad : LeitoraPlanilha<ItemSPE>, ILeitoraPlanilha<ItemSPE>
    {
        //RepoSPE _repoSPE;
        SPEBook _book;
        public SPEBulkLoad(int numeroLinha, SPEBook book, string conexao) : base(numeroLinha)
        {
            //_repoSPE = new RepoSPE(conexao);
            _book = book;
        }

        protected override void LerPorLinha(Celula celula)
        {
            ItemSPE item = new ItemSPE(
                celula.GetString(_numeroLinha, 1),
                celula.GetString(_numeroLinha, 2),
                celula.GetString(_numeroLinha, 3),
                celula.GetString(_numeroLinha, 4),
                celula.GetString(_numeroLinha, 5),
                celula.GetString(_numeroLinha, 6),
                celula.GetString(_numeroLinha, 7),
                celula.GetString(_numeroLinha, 8),
                celula.GetString(_numeroLinha, 9),
                celula.GetString(_numeroLinha, 10),
                celula.GetString(_numeroLinha, 11),
                celula.GetString(_numeroLinha, 12),
                _book
                );

            //_repoSPE.Cadastrar(item);

            _lista.Add(item);

        }


    }
}
