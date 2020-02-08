using EmpresaWZ.CadastroPedido.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EmpresaWZ.CadastroPedido.DAL
{
    public class CadastroPedidoContext : DbContext
    {
        public CadastroPedidoContext() : base("PedidoConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }  
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }


    }
}