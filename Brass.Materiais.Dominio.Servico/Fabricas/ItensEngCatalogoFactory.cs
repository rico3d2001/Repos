using Brass.Materiais.Dominio.Servico.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Fabricas
{
    public class ItensEngCatalogoFactory : AbstractFactory
    {
        ItensEngPlant3dService _itensEngPlant3dService;
        public ItensEngCatalogoFactory(ItensEngPlant3dService itensEngPlant3dService)
        {
            _itensEngPlant3dService = itensEngPlant3dService;
        }

        public void Criar()
        {
            var listaPlant3d = _itensEngPlant3dService.ObtemPlant3dData();

            foreach (var itemPlant3d in listaPlant3d)
            {
                //itemPlant3d.GU
            }

        }



    }
}
