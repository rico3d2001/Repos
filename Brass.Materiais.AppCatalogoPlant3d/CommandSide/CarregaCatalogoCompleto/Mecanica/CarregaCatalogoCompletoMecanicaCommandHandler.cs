using Brass.Materiais.AppNetCoreUtil;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Mecanica
{
    public class CarregaCatalogoCompletoMecanicaCommandHandler : Notifiable, IRequestHandler<CarregaCatalogoCompletoMecanicaCommand, Response>
    {
        RepoCatalogo _repoCatalogo;
        RepoIdioma _idiomaMDBRepositorio;
        RepoItemPipe _repoItemPipe;
        RepoCategoria _repoCategoria;
        RepoTipoDeItem _repoTipoDeItem;
        RepoFamilia _repoFamilia;
        RepoNomeTipoPropriedade _repoNomeTipoPropriedade;
        RepoPropriedadeItem _repoPropriedadeItem;
        RepoRelacaoPropriedadeItem _repoRelacaoPropriedadeItem;


       

        public Task<Response> Handle(CarregaCatalogoCompletoMecanicaCommand command, CancellationToken cancellationToken)
        {
            _repoCatalogo = new RepoCatalogo(command.TextoConexao);
            _idiomaMDBRepositorio = new RepoIdioma(command.TextoConexao);
            _repoItemPipe = new RepoItemPipe(command.TextoConexao);
            _repoCategoria = new RepoCategoria(command.TextoConexao);
            _repoFamilia = new RepoFamilia(command.TextoConexao);
            _repoTipoDeItem = new RepoTipoDeItem(command.TextoConexao);
            _repoNomeTipoPropriedade = new RepoNomeTipoPropriedade(command.TextoConexao);
            _repoPropriedadeItem = new RepoPropriedadeItem(command.TextoConexao);
            _repoRelacaoPropriedadeItem = new RepoRelacaoPropriedadeItem(command.TextoConexao);


            Response response = new Response(null, false);

            var catalogo = defineCatalogo(command);

            injetar(command, catalogo, command.TextoConexao);

            return Task.FromResult(response);
        }



        //public async Task<Unit> Handle(CarregaCatalogoCompletoMecanicaCommand command, CancellationToken cancellationToken)
        //{
        //    var catalogo = defineCatalogo(command);

        //     injetar(command, catalogo);

        //    return Unit.Value;


        //}

        private CatalogoEntidade defineCatalogo(CarregaCatalogoCompletoMecanicaCommand command)
        {

            var catalogo = _repoCatalogo.ObterPorNome(command.NomeCatalogo);

            if (catalogo == null)
            {

                var idioma = _idiomaMDBRepositorio.ObterIdiomaPorLinguaPais(command.Idioma, command.Pais);


                if (idioma == null)
                {
                    idioma = new Idioma(command.Idioma, command.Pais);
                    _idiomaMDBRepositorio.CadastrarIdioma(idioma);
                }


                catalogo = new CatalogoEntidade(idioma.GUID, command.NomeCatalogo, command.GuidDisciplina);
                _repoCatalogo.CadastrarCatalogo(catalogo);

            }


            return catalogo;
        }

        public void injetar(CarregaCatalogoCompletoMecanicaCommand command, CatalogoEntidade catalogo, string conexao)
        {


            //if (ExistemItensNaoInseridosNoBancoDeDados(command))
            //{

            foreach (var item in command.QueryEquipment_PNP_SQL)
            {

                string PnPClassName = item["PnPClassName"] == null ? "" : item["PnPClassName"].ToString();

                string PartFamilyLongDesc = item["PartFamilyLongDesc"] == null ? "" : item["PartFamilyLongDesc"].ToString();
                string PartSizeLongDesc = item["PartSizeLongDesc"] == null ? "" : item["PartSizeLongDesc"].ToString();
                string PnPID = item["PnPID"] == null ? "" : item["PnPID"].ToString();

                var tipoDeItemEngenharia = DefineTipoDeItem(PnPClassName);

                var categoria = DefinirCategoria(catalogo, tipoDeItemEngenharia);

                if (PartFamilyLongDesc != "")
                {
                    PartFamilyLongDesc = PartSizeLongDesc;
                }
                var valor = DefinirValor(PartFamilyLongDesc, conexao);

                var familia = DefinirFamilia(catalogo, categoria, valor);

                var itemPipeEstoque = DefineItemPipe(catalogo, int.Parse(PnPID), tipoDeItemEngenharia, familia);

                foreach (var info in item.Keys)
                {

                    var chave = info.ToString();
                    //if (chave != "PnPClassName" && chave != "PartFamilyLongDesc" && chave != "PartSizeLongDesc" && chave != "PnPID")
                    if (chave != "PnPID")
                    {


                        var nomeTipoPropriedade = DefineNomeTipoPropriedade(chave);

                        var descricaoValor = item[chave] == null ? "" : item[chave].ToString();

                        if (descricaoValor != "")
                        {

                            var valorTabelado = DefinirValor(descricaoValor, conexao);

                            var propriedadeDoItem = DefinirPropriedadeItem(nomeTipoPropriedade.GUID, valorTabelado.GUID, itemPipeEstoque);

                            DefinirRelacaoPropriedadeItem(propriedadeDoItem, itemPipeEstoque);



                        }
                    }
                }





            }

            //}

        }

        private void DefinirRelacaoPropriedadeItem(PropriedadeItem propriedadeDoItem, ItemPipe itemPipeEstoque)
        {
            var relacao = _repoRelacaoPropriedadeItem.ObterRelacao(propriedadeDoItem, itemPipeEstoque);
            if (relacao == null)
            {
                relacao = new RelacaoPropriedadeItem(propriedadeDoItem.GUID, itemPipeEstoque.GUID);
                _repoRelacaoPropriedadeItem.Cadastrar(relacao);
            }



        }

        private bool ExistemItensNaoInseridosNoBancoDeDados(CarregaCatalogoCompletoMecanicaCommand command)
        {


            return _repoItemPipe.Contar() < command.QueryEquipment_PNP_SQL.Count();
        }

        private PropriedadeItem DefinirPropriedadeItem(string guidTipo, string guidValor, ItemPipe itemPipe)
        {
            var propriedadeDoItem = _repoPropriedadeItem.ObterPorTipoMaisValor(guidTipo, guidValor);

            if (propriedadeDoItem == null)
            {
                propriedadeDoItem = new PropriedadeItem(guidValor, guidTipo);

                _repoPropriedadeItem.Cadastrar(propriedadeDoItem);



            }

            return propriedadeDoItem;

        }

        private NomeTipoPropriedade DefineNomeTipoPropriedade(string nome)
        {

            var nomeTipoPropriedade = _repoNomeTipoPropriedade.ObterPorNome(nome);

            if (nomeTipoPropriedade == null)
            {
                nomeTipoPropriedade = new NomeTipoPropriedade(nome);
                _repoNomeTipoPropriedade.CadastrarNomeTipoPropriedade(nomeTipoPropriedade);
            }

            return nomeTipoPropriedade;
        }

        private ItemPipe DefineItemPipe(CatalogoEntidade catalogo, int pnPidItemPipe, TipoItemEng tipoDeItemEngenharia, Familia familia)
        {
            var itemPipe = _repoItemPipe.ObterPorTipoDeItemNoCatalogo(tipoDeItemEngenharia, catalogo);

            if (itemPipe == null)
            {
                itemPipe = new ItemPipe(tipoDeItemEngenharia.GUID, catalogo.GUID, "", pnPidItemPipe, familia.GUID);
                _repoItemPipe.CadastrarItemPipe(itemPipe);
            }

            return itemPipe;
        }

        private Familia DefinirFamilia(CatalogoEntidade catalogo, Categoria categoria, ValorTabelado valor)
        {
            var familia = _repoFamilia.ObterFamiliaPorValor(valor);


            if (familia == null)
            {
                familia = new Familia(catalogo.GUID, categoria.GUID, valor);
                _repoFamilia.Cadastrar(familia);
            }

            return familia;
        }

        private static ValorTabelado DefinirValor(string descricaoValor, string conexao)
        {
            var valor = RepoValores.Instancia(conexao).ObterDescricao(descricaoValor);

            if (valor == null)
            {
                valor = new ValorTabelado(descricaoValor, "");
                RepoValores.Instancia(conexao).CadastrarValor(valor);
            }

            return valor;
        }

        private Categoria DefinirCategoria(CatalogoEntidade catalogo, TipoItemEng tipoDeItemEngenharia)
        {
            var categoria =
                _repoCategoria.ObterPorTipoDeItem(tipoDeItemEngenharia);
            if (categoria == null)
            {
                categoria = new Categoria(catalogo.GUID, tipoDeItemEngenharia.GUID);
                _repoCategoria.CadastrarCategoria(categoria);
            }

            return categoria;
        }

        private TipoItemEng DefineTipoDeItem(string oBaseTable)
        {
            var tipoItemEng = _repoTipoDeItem.ObterPorNome(oBaseTable);

            if (tipoItemEng == null)
            {
                tipoItemEng = new TipoItemEng(oBaseTable);
                _repoTipoDeItem.CadastrarTipo(tipoItemEng);
            }

            return tipoItemEng;
        }

        private ValorTabelado CriaValorTabelado(object valor, List<ValorTabelado> valoresTabelados, string conexao)
        {
            ValorTabelado valorTabelado = null;

            if (valoresTabelados.Count == 0)
            {
                valorTabelado = new ValorTabelado(valor.ToString(), "");

                RepoValores.Instancia(conexao).CadastrarValor(valorTabelado);
                //_valorTabeladoRepositorio.Inserir(valorTabelado);
            }
            else
            {
                valorTabelado = valoresTabelados.First();
            }

            return valorTabelado;
        }

    }
}
