using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
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

        BaseMDBRepositorio<ValorTabelado> _valorTabeladoRepositorio;

        public CarregaValoresTabeladosTubulacaoCommandHandle()
        {
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
        }


        public async Task<Unit> Handle(CarregaValoresTabeladosTubulacaoCommand command, CancellationToken cancellationToken)
        {
            var valoresTabelados = _valorTabeladoRepositorio.Obter();

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


                        //var espera = "";
                        //}

                        //if (info.Name != "GUID" && info.Name != "CODIGO" && info.Name != "PnPID")
                        //{
                        var valor = info.GetValue(item, null);





                        if (valor != null)
                        {
                            if (valor.ToString() == teste)
                            {
                                var valorTabelado = valoresTabelados.FirstOrDefault(x => x.VALOR == valor.ToString());

                                if (valorTabelado == null)
                                {
                                    valorTabelado = new ValorTabelado(valor.ToString(),"");

                                    _valorTabeladoRepositorio.Inserir(valorTabelado);
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
