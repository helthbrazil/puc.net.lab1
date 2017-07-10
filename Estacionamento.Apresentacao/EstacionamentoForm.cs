using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estacionamento.Negocio;

namespace Estacionamento.Apresentacao
{
    public partial class EstacionamentoForm : Form
    {
        public EstacionamentoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DtoCarro carro = new DtoCarro();
            carro.Placa = textBox1.Text;
            carro.Horario = DateTime.Now;

            try
            {

                Operacoes.Checkin(carro);
                MessageBox.Show(String.Format("Placa '{0}' adicionada.", carro.Placa));
                textBox1.Text = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DtoCarro carro = new DtoCarro();
            carro.Placa = textBox1.Text;

            try
            {
                var valor = Operacoes.Checkout(carro);

                MessageBox.Show(String.Format("Placa '{0}' valor de R${1}.", carro.Placa, valor));
                textBox1.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}