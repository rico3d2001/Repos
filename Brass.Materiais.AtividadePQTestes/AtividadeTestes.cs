using System;
using System.Linq;
using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.PQ.Entities.Montagens;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace Brass.Materiais.AtividadePQTestes
{
    [TestClass]
    public class AtividadeTestes
    {
        [TestMethod]
        public void DeveAssociarAtividadeComItemPQ()
        {

            var tipoItemDiag = "TUBO";
            var codigo = "M"; //Codigo para montagem


            var repositorioTipoItemEng = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");
            var repositorioNivelAtividade = new BaseMDBRepositorio<NivelAtividade>("MontagemPQ", "NivelAtividade");
            var repositorioAtividade = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");

            var niveisAtividades = repositorioNivelAtividade.Obter();


            var tipos = repositorioTipoItemEng.Encontrar(Builders<TipoItemEng>.Filter.Eq(x => x.NOME, tipoItemDiag));

            if(tipos.Count == 1)
            {
                var tipo = tipos.First();

                foreach (var nivel in niveisAtividades)
                {
                    var atividades = repositorioAtividade.Encontrar(
                        Builders<Atividade>.Filter.Eq(x => x.NivelAtividade, nivel.Nome));
                        //& Builders<Atividade>.Filter.Eq(x => x.Codigo, codigo));

                }



            }



        }
    }
}
