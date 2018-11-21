using System;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo1.Variaveis
{
    public partial class VariaveisForm : Form
    {
        int x = 32;
        int w = 45;
        int y = 16;
        int z = 32;

        public VariaveisForm()
        {
            InitializeComponent();
        }
        /*Assinatura do método*/
        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = 2;
            int b = 6, c = 10;
            int d = 13;

            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ", b));
            resultadoListBox.Items.Add(string.Format("c = {0}", c));
            resultadoListBox.Items.Add($"d = {d}");


            resultadoListBox.Items.Add("-------------------------------------");

            resultadoListBox.Items.Add("c * d = " + (c * d));
            resultadoListBox.Items.Add("c / d = " + (c / d));
            resultadoListBox.Items.Add("d % a = " + (d % a));









            //decimal valor = 22.39M;
            //string nome = "Lucas";
            //char ch = '\n';

            //bool aprovado = true;
            //DateTime dataNascimento = new DateTime(1986, 10, 11);

            ////int e = 10; e já está sendo usado na  assinatura

            ////declarar uma variável usando var para que o C# descubra o tipo por inferência
            //var sobrenome = "Gomes";


            ////variável precisa ser inicializada antes de ser utilizada
            ////decimal nota;
            ////if (nota > 7)
            ////{      }

            ////não usar palavras reservadas como nome de variáveis
            ////var decimal = 0.2m;

            //object recebe qualquer coisa
            //object meuObjeto = 45;
            //meuObjeto = "Nome";

        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;
            resultadoListBox.Items.Add("x = " + x);
            //x = x - 3;
            x -= 3;
            resultadoListBox.Items.Add("x = " + x);
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            a = 5;
            resultadoListBox.Items.Add("Exemplo Pré-Incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + ++a = " + (2 + ++a));
            resultadoListBox.Items.Add("a = " + a);

            a = 5;
            resultadoListBox.Items.Add("Exemplo Pós-Incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + a++ = " + (2 + a++));
            resultadoListBox.Items.Add("a = " + a);

        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApresentarVariaveis();

            resultadoListBox.Items.Add("w <= x =" + (w <= x));
            resultadoListBox.Items.Add("x == z =" + (x == z));
            resultadoListBox.Items.Add("x != z =" + (x != z));


        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApresentarVariaveis();

            resultadoListBox.Items.Add("w <= x || y == 16 =" + (w <= x || y == 16));
            resultadoListBox.Items.Add("x == z && x != z =" + (x == z && x != z));

            resultadoListBox.Items.Add("!(y > w) =" + (!(y > w)));

        }

        private void ApresentarVariaveis()
        {
            resultadoListBox.Items.Add("x = " + x);
            resultadoListBox.Items.Add("w = " + w);
            resultadoListBox.Items.Add("y = " + y);
            resultadoListBox.Items.Add("z = " + z);

            resultadoListBox.Items.Add(new string('-', 50));
        }

        private void ternariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;
            ano = 2014;
            resultadoListBox.Items.Add(string.Format("O ano {0} é bissexto? {1}.", ano, ano % 4 == 0 ? "Sim" : "Não"));

            ano = 2016;
            resultadoListBox.Items.Add(string.Format("O ano {0} é bissexto? {1}.", ano, DateTime.IsLeapYear(ano) ? "Sim" : "Não"));
        }
    }
}
