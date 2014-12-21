using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VM.DataAccessLayer.EDM;

namespace VirtualManager.Controllers.ModuleManage
{
    public class ModuleAssociationController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: ModuleAssociation
        public async Task<ActionResult> Index()
        {
            var moduleProjectAssociation = db.ModuleProjectAssociation.Include(m => m.ModuleTable).Include(m => m.ProjectTable);
            return View(await moduleProjectAssociation.ToListAsync());
        }

        // GET: ModuleAssociation/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleProjectAssociation moduleProjectAssociation = await db.ModuleProjectAssociation.FindAsync(id);
            if (moduleProjectAssociation == null)
            {
                return HttpNotFound();
            }
            return View(moduleProjectAssociation);
        }

        // GET: ModuleAssociation/Create
        public ActionResult Create()
        {
            ViewBag.ModuleId = new SelectList(db.ModuleTable, "Id", "ModuleName");
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName");
            return View();
        }

        // POST: ModuleAssociation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectId,ModuleId,TurnOn")] ModuleProjectAssociation moduleProjectAssociation)
        {
            if (ModelState.IsValid)
            {
                db.ModuleProjectAssociation.Add(moduleProjectAssociation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleId = new SelectList(db.ModuleTable, "Id", "ModuleName", moduleProjectAssociation.ModuleId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", moduleProjectAssociation.ProjectId);
            return View(moduleProjectAssociation);
        }

        // GET: ModuleAssociation/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleProjectAssociation moduleProjectAssociation = await db.ModuleProjectAssociation.FindAsync(id);
            if (moduleProjectAssociation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleId = new SelectList(db.ModuleTable, "Id", "ModuleName", moduleProjectAssociation.ModuleId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", moduleProjectAssociation.ProjectId);
            return View(moduleProjectAssociation);
        }

        // POST: ModuleAssociation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,ModuleId,TurnOn")] ModuleProjectAssociation moduleProjectAssociation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleProjectAssociation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleId = new SelectList(db.ModuleTable, "Id", "ModuleName", moduleProjectAssociation.ModuleId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", moduleProjectAssociation.ProjectId);
            return View(moduleProjectAssociation);
        }

        // GET: ModuleAssociation/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleProjectAssociation moduleProjectAssociation = await db.ModuleProjectAssociation.FindAsync(id);
            if (moduleProjectAssociation == null)
            {
                return HttpNotFound();
            }
            return View(moduleProjectAssociation);
        }

        // POST: ModuleAssociation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ModuleProjectAssociation moduleProjectAssociation = await db.ModuleProjectAssociation.FindAsync(id);
            db.ModuleProjectAssociation.Remove(moduleProjectAssociation);
            await db.SaveChangesAsync();
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
