using Brass.Materiais.DominioPQ.PQ.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.TesteBulkload.Templates.MontagensXLS
{
    public class ItemizaAtividades
    {
        public static void Itemizar(string itemIndice, string descricao, List<Atividade> atividades, 
            List<NivelAtividade> niveis, List<Atividade> atividadesColetadas)
        {

           

            var indices = new int[] { 0, 0, 0, 0 };

            //var itemizacao = celula.GetString(_numeroLinha, 1).Split('.');

            var itemizacao = itemIndice.Split('.');
            for (int i = 0; i < itemizacao.Length; i++)
            {
                var numero = int.Parse(itemizacao[i]);
                indices[i] = numero;
            }



            if (indices[0] == 1 && indices[1] == 0 && indices[2] == 0 && indices[3] == 0)
            {
                var nivel = niveis.FirstOrDefault(x => x.Oredenador == 0);

                var atividadesSelect = atividades.Where(x => 
                x.NivelAtividade == nivel.Nome 
                && x.Codigo == "M").ToList();

            

                atividadesColetadas.Add(atividadesSelect.First(x => x.Descricao == descricao));


            }
            if (indices[1] == 0 && indices[2] == 0 && indices[3] == 0)
            {
                var nivel = niveis.FirstOrDefault(x => x.Oredenador == 1);

                var atividadesSelect = atividades.Where(x => x.NivelAtividade == nivel.Nome && x.Codigo == "M").ToList();


                atividadesColetadas.Add(atividadesSelect.First(x => x.Descricao == descricao));
       
            }
            //else if (indices[2] == 0 && indices[3] == 0)
            //{
            //    var nivel = niveis.FirstOrDefault(x => x.Oredenador == 1);
            //    var atividadesSelect = atividades.Where(x => x.NivelAtividade == nivel.Nome).ToList();
            //    var descricao = celula.GetString(_numeroLinha, 10);
            //    if (indices[1] == _atividadeBase.Indice)
            //    {
            //        atividadeBase.AddFilha(atividadesSelect.FirstOrDefault(x => x.Descricao == descricao));
            //    }
            //}
            //else if (indices[3] == 0)
            //{
            //    var nivel = niveis.FirstOrDefault(x => x.Oredenador == 2);
            //    var atividadesSelect = atividades.Where(x => x.NivelAtividade == nivel.Nome).ToList();
            //    var descricao = celula.GetString(_numeroLinha, 10);


            //    //_atividadeBase.AtividadesFilhas.Add(atividadesSelect.FirstOrDefault(x => x.Descricao == descricao));
            //}
            //else
            //{
            //    var nivel = niveis.FirstOrDefault(x => x.Oredenador == 3);
            //    var atividadesSelect = atividades.Where(x => x.NivelAtividade == nivel.Nome);
            //    var descricao = celula.GetString(_numeroLinha, 10);
            //    //_atividadeBase.AtividadesFilhas = atividadesSelect.FirstOrDefault(x => x.Descricao == descricao);
            //}


        }
    }
}
