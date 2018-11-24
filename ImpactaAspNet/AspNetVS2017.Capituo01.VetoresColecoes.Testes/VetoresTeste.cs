using System;
using System.Linq;
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

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.5m, 78, 1.59m };
            Array.Resize(ref decimais, 5);

            decimais[3] = 20.01m;
        }

        [TestMethod]
        public void OrdenacaodorTeste()
        {
            var decimais = new decimal[] { 35, 89m, 0.5m, 78, 1.59m };
            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], 0.5m);
        }

        [TestMethod]
        public void MediaTeste()
        {
            decimal[] valores = { 0.4m, 1.6m, 0.8m, 0.3m };

            var media = ObterMedia(valores);
            Console.WriteLine(media);
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 35.89m, 0.5m, 78, 1.59m };
            Console.WriteLine(ObterMedia(decimais));
            Console.WriteLine(ObterMedia(2, 8, 9.8m, 4.23m));
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            const string nome = "Hejlsberg";
            Assert.AreEqual(nome[0], 'H');
            foreach (var @char in nome)
            {
                Console.WriteLine(@char);
            }
        }

        private decimal ObterMedia(decimal num1, decimal num2)
        {
            decimal media = 0;
            media = (num1 + num2) / 2;
            return media;
        }

        private decimal ObterMedia(params decimal[] decimais)
        {
            //return decimais.Average();
            decimal media = 0;
            var qtdItens = decimais.Length;
            decimal total = 0;

            foreach (var @decimal in decimais)
            {
                total += @decimal;
            }
            media = total / qtdItens;
            return media;
        }
    }
}
