using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.InterfaceExcel.Comandos
{
    public class ArquivosExcel
    {
        List<string> _arquivos;

        public ArquivosExcel()
        {
            _arquivos = new List<string>();
        }

        public List<string> ObtemArquivos(string nomeDiretorio)
        {
            DirectoryInfo dir = new DirectoryInfo(nomeDiretorio);

            foreach (FileInfo file in dir.GetFiles())
            {

                if (!file.Name.Contains('~') && (file.Extension == ".xlsx" || file.Extension == ".xls"))
                {
                    _arquivos.Add(file.FullName);
                }


            }

            return _arquivos;
        }

    }
}
