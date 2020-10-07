using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaValoresTabelasDoArquivoCatalogo.Tubulacao
{
    public class CarregaValoresTabeladosTubulacaoCommandHandle : Notifiable, IRequestHandler<CarregaValoresTabeladosTubulacaoCommand>
    {

 

      


        public async Task<Unit> Handle(CarregaValoresTabeladosTubulacaoCommand command, CancellationToken cancellationToken)
        {
            var valorTabeladoRepositorio = RepoValores.Instancia(command.Conexao);

            //var valoresTabelados = valorTabeladoRepositorio.ObterTodos();

            //var tubos = valoresTabelados.Where(x => x.VALOR.ToString().Split(',')[0].Trim() == "TUBO");
            var teste = "TUBO, AC ASTM A-53 Gr.B, SS ou CC LONG. (TIPO S ou TIPO E), SCH STD, PC CONF. ASME B16.25, NORMA DIM. ASME B36.10 - 3\"";

            foreach (var item in command.EngineeringItems)
            {



                Type type = item.GetType();

                var props = type.GetProperties();

                foreach (var info in type.GetProperties())
                {


                    PropertyInfo campo = type.GetProperty(info.Name);



                    if (info.Name == "PartSizeLongDesc")
                    {

                        var valor = info.GetValue(item, null);

                        if (valor != null)
                        {
                            if (valor.ToString() == teste)
                            {
                                var valorTabelado = valorTabeladoRepositorio.ObterDescricao(valor.ToString());

                                if (valorTabelado == null)
                                {
                                    valorTabelado = new ValorTabelado(valor.ToString(),"");

                                    valorTabeladoRepositorio.CadastrarValor(valorTabelado);
                                }
                            }

                        }
                    }

                }
            }


            return Unit.Value;
        }
    }
}
