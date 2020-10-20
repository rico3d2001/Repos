using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Services
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
