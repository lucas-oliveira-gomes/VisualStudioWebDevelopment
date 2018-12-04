using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{

    //TODO: OO(Orientação a Objetos) -- Classe (entidade) ou Abstração
    public abstract class Veiculo //: Object (Não necessário pois todas classes herdam de Object)
    {
        //public Veiculo()
        //{
        //    Id = Guid.NewGuid();
        //}
        public Guid Id { get; set; } = Guid.NewGuid();
        //public string Placa
        //{
        //    get
        //    {
        //        return Placa.ToUpper(); //Loop infinito
        //    }
        //    set
        //    {
        //        Placa = value.ToUpper();
        //    }
        //}

        private string placa;

        //TODO: OO -- Encapsulamento.
        public string Placa
        {
            get { return placa?.ToUpper(); }
            set { placa = value?.ToUpper(); }
        }

        public DateTime Agora
        {
            get { return DateTime.Now; }
        }



        public int Ano { get; set; }
        public string Observacao { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
        public abstract List<string> Validar();

        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Ano < 1980 || Ano > DateTime.Now.Year + 2)
            {
                erros.Add($"O ano informado {Ano} não é válido");
            }
            return erros;
        }

        public override string ToString()
        {
            return string.Format("Marca: {0}, Modelo: {1}, Placa: {2}", this.Modelo.Marca.Nome, this.Modelo.Nome, this.Placa);
            //return base.ToString();
        }
    }
}
