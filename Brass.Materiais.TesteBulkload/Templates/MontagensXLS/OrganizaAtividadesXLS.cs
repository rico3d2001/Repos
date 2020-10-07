using Brass.ExcelLeitura.App.Comandos;
using Brass.ExcelLeitura.App.Interface;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.TesteBulkload.Templates.MontagensXLS
{
    public class OrganizaAtividadesXLS : LeitoraPlanilha<Atividade>, ILeitoraPlanilha<Atividade>
    {
        //List<Atividade> _atividades;
        List<NivelAtividade> _niveis;

        Atividade _atividadeK;
        Atividade _atividadeTT;
        Atividade _atividadeUU;
        Atividade _atividadeVVV;
        Atividade _atividadeWWW;




        public OrganizaAtividadesXLS(int numeroLinha, List<NivelAtividade> niveis, List<Atividade> atividades) : base(numeroLinha)
        {
            _niveis = niveis;

            _lista = new List<Atividade>(atividades);

           
        }

        protected override void LerPorLinha(Celula celula)
        {

           // List<string> niveisBase = new List<string> { "M", "D", "F" };


          

            var indices = new string[] { "M", "00", "00", "000", "000" };

        
            for (int i = 0; i < 5; i++)
            {
                var ativ = celula.GetString(_numeroLinha, i + 1);
                indices[i] = ativ;
            }

            Versao versao = new Versao(0, "Planilha", "Tirado teste", DateTime.Now);


            if (indices[1] == "00" && indices[2] == "00" && indices[3] == "000" && indices[4] == "000")
            {
                var nivel = _niveis.FirstOrDefault(x => x.Oredenador == 0);
                var descr = celula.GetString(_numeroLinha, 6);
                var codigo = celula.GetString(_numeroLinha, 1);
                var atividadesSelect = _lista.Where(x => x.NivelAtividade == "K" && x.Codigo == indices[0]).ToList();
               
                if (atividadesSelect.Count > 0)
                {
                    _atividadeK = atividadesSelect.FirstOrDefault(x => x.Descricao == descr);
                    if (_atividadeK == null)
                    {
                        _atividadeK = new Atividade(_identidade,"K", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                       "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                    }
                    else
                    {
                        _atividadeK.GUID_PAI = "";
                    }

                }
                else
                {
                    _atividadeK = new Atividade("K", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                        "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);

                    _lista.Add(_atividadeK);
                }

                

               

            }
            if (indices[1] != "00" && indices[2] == "00" && indices[3] == "000" && indices[4] == "000")
            {
                var nivel = _niveis.FirstOrDefault(x => x.Oredenador == 1);

                var atividadesSelect = _lista.Where(x => x.NivelAtividade == "TT").ToList();

                var descr = celula.GetString(_numeroLinha, 6);
                var codigo = celula.GetString(_numeroLinha, 2);
                if (atividadesSelect.Count > 0)
                {
                    _atividadeTT = atividadesSelect.FirstOrDefault(x => x.Descricao == descr);
                    if (_atividadeTT == null)
                    {
                        _atividadeTT = new Atividade("TT", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                       "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                        _atividadeTT.GUID_PAI = _atividadeK.GUID;
                        _lista.Add(_atividadeTT);
                    }
                    else
                    {
                        _atividadeTT.GUID_PAI = _atividadeTT.GUID_PAI;
                    }
                    
                }
                else
                {
                    _atividadeTT = new Atividade("TT", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                        "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                    _atividadeTT.GUID_PAI = _atividadeK.GUID;
                    _lista.Add(_atividadeTT);
                }

            }
            else if (indices[2] != "00" && indices[3] == "000" && indices[4] == "000")
            {
                var nivel = _niveis.FirstOrDefault(x => x.Oredenador == 2);

                var atividadesSelect = _lista.Where(x => x.NivelAtividade == "UU").ToList();

                var descr = celula.GetString(_numeroLinha, 6);
                var codigo = celula.GetString(_numeroLinha, 3);
                if (atividadesSelect.Count > 0)
                {
                    _atividadeUU = atividadesSelect.FirstOrDefault(x => x.Descricao == descr);
                    if (_atividadeUU == null)
                    {
                        _atividadeUU = new Atividade("UU", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                        "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                        _atividadeUU.GUID_PAI = _atividadeTT.GUID;
                        _lista.Add(_atividadeUU);
                    }
                    else
                    {
                        _atividadeUU.GUID_PAI = _atividadeUU.GUID_PAI;
                    }
                   
                }
                else
                {
                    _atividadeUU = new Atividade("UU", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                        "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                    _atividadeUU.GUID_PAI = _atividadeTT.GUID;
                    _lista.Add(_atividadeUU);

                }
            }
            else if (indices[3] != "000" && indices[4] == "000")
            {
                var nivel = _niveis.FirstOrDefault(x => x.Oredenador == 3);

                var atividadesSelect = _lista.Where(x => x.NivelAtividade == "VVV").ToList();

                var descr = celula.GetString(_numeroLinha, 6);
                var codigo = celula.GetString(_numeroLinha, 4);
                if (atividadesSelect.Count > 0)
                {
                    _atividadeVVV = atividadesSelect.FirstOrDefault(x => x.Descricao == descr);
                    if(_atividadeVVV == null)
                    {
                        _atividadeVVV = new Atividade("VVV", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                       "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                        _atividadeVVV.GUID_PAI = _atividadeUU.GUID;
                        _lista.Add(_atividadeVVV);
                    }
                    else
                    {
                        _atividadeVVV.GUID_PAI = _atividadeVVV.GUID_PAI;
                    }

  
                }
                else
                {
                    _atividadeVVV = new Atividade("VVV", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                        "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                    _atividadeVVV.GUID_PAI = _atividadeUU.GUID;
                    _lista.Add(_atividadeVVV);
                }
            }
            else if (indices[4] != "000")
            {
                var nivel = _niveis.FirstOrDefault(x => x.Oredenador == 4);

                var atividadesSelect = _lista.Where(x => x.NivelAtividade == "WWW").ToList();

                var descr = celula.GetString(_numeroLinha, 6);
                var codigo = celula.GetString(_numeroLinha, 5);
                if (atividadesSelect.Count > 0)
                {
                    _atividadeWWW = atividadesSelect.FirstOrDefault(x => x.Descricao == descr);
                    if (_atividadeWWW == null)
                    {
                        _atividadeWWW = new Atividade("WWW", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                   "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                        _atividadeWWW.GUID_PAI = _atividadeVVV.GUID;
                        _lista.Add(_atividadeWWW);
                    }
                    else
                    {
                        _atividadeWWW.GUID_PAI = _atividadeWWW.GUID_PAI;
                    }
                        
                }
                else
                {
                    _atividadeWWW = new Atividade("WWW", "", "697cf50e-17fe-47b4-bfbe-32aa4f06de46", "909e5882-0b5e-414f-b37c-79514ac6f69f",
                        "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f", versao, codigo, descr);
                    _atividadeWWW.GUID_PAI = _atividadeVVV.GUID;
                    _lista.Add(_atividadeWWW);
                }
            }


        }

        //if (tipos.Count == 1)
        //{
        //    var tipo = tipos.First();

        //    foreach (var nivel in niveisAtividades)
        //    {
        //        var atividades = repositorioAtividade.Encontrar(
        //            Builders<Atividade>.Filter.Eq(x => x.NivelAtividade, nivel.Nome));
        //        //& Builders<Atividade>.Filter.Eq(x => x.Codigo, codigo));

        //    }



        //}



    }
}
