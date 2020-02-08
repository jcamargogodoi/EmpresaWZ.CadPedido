using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Web;
namespace EmpresaWZ.CadastroPedido.Models
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }

        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public double ValorItem { get; set; }
    }
}