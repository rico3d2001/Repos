using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.Nucleo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Brass.Materiais.ServicoDominio.Fabrica
{
    public class ConstrutorCatalogo
    {
        CatalogoEntidade _catalogo;

        string _conexaoMongoDB;
        public ConstrutorCatalogo(string nomeCatalogo, string lingua, string pais, Disciplina disciplina, string conexaoMongoDB)
        {
            _conexaoMongoDB = conexaoMongoDB;

            Idioma idioma = defineIdioma(lingua, pais);



            _catalogo = defineCatalogo(nomeCatalogo, idioma, disciplina);
        }


        public void IncluirDiametroNominal(List<EngineeringItems> engineeringItems)
        {
            foreach (var item in engineeringItems)
            {
                RepoItemPipe repoItemPipe = new RepoItemPipe(_conexaoMongoDB);


                var itemPipeEstoque = repoItemPipe.ObterPorPnPIDComCatalogo((int)item.PnPID, _catalogo.GUID);

                if(itemPipeEstoque.GUID_ATIVIDADE != null)
                {
                    itemPipeEstoque.NominalDiameter = item.NominalDiameter;
                }

                //itemPipeEstoque.NominalDiameter = item.NominalDiameter;

                //repoItemPipe.Modificar(itemPipeEstoque);
            }
        }

        public void IncluirPeso(List<EngineeringItems> engineeringItems)
        {
            foreach (var item in engineeringItems)
            {
                RepoItemPipe repoItemPipe = new RepoItemPipe(_conexaoMongoDB);


                var itemPipeEstoque = repoItemPipe.ObterPorPnPIDComCatalogo((int)item.PnPID, _catalogo.GUID);

                //if (itemPipeEstoque.GUID_ATIVIDADE != null)
                //{
                    itemPipeEstoque.Weigth = item.Weight;
                //}

                itemPipeEstoque.NominalDiameter = item.NominalDiameter;

                repoItemPipe.Modificar(itemPipeEstoque);
            }
        }

        private Idioma defineIdioma(string lingua, string pais)
        {
            var repoIdioma = new RepoIdioma(_conexaoMongoDB);
            var idioma = repoIdioma.ObterIdiomaPorLinguaPais(lingua, pais);
            if (idioma == null)
            {
                idioma = new Idioma(lingua, pais);
                repoIdioma.Cadastrar(idioma);
            }

            return idioma;
        }

       

        private CatalogoEntidade defineCatalogo(string nomeCatalogo, Idioma idioma, Disciplina disciplina)
        {
            var repoCatalogo = new RepoCatalogo(_conexaoMongoDB);
            var catalogo = repoCatalogo.ObterPorNome(nomeCatalogo);
            if (catalogo == null)
            {
                catalogo = new CatalogoEntidade(idioma.GUID, nomeCatalogo, disciplina.GUID);
                repoCatalogo.CadastrarCatalogo(catalogo);
            }

            return catalogo;
        }

        public void InjetarDoSQLitePlant3d(List<EngineeringItems> engineeringItems)
        {

            //var repoItemPipe = new RepoItemPipe(_conexaoMongoDB);

            //int conta = repoItemPipe.ObterTodos().Count();

            //if (conta < engineeringItems.Count())
            //{
            foreach (var item in engineeringItems)
            {
                var nomeFamilia = defineNomeFamilia(item.PartFamilyLongDesc);

                var tipoDeItem = defineTipoDeItem(item.PartCategory);

                var categoria = definirCategoria(_catalogo, tipoDeItem);


                var familia = defineFamilia(categoria, nomeFamilia, item.PartFamilyId.ToString());

                defineItens(item, familia, tipoDeItem);
            }
            //}

        }

        private ValorTabelado defineNomeFamilia(string partFamilyLongDesc)
        {
          

            RepoValores repoValores = RepoValores.Instancia(_conexaoMongoDB);

            var valor = repoValores.ObterDescricao(partFamilyLongDesc);

            if(valor == null)
            {
                valor = new ValorTabelado(partFamilyLongDesc, "");
                repoValores.CadastrarValor(valor);
            }

            return valor;
        }

        

        private Familia defineFamilia(Categoria categoria, ValorTabelado valor, string partFamilyId)
        {

            RepoFamilia repoFamilia = new RepoFamilia(_conexaoMongoDB);

            var familia = repoFamilia.ObterFamiliaPorValor(valor);


            if (familia == null)
            {
                familia = new Familia(_catalogo.GUID, categoria.GUID, valor, partFamilyId);
                repoFamilia.Cadastrar(familia);
            }

            return familia;
        }

        private TipoItemEng defineTipoDeItem(string oBaseTable)
        {
            RepoTipoDeItem repoTipoDeItem = new RepoTipoDeItem(_conexaoMongoDB);

            var tipoItemEng = repoTipoDeItem.ObterPorNome(oBaseTable);

            if (tipoItemEng == null)
            {
                tipoItemEng = new TipoItemEng(oBaseTable);
                repoTipoDeItem.CadastrarTipo(tipoItemEng);
            }

            return tipoItemEng;
        }

        private Categoria definirCategoria(CatalogoEntidade catalogo, TipoItemEng tipoDeItemEngenharia)
        {
            RepoCategoria repoCategoria = new RepoCategoria(_conexaoMongoDB);

            var categoria =
                repoCategoria.ObterPorTipoDeItem(tipoDeItemEngenharia);
            if (categoria == null)
            {
                categoria = new Categoria(catalogo.GUID, tipoDeItemEngenharia.GUID);
                repoCategoria.CadastrarCategoria(categoria);
            }

            return categoria;
        }

        private void defineItens(EngineeringItems item, Familia familia, TipoItemEng tipoItemEng)
        {
            RepoItemPipe repoItemPipe = new RepoItemPipe(_conexaoMongoDB);

            var itemPipeEstoque = repoItemPipe.ObterPorPnPIDComCatalogo((int)item.PnPID, _catalogo.GUID);

            if (itemPipeEstoque == null)
            {


                var itemPipe = new ItemPipe(tipoItemEng.GUID, _catalogo.GUID, _catalogo.GUID, (int)item.PnPID,familia.GUID,familia.PartFamilyId,item.NominalDiameter, item.Weight);

                repoItemPipe.CadastrarItemPipe(itemPipe);

                Type type = item.GetType();

                foreach (var info in type.GetProperties())
                {
                    if (SeInformacaodeParaPropriedade(info))
                    {
                        definePropriedade(item, itemPipe, info);
                    }

                }

               






            }
        }

        private static bool SeInformacaodeParaPropriedade(PropertyInfo info)
        {
            return info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID";
        }

        private void definePropriedade(EngineeringItems item, ItemPipe itemPipe, PropertyInfo info)
        {
          
                NomeTipoPropriedade nomeTipoPropriedade = defineNomeDoTipoDePropriedade(info.Name);

                var valor = info.GetValue(item, null);

                if (valor != null)
                {
                    ValorTabelado valorTabelado = defineValorTabelado(valor);

                    PropriedadeItem propriedadeEng = definePropriedadeDoItem(nomeTipoPropriedade, valorTabelado);

                    var relacaoPropriedadeItem = new RelacaoPropriedadeItem(propriedadeEng.GUID, itemPipe.GUID);

                    RepoRelacaoPropriedadeItem repoRelacaoPropriedadeItem = new RepoRelacaoPropriedadeItem(_conexaoMongoDB);
                    repoRelacaoPropriedadeItem.Cadastrar(relacaoPropriedadeItem);


                }
            
        }

        private PropriedadeItem definePropriedadeDoItem(NomeTipoPropriedade nomeTipoPropriedade, ValorTabelado valorTabelado)
        {
            RepoPropriedadeItem repoPropriedadeItem = new RepoPropriedadeItem(_conexaoMongoDB);
            var propriedadeEng = repoPropriedadeItem.ObterPorTipoMaisValor(nomeTipoPropriedade.GUID, valorTabelado.GUID);

            if (propriedadeEng == null)
            {
                propriedadeEng = new PropriedadeItem(nomeTipoPropriedade.GUID, valorTabelado.GUID);
                repoPropriedadeItem.Cadastrar(propriedadeEng);
            }

            return propriedadeEng;
        }

        private NomeTipoPropriedade defineNomeDoTipoDePropriedade(string nomeDoTipo)
        {
            RepoNomeTipoPropriedade repoNomeTipoPropriedade = new RepoNomeTipoPropriedade(_conexaoMongoDB);
            var nomeTipoPropriedade = repoNomeTipoPropriedade.ObterPorNome(nomeDoTipo);

            if (nomeTipoPropriedade == null)
            {
                nomeTipoPropriedade = new NomeTipoPropriedade(nomeDoTipo);
                repoNomeTipoPropriedade.CadastrarNomeTipoPropriedade(nomeTipoPropriedade);
            }

            return nomeTipoPropriedade;
        }

        private ValorTabelado defineValorTabelado(object valor)
        {
            RepoValores repoValores = RepoValores.Instancia(_conexaoMongoDB);
            var valorTabelado = repoValores.ObterDescricao(valor.ToString());

            if (valorTabelado == null)
            {
                valorTabelado = new ValorTabelado(valor.ToString(), "");
                repoValores.CadastrarValor(valorTabelado);
            }

            return valorTabelado;
        }
    }
}
