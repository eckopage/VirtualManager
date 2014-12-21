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
    public class ModuleSettingsController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: ModuleSettings
        public async Task<ActionResult> Index()
        {
            return View(await db.ModuleTable.ToListAsync());
        }

        // GET: ModuleSettings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTable moduleTable = await db.ModuleTable.FindAsync(id);
            if (moduleTable == null)
            {
                return HttpNotFound();
            }
            return View(moduleTable);
        }

        // GET: ModuleSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModuleSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ModuleName,ModuleDescription,ModuleDLLname,Created,Version,DeveloperName,StableVersion,UpdatedDLL,PathToDLL")] ModuleTable moduleTable)
        {
            if (ModelState.IsValid)
            {
                db.ModuleTable.Add(moduleTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(moduleTable);
        }

        // GET: ModuleSettings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTable moduleTable = await db.ModuleTable.FindAsync(id);
            if (moduleTable == null)
            {
                return HttpNotFound();
            }
            return View(moduleTable);
        }

        // POST: ModuleSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ModuleName,ModuleDescription,ModuleDLLname,Created,Version,DeveloperName,StableVersion,UpdatedDLL,PathToDLL")] ModuleTable moduleTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(moduleTable);
        }

        // GET: ModuleSettings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTable moduleTable = await db.ModuleTable.FindAsync(id);
            if (moduleTable == null)
            {
                return HttpNotFound();
            }
            return View(moduleTable);
        }

        // POST: ModuleSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ModuleTable moduleTable = await db.ModuleTable.FindAsync(id);
            db.ModuleTable.Remove(moduleTable);
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
