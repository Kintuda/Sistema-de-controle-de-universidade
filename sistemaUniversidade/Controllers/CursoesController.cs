using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sistemaUniversidade.Models;

namespace sistemaUniversidade.Controllers
{
    public class CursoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cursoes
        [Authorize]
        public ActionResult Index()
        {
            var cursoes = db.Cursoes.Include(c => c.Departamento).Include(c => c.Professor);
            return View(cursoes.ToList());
        }

        // GET: Cursoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "ID", "Nome");
            ViewBag.ProfessorID = new SelectList(db.Professors, "ID", "Nome");
            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,inicioAula,Duracao,DepartamentoID,ProfessorID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursoes.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "ID", "Nome", curso.DepartamentoID);
            ViewBag.ProfessorID = new SelectList(db.Professors, "ID", "Nome", curso.ProfessorID);
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "ID", "Nome", curso.DepartamentoID);
            ViewBag.ProfessorID = new SelectList(db.Professors, "ID", "Nome", curso.ProfessorID);
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,inicioAula,Duracao,DepartamentoID,ProfessorID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "ID", "Nome", curso.DepartamentoID);
            ViewBag.ProfessorID = new SelectList(db.Professors, "ID", "Nome", curso.ProfessorID);
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursoes.Find(id);
            db.Cursoes.Remove(curso);
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
