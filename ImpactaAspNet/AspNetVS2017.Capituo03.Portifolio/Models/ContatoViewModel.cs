using System.ComponentModel.DataAnnotations;

namespace AspNetVS2017.Capituo03.Portifolio.Models
{
    public class ContatoViewModel
    {
        public int Id { get; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}