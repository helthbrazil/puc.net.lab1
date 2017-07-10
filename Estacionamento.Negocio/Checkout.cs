using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    class Checkout : ICommand {


        public bool Validar(DtoCarro carro) {
            if (String.Equals(carro.Placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", carro.Placa.Trim()));

            if (!Operacoes._estacionamento.ContainsKey(carro.Placa.Trim()))
                throw new Exception(String.Format("Carro placa '{0}' NÃO existe!", carro.Placa.Trim()));

            return true;
        }

        public double Run(DtoCarro carro) {
            Validar(carro);
            DateTime horaEntrada = Operacoes._estacionamento[carro.Placa];
            Operacoes._estacionamento.Remove(carro.Placa);

            return CalcularValorEstacionamento(horaEntrada);
        }

        private double CalcularValorEstacionamento(DateTime entrada) {
            
            var permanencia = DateTime.Now.Subtract(entrada);
            return Math.Round((permanencia.TotalMinutes / 3), 2); // 3 reais é o valor mínimo            
        }
    }
}
