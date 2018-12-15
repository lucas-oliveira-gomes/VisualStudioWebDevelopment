using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; } = true;

        public virtual Categoria Categoria { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
        public virtual ProdutoImagem Imagem { get; set; }
    }
}
