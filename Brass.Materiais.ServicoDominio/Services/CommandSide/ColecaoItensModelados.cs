using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.ServicoDominio.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brass.Materiais.ServicoDominio.Services.CommandSide
{
    public class ColecaoItensModelados
    {
        RepoItemModelado _repoItemModelado;
        //List<Coletados> _viewsBanco;
        RepoNumerosAtivos _repoAreasPlanejadas;

        Projeto _projeto;



        public ColecaoItensModelados(string dataBaseProjeto, string guidProjeto, string conexao)
        {
            DataBaseProjeto = dataBaseProjeto;
            GuidProjeto = guidProjeto;

            _repoItemModelado = new RepoItemModelado(conexao);
            _repoAreasPlanejadas = new RepoNumerosAtivos(conexao);

            var repoProjetos = new RepoProjetos(conexao);
            _projeto = repoProjetos.ObterProjeto(guidProjeto);

        }

        public string DataBaseProjeto { get; set; }
        public string GuidProjeto { get; set; }


        public void ColetarItens(NumeroAtivo ativo, List<Coletado> coletados)
        {

            foreach (var coletado in coletados)
            {
                if (PossuiDescricao(coletado))
                {

                    if(TagCompativel(coletado.ComponentePlant.LineNumberTag))
                    {
                        if (TagPertenceEstaArea(ativo, coletado.ComponentePlant.LineNumberTag))
                        {
                            var construtorItemModelado = new ConstrutorItemModelado(_projeto, coletado.ComponentePlant.LineNumberTag);

                            var itemModelado = construtorItemModelado.Construir(coletado);

                            _repoItemModelado.Cadastrar(itemModelado);
                        }



                        
                    }
                 

                }

            }
        }

        private bool TagPertenceEstaArea(NumeroAtivo ativo, string lineNumberTag)
        {
           if(ativo.AreaTag.Area == "00" && lineNumberTag == null)
            {
                return true;
            }
            else if (NomesAreasEsccitasSaoIguais(ativo, lineNumberTag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool NomesAreasEsccitasSaoIguais(NumeroAtivo ativo, string lineNumberTag)
        {
            if (lineNumberTag == null) return false;

            var area = lineNumberTag.Split('-').First().Trim().Substring(0, 2);
            var subArea = lineNumberTag.Split('-').First().Trim().Substring(2, 2);

            return ativo.AreaTag.Area == area && ativo.AreaTag.SubArea == subArea;
        }

        private bool TagCompativel(string lineNumberTag)
        {
            return lineNumberTag == null || lineNumberTag.Split('-').First().Trim().Length == 6;
        }

 
        private static bool PossuiDescricao(Coletado coletado)
        {
            return !(coletado.ComponentePlant.PartFamilyLongDesc == "" && coletado.ComponentePlant.PartSizeLongDesc == "");
        }

        public List<Coletado> ObterColetadosDaArea(string guidProjeto, string conexao)
        {
            var repoColetados = new RepoColetadosPipe(conexao);

            return repoColetados.ObterColetadosDaArea(guidProjeto);
        }




        //private AreaTag CriaAreaZero() //, AreaTag areaPlanejada)
        //{
        //    AreaTag areaZero = AreaTag.Improvisar(projeto);

        //    _repoAreasPlanejadas.Cadastrar(areaZero);
        //    return areaZero;
        //}





        private bool AreaDoModeloEstaDeAcordoComAreaPlanejada(NumeroAtivo ativo, NumeroAtivo ativoModelo)
        {
            return (ativoModelo != null && ativoModelo.Equals(ativo)) ? true : false;
        }

        private static string extraiTagViewDoBanco(Dictionary<string, string> itemViewBanco)
        {
            return itemViewBanco["LineNumberTag"] == null ? "" : itemViewBanco["LineNumberTag"].ToString();
        }



    }


}

