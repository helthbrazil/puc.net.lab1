using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    /// <summary>
    /// Classe com as operações de um estacionamento.
    /// </summary>
    public sealed class Operacoes
    {
        public const int VAGAS_TOTAIS = 15;
        public static IDictionary<string, DateTime> _estacionamento = new Dictionary<string, DateTime>();

        public static double Checkin(DtoCarro carro){
            ICommand checkin = new Checkin();
            return checkin.Run(carro);
        }

        public static double Checkout(DtoCarro carro) {
            ICommand checkout = new Checkout();
            return checkout.Run(carro);
        }

    }
}
