using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    interface ICommand {
        bool Validar(DtoCarro carro);
        double Run(DtoCarro carro);
    }
}
