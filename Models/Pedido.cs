using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaWZ.CadastroPedido.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }



    }
}