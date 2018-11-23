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
            var erros = ValidarFormulario();
            if (erros.Count == 0) //Espera valores booleanos
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
            var nordeste = new List<string> { "MA", "PI", "CE", "RN", "PB", "PE", "AL", "SE", "BA" };

            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentual = 0.2m;
                    break;
                case "ES":
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
                    throw new NullReferenceException("ComboBox nulo");
                default:
                    percentual = 0.5m;
                    break;
            }
            //Performance Ruim
            //if (ufComboBox.Text.ToUpper() == "SP")
            //{
            //    percentual = 0.2m;
            //}
            //if (ufComboBox.Text.ToUpper() == "RJ")
            //{
            //    percentual = 0.3m;
            //}
            freteTextBox.Text = percentual.ToString("P1");
            totalTextBox.Text = (valor * (1 + percentual)).ToString("C");
        }

        private List<string> ValidarFormulario()
        {
            var erros = new List<string>();
            if (string.IsNullOrEmpty(clienteTextBox.Text))
            {
                erros.Add("Campo cliente é obrigatório.");
            }
            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("Você precisa selecionar uma UF");
            }
            if (valorTextBox.Text == string.Empty)
            {
                erros.Add("Campo \"Valor\" é obrigatório.");
            }
            else
            {
                //TryParse consegue criar uma variável
                //var valor
                if (!decimal.TryParse(valorTextBox.Text, out decimal valor))
                {
                    //var x = valor;
                    erros.Add("O campo valor está com um formato inválido");
                }
            }
            return erros;
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.ResetText();
            valorTextBox.Text = null;
            ufComboBox.SelectedIndex = -1;
            freteTextBox.Clear();
            totalTextBox.Text = "";
            clienteTextBox.Focus();
        }
    }
}
