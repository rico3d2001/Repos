using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Interfaces;
using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using Brass.Materiais.RepositorioSQLServer;
using Brass.Materiais.RepositorioSQLServer.Service;
using System;
using System.Linq;

namespace Brass.Materiais.Dominio.Servico.Fabricas
{

    public class MontagemItemEngenharia
    {


        //private DataBaseContext _contexto;
        private string _conexao;

        public MontagemItemEngenharia()
        {
            //_contexto = contexto;
        }


        public void MontarItem(string siglaPeca, string siglaMaterial, string siglaFabricacao, string siglaExtremidade,
            string siglaRevestimento, string siglaEspessura, string siglaDiametro, string conexao)
        {
            _conexao = conexao;
            string guid = Guid.NewGuid().ToString();


            ICodificacao codificadorBRASS = new CodigoBRASS();

            EngenhariaItem itemInLine = new EngenhariaItem(new NomeItem("InLine"),null,null);
            EngenhariaItem ItemTubo = new EngenhariaItem(new NomeItem("TUBO"), itemInLine, codificadorBRASS);

            using (var tipoPropriedadeRepositorio = new Repositorio<TipoPropriedade>(_conexao))
            {
                var listaTiposPropriedade = tipoPropriedadeRepositorio.Query().ToList();

                foreach (var tipos in listaTiposPropriedade)
                {

                }
            }
              


            ItemTubo.AddPropriedade(new Propriedade(new NomePropriedade("MATERIAL"), new ValorPropriedade("053", new PropriedadeTipo("LISTA"))));//new TipoPropriedade("MATERIAL"),new ValorPropriedade(,null)));
            ItemTubo.AddPropriedade(new Propriedade(new NomePropriedade("SCH"), new ValorPropriedade("SC", new PropriedadeTipo("LISTA"))));
            ItemTubo.AddPropriedade(new Propriedade(new NomePropriedade("EXT"), new ValorPropriedade("053", new PropriedadeTipo("LISTA"))));
            ItemTubo.AddPropriedade(new Propriedade(new NomePropriedade("Ø"), new ValorPropriedade("P102", new PropriedadeTipo("LINEAR"))));
            ItemTubo.AddPropriedade(new Propriedade(new NomePropriedade("REVEST"), new ValorPropriedade("A", new PropriedadeTipo("LISTA"))));



            //ItemTubo.AddPropriedade(new PropriedadeEng("PECA", new Sigla("TUB", 3, new FormataLetras())));
            //ItemTubo.AddPropriedade(new PropriedadeEng("MATERIAL", new Sigla("053", 3, new FormataInteiros())));
            //ItemTubo.AddPropriedade(new PropriedadeEng("SCH", new Sigla("SC", 2, new FormataLetras())));
            //ItemTubo.AddPropriedade(new PropriedadeEng("EXT", new Sigla("PL", 2, new FormataLetras())));
            //ItemTubo.AddPropriedade(new PropriedadeEng("Ø", new Sigla("P102", 4, new FormataCaracteres())));
            //ItemTubo.AddPropriedade(new PropriedadeEng("REVEST", new Sigla("A", 1, new FormataLetras())));

            //Sigla tipo = new Sigla("TUB", 3, new FormataLetras());
            //Sigla material = new Sigla("053", 3, new FormataInteiros());
            //Sigla espessura = new Sigla("SCH", "SC", 2, new FormataLetras(), null, material, "BRASS");
            //Sigla extremidade = new Sigla("EXT", "PL", 2, new FormataLetras(), null, espessura, "BRASS");
            // diametro = new Sigla("REVEST", "PL", 4, new FormataCaracteres(), null, extremidade, "BRASS");
            //Sigla revestimento = new Sigla("EXT", "PL", 1, new FormataLetras(), null, diametro, "BRASS");

            //List<Sigla> siglasCodigo = new List<Sigla> { tipo, material, espessura, extremidade, diametro, revestimento };
            //var codigo = new CodigoEspecificacao(siglasCodigo);





            //var siglaDiametroFind = new Repositorio<Cod_Brass_Diametro_Tubo>(_contexto).GetPorGuid(siglaDiametro);
            //if(siglaDiametroFind == null)
            //{
            //    throw new ArgumentNullException("Não existe esta sigla no banco.");
            //}
            //else
            //{
            //    codigo.AdicionaSigla(new Sigla("Diametro", siglaDiametroFind.Sigla, 3, new FormataLetras(), siglaDiametroFind.DiametroExtMilimetro));
            //}







            //codigo.AdicionaSigla(new Sigla("TipoPeca", siglaPeca, 3, new FormataLetras(),0.0));
            //codigo.AdicionaSigla(new Sigla("Material", siglaMaterial, 3, new FormataLetras(), 0.0));
            //codigo.AdicionaSigla(new Sigla("Espessura", siglaEspessura, 3, new FormataLetras(), 0.0));
            //codigo.AdicionaSigla(new Sigla("Fabricacao", siglaFabricacao, 3, new FormataLetras(), 0.0));
            //codigo.AdicionaSigla(new Sigla("Extremidade", siglaExtremidade, 3, new FormataLetras(), 0.0));
            ////codigo.AdicionaSigla(new Sigla("Diametro", siglaDiametro, 3, new FormataLetras()));
            //codigo.AdicionaSigla(new Sigla("Revestimento", siglaRevestimento, 1, new FormataLetras(), 0.0));


            //return codigo;
            //    //new SiglaTipoPeca(siglaPeca),
            //    //new SiglaMaterial(siglaMaterial),
            //    //new SiglaEspessura(siglaEspesura),
            //    //new SiglaFabricacao(siglaFabricacao),
            //    //new SiglaExtremidade(siglaExtremidade),
            //    //new SiglaDiametro(siglaDiametroFind.Sigla, siglaDiametroFind.DiametroExtMilimetro),
            //    //new SiglaRevestimento(siglaRevestimento));
        }
    }
}
