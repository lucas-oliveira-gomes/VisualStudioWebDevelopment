using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo1.Troco
{
    public partial class TrocoForm : Form
    {
        public TrocoForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            decimal valorDaCompra = 0m;
            valorDaCompra = Convert.ToDecimal(valorCompraTextBox.Text);
            decimal valorPago = 0m;
            valorPago = Convert.ToDecimal(valorPagoTextBox.Text);
            //valorPago = decimal.Parse(valorPagoTextBox.Text);
            decimal troco = valorPago - valorDaCompra;
            TrocoTextBox.Text = troco.ToString("C2");

            var moedas = new decimal[] { 1, 0.5m, 0.25m, 0.1m, 0.05m, 0.01m };

            for (int i = 0; i < moedas.Length; i++)
            {
                moedasListView.Items[i].Text = ((int)(troco / moedas[i])).ToString();
                troco %= moedas[i];
            }
        }
    }
}
