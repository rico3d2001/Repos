using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.ServicoDominio.Fabrica
{
    public class ConstrutorItemPQDiagrama
    {

        RepoAtividade _repoAtividade;

        public ConstrutorItemPQDiagrama(string conexao)
        {
            _repoAtividade = new RepoAtividade(conexao);
        }

        public ItemPQ ConstruirItemPQDoDiagrama(ItemPipe itemPipe, Linha linha) //string tag, string pnPID, string specPart)
        {
            string siglaPrimeiraAtividade = DefineSiglaPrimeiraAtividade(itemPipe);


            Atividade atividade = null;
            if(siglaPrimeiraAtividade != "X")
            {
                atividade = _repoAtividade.ObterPorGuid(itemPipe.GUID_ATIVIDADE);
            }
            

            var itemTag = new ItemTag(linha.NumeroAtivo, linha.TagOrigem);
            return new ItemPQ(itemTag, linha.PnPID, linha.Descricao, itemPipe, siglaPrimeiraAtividade, atividade);
        }

      

        public ItemPQ ConstruirItemPQSomenteModelado(ItemModelado itemParaAnalize, ItemPipe itemPipe)
        {

            string siglaPrimeiraAtividade = DefineSiglaPrimeiraAtividade(itemPipe);

            Atividade atividade = null;
            if (siglaPrimeiraAtividade != "X")
            {
                atividade = _repoAtividade.ObterPorGuid(itemPipe.GUID_ATIVIDADE);
            }

            ItemPQ itemPQPlant3D =
             new ItemPQ(itemParaAnalize.ItemTag, itemParaAnalize,
             itemParaAnalize.DescricaoLongaDimensionada, itemPipe, siglaPrimeiraAtividade, atividade);

            itemPQPlant3D.CorAvanco = "red";

            return itemPQPlant3D;
        }

        private string DefineSiglaPrimeiraAtividade(ItemPipe itemPipe)
        {
            var siglaPrimeiraAtividade = "X";

            if (itemPipe != null)
            {
                siglaPrimeiraAtividade = _repoAtividade.ObterSiglaPrimeiraAtividade(itemPipe);

                if(siglaPrimeiraAtividade == null)
                {
                    if(itemPipe.NominalDiameter <= 8)
                    {
                        siglaPrimeiraAtividade = "X";
                    }
                    else
                    {
                        siglaPrimeiraAtividade = "X";
                    }
                }
            }


            return siglaPrimeiraAtividade;
        }

    

    }
}
