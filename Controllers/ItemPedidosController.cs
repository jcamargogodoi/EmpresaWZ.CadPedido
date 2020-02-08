using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpresaWZ.CadastroPedido.DAL;
using EmpresaWZ.CadastroPedido.Models;

namespace EmpresaWZ.CadastroPedido.Controllers
{
    public class ItemPedidosController : Controller
    {
        private CadastroPedidoContext db = new CadastroPedidoContext();

        // GET: ItemPedidos
        public ActionResult Index()
        {
            var itemPedidos = db.ItemPedidos.Include(i => i.Pedido).Include(i => i.Produto);
            return View(itemPedidos.ToList());
        }

        // GET: ItemPedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedidos.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // GET: ItemPedidos/Create
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.Pedidos, "PedidoId", "PedidoId");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto");
            return View();
        }

        // POST: ItemPedidos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemPedidoId,PedidoId,ProdutoId,Quantidade,ValorItem")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.ItemPedidos.Add(itemPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidos, "PedidoId", "PedidoId", itemPedido.PedidoId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto", itemPedido.ProdutoId);
            return View(itemPedido);
        }

        // GET: ItemPedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedidos.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedidos, "PedidoId", "PedidoId", itemPedido.PedidoId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto", itemPedido.ProdutoId);
            return View(itemPedido);
        }

        // POST: ItemPedidos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemPedidoId,PedidoId,ProdutoId,Quantidade,ValorItem")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidos, "PedidoId", "PedidoId", itemPedido.PedidoId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "NomeProduto", itemPedido.ProdutoId);
            return View(itemPedido);
        }

        // GET: ItemPedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedidos.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // POST: ItemPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPedido itemPedido = db.ItemPedidos.Find(id);
            db.ItemPedidos.Remove(itemPedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
