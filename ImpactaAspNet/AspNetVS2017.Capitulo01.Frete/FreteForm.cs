using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Frete
{
    public partial class FreteForm : Form
    {
        public FreteForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var erros = ValidarFomulario();

            if (erros.Count == 0)
            {
                Calcular();
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros),
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void Calcular()
        {
            var percentual = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);
            var nordeste = new List<string> { "BA", "PE", "AL" };

            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentual = 0.2m;
                    break;
                case "RJ":
                    percentual = 0.3m;
                    break;
                case "MG":
                    percentual = 0.35m;
                    break;
                case "AM":
                    percentual = 0.6m;
                    break;
                case var uf when nordeste.Contains(uf):
                    percentual = 0.45m;
                    break;
                case null:
                    throw new NullReferenceException("ComboBox Null");
                default:
                    percentual = 0.5m;
                    break;
            }

            freteTextBox.Text = percentual.ToString("P1");
            totalTextBox.Text = (valor * (1 + percentual)).ToString("C");

            /*if (ufComboBox.Text.ToUpper() == "SP")
            {
                percentual = 0.2m;
            }
            else if (ufComboBox.Text.ToUpper() == "RJ")
            {
                percentual = 0.3m;
            }*/

        }

        private List<string> ValidarFomulario()
        {
            var erros = new List<string>();

            //if (clienteTextBox.Text != "")
            //if (string.IsNullOrEmpty(clienteTextBox.Text))
            if (clienteTextBox.Text == string.Empty)
            {
                erros.Add("O campo cliente é obrigatório.");
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("O campo UF é obrigatório.");
            }

            if (valorTextBox.Text == string.Empty)
            {
                erros.Add("O campo valor é obrigatório.");
            }
            else
            {
                if (!decimal.TryParse(valorTextBox.Text, out decimal valor))
                {
                    erros.Add("O campo valor está com o formato inválido.");
                }
            }

            return erros;

        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.Text = string.Empty;
            ufComboBox.SelectedIndex = -1;
            valorTextBox.Text = "";
            freteTextBox.Clear();
            totalTextBox.Text = null;

            clienteTextBox.Focus();

        }
    }
}
