using Brass.Materiais.RepoDapperSQLServer.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.RepoDapperSQLServer.Service
{
    public class PropriedadesItemServiceSQL
    {
        public List<string> ObterColunas(string guidCategoria,string guidTipoItem)
        {

            List<string> lista = new List<string>();

            string qry = "SELECT TipoPropriedade.NOME"
                         + " FROM ItemEngenharia INNER JOIN"
                         + " PropriedadeItemEng ON ItemEngenharia.GUID = PropriedadeItemEng.GUID_ITEM_ENG INNER JOIN"
                         + " PropriedadeEng ON PropriedadeItemEng.GUID_PROPRIEDADE = PropriedadeEng.GUID INNER JOIN"
                         + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                         + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID"
                         + " WHERE ItemEngenharia.GUID = (SELECT TOP(1) ItemEngenharia.GUID"
                            + " FROM PropriedadeEng INNER JOIN"
                            + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                            + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                            + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                            + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                            + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                            + " WHERE(TipoPropriedade.NOME = N'PartCategory')"
                            + " AND(Valores.GUID = '" + guidCategoria + "')" 
                            + " AND(TipoItem.GUID = '" + guidTipoItem + "'))"; 



            using (var conexaoBD = new Conexao("__CATALOGO_BRASS"))
            {
                
                lista = conexaoBD.SQLServerConexao.Query<string>(qry).OrderBy(x => x).ToList();


            }

            return lista;
        }

        public List<PropriedadeIDArmazem> ObterPropriedadesID(string guidCatalogo, string guidCategoria, string guidTipoItem)
        {
            List<PropriedadeIDArmazem> props = new List<PropriedadeIDArmazem>();

            string qryGuidsItens = "SELECT ItemEngenharia.GUID, ItemEngenharia.PnPID,ItemEngenharia.GUID_CATALOGO AS GUID_CATALOG"
                                            + " FROM PropriedadeEng INNER JOIN"
                                            + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                                            + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                                            + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                            + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                                            + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                                            + " WHERE(TipoPropriedade.NOME = N'PartCategory')"
                                            + " AND(ItemEngenharia.GUID_CATALOGO = '" + guidCatalogo + "')"
                                            + " AND(Valores.GUID = '" + guidCategoria + "')"
                                            + " AND(TipoItem.GUID = '" + guidTipoItem + "')"
                                            + " ORDER BY[PnPID]";

         

            using (var conexaoBD = new Conexao("__CATALOGO_BRASS"))
            {
                props = conexaoBD.SQLServerConexao.Query<PropriedadeIDArmazem>(qryGuidsItens).ToList();

            }

            return props;
        }


        public List<PropriedadesItemDTO> ObterPropriedadesItemDTO(PropriedadeIDArmazem prop, string guidCategoria, string guidTipoItem)
        {
            List<PropriedadesItemDTO> listaProps = new List<PropriedadesItemDTO>();

            using (var conexaoBD = new Conexao("__CATALOGO_BRASS"))
            {
                
                //foreach (var prop in props)
                //{



                    string qry = "SELECT PropriedadeItemEng.GUID AS GUID_ITEM_PROPRIEDADE, TipoPropriedade.NOME AS PROPRIEDADE, Valores.VALOR AS VALOR_PROPRIEDADE,"
                                 + "ItemEngenharia.PnPID AS PnPID, ItemEngenharia.GUID AS GUID_ITEM"
                                    + " FROM ItemEngenharia INNER JOIN"
                                    + " PropriedadeItemEng ON ItemEngenharia.GUID = PropriedadeItemEng.GUID_ITEM_ENG INNER JOIN"
                                    + " PropriedadeEng ON PropriedadeItemEng.GUID_PROPRIEDADE = PropriedadeEng.GUID INNER JOIN"
                                    + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                    + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID"
                                    + " WHERE ItemEngenharia.GUID = (SELECT ItemEngenharia.GUID"
                                                        + " FROM PropriedadeEng INNER JOIN"
                                                        + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                                                        + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                                                        + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                                        + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                                                        + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                                                        + " WHERE(TipoPropriedade.NOME = N'PartCategory')"
                                                        + " AND(Valores.GUID = '" + guidCategoria + "')"
                                                        + " AND(TipoItem.GUID = '" + guidTipoItem + "')"
                                                        + " AND(ItemEngenharia.GUID = '" + prop.GUID + "'))";

                    listaProps = conexaoBD.SQLServerConexao.Query<PropriedadesItemDTO>(qry).OrderBy(x => x.PROPRIEDADE).ToList();

                    //linhas = linhas + "{\"PnPID\": \"" + listaProps[0].PnPID + "\",\"GUID_ITEM\": \"" + listaProps[0].GUID_ITEM + "\",";
                    //foreach (var item in listaProps)
                    //{
                        //linhas = linhas + "\"" + item.PROPRIEDADE + "\": \"" + item.VALOR_PROPRIEDADE.Replace('"', '¨') + "\",";
                    //}

                    //linhas = linhas.Substring(0, linhas.Length - 1) + "},";




                //}



            }


            return listaProps;
        }



        public string ObterLinhasTabela(int intervalo, int ultimoPnPID, string guidCategoria, string guidTipoItem)
        {

            string linhas = "[";

            string qryGuidsItens = "SELECT TOP (" + intervalo + ") ItemEngenharia.GUID, ItemEngenharia.PnPID"
                                            + " FROM PropriedadeEng INNER JOIN"
                                            + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                                            + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                                            + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                            + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                                            + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                                            + " WHERE(TipoPropriedade.NOME = N'PartCategory')"
                                            + " AND(Valores.GUID = '" + guidCategoria + "')"
                                            + " AND(TipoItem.GUID = '" + guidTipoItem + "')"
                                            + " AND[PnPID] > " + ultimoPnPID
                                            + " ORDER BY[PnPID]";


            using (var conexaoBD = new Conexao("__CATALOGO_BRASS"))
            {
                var props = conexaoBD.SQLServerConexao.Query<PropriedadeIDArmazem>(qryGuidsItens).ToList();

                foreach (var prop in props)
                {



                    string qry = "SELECT PropriedadeItemEng.GUID AS GUID_ITEM_PROPRIEDADE, TipoPropriedade.NOME AS PROPRIEDADE, Valores.VALOR AS VALOR_PROPRIEDADE,"
                                 + "ItemEngenharia.PnPID AS PnPID, ItemEngenharia.GUID AS GUID_ITEM"
                                    + " FROM ItemEngenharia INNER JOIN"
                                    + " PropriedadeItemEng ON ItemEngenharia.GUID = PropriedadeItemEng.GUID_ITEM_ENG INNER JOIN"
                                    + " PropriedadeEng ON PropriedadeItemEng.GUID_PROPRIEDADE = PropriedadeEng.GUID INNER JOIN"
                                    + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                    + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID"
                                    + " WHERE ItemEngenharia.GUID = (SELECT ItemEngenharia.GUID"
                                                        + " FROM PropriedadeEng INNER JOIN"
                                                        + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                                                        + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                                                        + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                                                        + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                                                        + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                                                        + " WHERE(TipoPropriedade.NOME = N'PartCategory')"
                                                        + " AND(Valores.GUID = '" + guidCategoria + "')"
                                                        + " AND(TipoItem.GUID = '" + guidTipoItem + "')"
                                                        + " AND(ItemEngenharia.GUID = '" + prop.GUID + "'))";

                    var listaProps = conexaoBD.SQLServerConexao.Query<PropriedadesItemDTO>(qry).OrderBy(x => x.PROPRIEDADE).ToList();

                    linhas = linhas + "{\"PnPID\": \"" + listaProps[0].PnPID + "\",\"GUID_ITEM\": \"" + listaProps[0].GUID_ITEM + "\",";
                    foreach (var item in listaProps)
                    {
                        linhas = linhas + "\"" + item.PROPRIEDADE + "\": \"" + item.VALOR_PROPRIEDADE.Replace('"','¨') + "\",";
                    }

                    linhas = linhas.Substring(0, linhas.Length - 1) + "},"; 

                    


                }



            }

            linhas = linhas.Substring(0, linhas.Length - 1) + "]";

            return linhas;


    }


        public List<ItemEngenhariaDTO> ObterPorCategoria(string guidCatalogo, string guidCategoria, string guidTipoItem)
        {
            List<ItemEngenhariaDTO> lista = new List<ItemEngenhariaDTO>();

            //string tipoItem = "CROSS (RED)";
            

            string qry = "SELECT DISTINCT "
           + " TipoItem.NOME AS ITEM,"
           + " TipoPropriedade.NOME AS PROPRIEDADE,"
           + " Valores.VALOR AS VALOR_PROPRIEDADE,"
           + " ItemEngenharia.GUID AS GUID_ITEM"
           + " FROM PropriedadeEng INNER JOIN"
                         + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                         + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                         + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                         + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                         + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                         + " WHERE(ItemEngenharia.GUID_CATALOGO = '" + guidCatalogo + "')"
                         + " AND(TipoPropriedade.NOME = N'PartCategory')"
                         + " AND(Valores.GUID = '" + guidCategoria + "')"
                         + " AND(TipoItem.GUID = '" + guidTipoItem + "')";



            using (var conexaoBD = new Conexao("__CATALOGO_BRASS"))
            {
                lista = conexaoBD.SQLServerConexao.Query<ItemEngenhariaDTO>(qry).ToList();
            }


            return lista;
        }
    }
}
