using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    class Checkin : ICommand {


        public bool Validar(DtoCarro carro) {
            if (String.Equals(carro.Placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", carro.Placa));

            if (Operacoes._estacionamento.Count == Operacoes.VAGAS_TOTAIS)
                throw new Exception("Estacionamento cheio!");

            if (Operacoes._estacionamento.ContainsKey(carro.Placa))
                throw new Exception(String.Format("Carro placa '{0} já existe!", carro.Placa));
            return true;
        }

        public double Run(DtoCarro carro) {
            Validar(carro);
            Operacoes._estacionamento.Add(carro.Placa, DateTime.Now);
            return 1d;
        }
    }
}
