using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetVS2017.Capitulo01.Repeticao.Testes
{
    [TestClass]
    public class RepeticaoTeste
    {
        [TestMethod]
        public void ForAninhadoTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i}*{j} = {i * j}");
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        [TestMethod]
        public void EstruturaForTeste()
        {
            var i = 1;
            for (Console.WriteLine("Iniciou"); i < 3; Console.WriteLine(i))
            {
                i++;
            }

            /*
            for (1. Inicialização;2. Condição de Execução; 4. Pós-Execução)
            {
                3. Execução;
            }
            */
        }
    }
}
