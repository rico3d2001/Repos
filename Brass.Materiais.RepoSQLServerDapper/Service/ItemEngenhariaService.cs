using Brass.Materiais.RepoSQLServerDapper.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoSQLServerDapper.Service
{
    public class ItemEngenhariaService
    {

        public List<CatalogoDTO> ObterCatalogos()
        {
            List<CatalogoDTO> lista = new List<CatalogoDTO>();
            string qry = "SELECT GUID, NOME FROM CatalogoPlant3d";

            using (var conexaoBD = new Conexao())
            {
                lista = conexaoBD.SQLServerConexao.Query<CatalogoDTO>(qry).ToList();
            }

            return lista;
        }

        public List<CategoriaDTO> ObterCategorias(string guidCatalogo)
        {
            List<CategoriaDTO> lista = new List<CategoriaDTO>();

            //string qry = "SELECT  ItemEngenharia.GUID, Valores.VALOR AS NOME"
            //                + " FROM ItemEngenharia INNER JOIN"
            //                + " Valores ON ItemEngenharia.GUID = Valores.GUID"
            //                + " WHERE(ItemEngenharia.GUID_ITEM_PAI = '" + guidCatalogo + "')";

            string qry = "SELECT Categoria.GUID, Categoria.NOME"
                         + " FROM Categorias_Catalogo INNER JOIN"
                         + " Categoria ON Categorias_Catalogo.GUID_CATEGORIA = Categoria.GUID"
                         + " WHERE(Categorias_Catalogo.GUID_CATALOGO = '" + guidCatalogo + "')";

            using (var conexaoBD = new Conexao())
            {
                lista = conexaoBD.SQLServerConexao.Query<CategoriaDTO>(qry).ToList();
            }

            return lista;
        }

        public List<TiposItemDTO> ObterTiposItem(string guidCatalogo, string guidCategoria)
        {
            List<TiposItemDTO> lista = new List<TiposItemDTO>();
            string qry = "SELECT DISTINCT TipoItem.GUID AS GUID, TipoItem.NOME AS NOME"
                         + " FROM PropriedadeEng INNER JOIN"
                         + " PropriedadeItemEng ON PropriedadeEng.GUID = PropriedadeItemEng.GUID_PROPRIEDADE INNER JOIN"
                         + " ItemEngenharia ON PropriedadeItemEng.GUID_ITEM_ENG = ItemEngenharia.GUID INNER JOIN"
                         + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                         + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID INNER JOIN"
                         + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID"
                         + " WHERE(ItemEngenharia.GUID_CATALOGO = '" + guidCatalogo + "')"
                         + " AND(TipoPropriedade.NOME = N'PartCategory')"
                         + " AND(Valores.GUID = '" + guidCategoria + "')";

            using (var conexaoBD = new Conexao())
            {
                lista = conexaoBD.SQLServerConexao.Query<TiposItemDTO>(qry).ToList();
            }

            return lista;
        }



        
        public List<ItemEngenhariaDTO> ObterPorId(string guid_item)
        {
            List<ItemEngenhariaDTO> lista = new List<ItemEngenhariaDTO>();

            string qry = "SELECT "
                + " TipoItem.NOME AS ITEM,"
                + " CatalogoPlant3d.NOME AS CATALOGO,"
                + " TipoPropriedade.NOME AS PROPRIEDADE,"
                + " Valores.VALOR AS VALOR_PROPRIEDADE,"
                + " ItemEngenharia.GUID AS GUID_ITEM"
                + " FROM ItemEngenharia INNER JOIN"
                         + " TipoItem ON ItemEngenharia.GUID_TIPO_ITEM = TipoItem.GUID INNER JOIN"
                         + " CatalogoPlant3d ON ItemEngenharia.GUID_CATALOGO = CatalogoPlant3d.GUID INNER JOIN"
                         + " PropriedadeItemEng ON ItemEngenharia.GUID = PropriedadeItemEng.GUID_ITEM_ENG INNER JOIN"
                         + " PropriedadeEng ON PropriedadeItemEng.GUID_PROPRIEDADE = PropriedadeEng.GUID INNER JOIN"
                         + " TipoPropriedade ON PropriedadeEng.GUID_TIPO = TipoPropriedade.GUID INNER JOIN"
                         + " Valores ON PropriedadeEng.GUID_VALOR = Valores.GUID"
               + " WHERE(ItemEngenharia.GUID = '" + guid_item + "')";

            using (var conexaoBD = new Conexao())
            {
                lista = conexaoBD.SQLServerConexao.Query<ItemEngenhariaDTO>(qry).ToList();
            }

            return lista;



        }
    }

}
