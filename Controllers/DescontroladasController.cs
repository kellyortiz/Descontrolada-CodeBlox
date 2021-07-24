using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using codeBlox.Models;

namespace codeBlox.Controllers
{
    public class DescontroladasController : Controller
    {
        private DescontroladaContext db = new DescontroladaContext();

        // GET: Descontroladas
        public ActionResult Index()
        {
            return View(db.descontroladaBD.ToList());
        }

        // GET: Descontroladas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descontrolada descontrolada = db.descontroladaBD.Find(id);
            if (descontrolada == null)
            {
                return HttpNotFound();
            }
            return View(descontrolada);
        }

        // GET: Descontroladas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Descontroladas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,preco,descricao,Quantidade,DtCadastro,tipoProduto")] Descontrolada descontrolada)
        {
            if (ModelState.IsValid)
            {
                db.descontroladaBD.Add(descontrolada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(descontrolada);
        }

        // GET: Descontroladas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descontrolada descontrolada = db.descontroladaBD.Find(id);
            if (descontrolada == null)
            {
                return HttpNotFound();
            }
            return View(descontrolada);
        }

        // POST: Descontroladas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,preco,descricao,Quantidade,DtCadastro,tipoProduto")] Descontrolada descontrolada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descontrolada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descontrolada);
        }

        // GET: Descontroladas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descontrolada descontrolada = db.descontroladaBD.Find(id);
            if (descontrolada == null)
            {
                return HttpNotFound();
            }
            return View(descontrolada);
        }

        // POST: Descontroladas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Descontrolada descontrolada = db.descontroladaBD.Find(id);
            db.descontroladaBD.Remove(descontrolada);
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
