using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetVS2017.Capituo01.VetoresColecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(50) { 2, 1, 2, 6, 125 };
            inteiros.Add(22);
            //inteiros[12] = 89;

            var maisInteiros = new List<int> { 21, 72, 6, 14 };

            inteiros.AddRange(maisInteiros);
            //inteiros.Insert(0, 29); //Se o índice não existe vai dar Exceção

            inteiros.Remove(2);
            //inteiros.RemoveAt(189); //Se o índice não existe vai dar Exceção

            inteiros.Sort();

            var primeiro = inteiros[0];
            //var primeiro = inteiros.First() //Requer Linq dá erro se a Lista estiver vazia
            //var primeiro = inteiros.FirstOrDefault() //Requer Linq dá erro se a Lista estiver vazia

            var utilmo = inteiros[inteiros.Count - 1];
            var estahVazia = inteiros.Count == 0;

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}:{inteiro}");
            }
            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < inteiros.Count; i++)
            {
                Console.WriteLine($"{i}:{inteiros[i]}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();
            feriados.Add(new DateTime(2018, 12, 25), "Natal");
            feriados.Add(new DateTime(2019, 1, 1), "Ano Novo");
            feriados.Add(new DateTime(2019, 1, 25), "Aniversário São Paulo");
            //feriados.Add(new DateTime(2019, 1, 25), "Aniversário da Fulaninha");

            var natal = feriados[new DateTime(2018, 12, 25)];

            foreach (var feriado in feriados)
            {
                //Console.WriteLine($"{feriado.Key.ToShortDateString()} é {feriado.Value}");
                //Console.WriteLine(string.Format("{0:dd/MM} é {1}", feriado.Key, feriado.Value));
                Console.WriteLine(string.Format("{0} é {1}", feriado.Key.ToString("dd/MM"), feriado.Value));
            }

            Console.WriteLine(feriados.ContainsKey(Convert.ToDateTime("25/12/2018")));
            Console.WriteLine(feriados.ContainsValue("Ano Novo"));
        }
    }
}
