using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetVS2017.Capituo01.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var strings = new string[10];
            strings[0] = "A";
            //strings[-1] = "Outra coisa"; //Erro de execução (matrizes iniciam a partir do 0)
            //strings[10] = "B"; // Erro de execução (o tamanho informado não é alcançavel)
            var decimais = new decimal[] { 0.5m, 78, 1.59m };

            decimal[] novosDecimais = { 0.99m, 5, 45.646m }; // não pode user var

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }
            Console.WriteLine($"Tamanho do vetor: {decimais.Length}");
        }
    }
}
