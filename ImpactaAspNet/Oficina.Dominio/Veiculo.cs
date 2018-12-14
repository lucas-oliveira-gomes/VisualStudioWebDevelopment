using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO - classe(entidade) ou abstração
    //classe por default herda de object
    public abstract class Veiculo //: Object
    {
        //
        //public Veiculo()
        //{
        //    Id = Guid.NewGuid();
        //}

        public Guid Id { get; set; } = Guid.NewGuid();

        //public string Placa
        //{
        //    get
        //    {
        //        //get sempre retorna com return
        //        return Placa.ToUpper();
        //    }
        //    set
        //    {
        //        //value tem que ser retornado no set
        //        Placa = value.ToUpper();
        //    }
        //}


        private string placa;

        //ToDo - OO - Encapsulameto.
        public string Placa
        {
            get { return placa?.ToUpper(); }
            set { placa = value?.ToUpper(); }
        }



        public int Ano { get; set; }
        public string Observacao { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }

        public DateTime Agora
        {
            get { return DateTime.Now; }
        }

        public abstract List<string> Validar();

        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Ano < 1979 || Ano > DateTime.Now.Year + 1)
            {
                erros.Add($"O ano Informado ({Ano}) não é valido");
            }

            return erros;
        }

        public override string ToString()
        {

            return string.Format("{0} {1} {2}", Modelo.Marca.Nome, Modelo.Nome, Placa);

            //return base.ToString();
        }
    }
}
