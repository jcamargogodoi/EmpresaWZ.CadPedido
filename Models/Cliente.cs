using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaWZ.CadastroPedido.Models
{
    public class Cliente
    {

        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}