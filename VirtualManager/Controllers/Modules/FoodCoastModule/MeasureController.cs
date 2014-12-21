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

namespace VirtualManager.Controllers.Modules.FoodCoastModule
{
    public class MeasureController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: Measure
        public async Task<ActionResult> Index()
        {
            return View(await db.MeasureTable.ToListAsync());
        }

        // GET: Measure/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasureTable measureTable = await db.MeasureTable.FindAsync(id);
            if (measureTable == null)
            {
                return HttpNotFound();
            }
            return View(measureTable);
        }

        // GET: Measure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Measure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ShortName")] MeasureTable measureTable)
        {
            if (ModelState.IsValid)
            {
                db.MeasureTable.Add(measureTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(measureTable);
        }

        // GET: Measure/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasureTable measureTable = await db.MeasureTable.FindAsync(id);
            if (measureTable == null)
            {
                return HttpNotFound();
            }
            return View(measureTable);
        }

        // POST: Measure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ShortName")] MeasureTable measureTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measureTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(measureTable);
        }

        // GET: Measure/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasureTable measureTable = await db.MeasureTable.FindAsync(id);
            if (measureTable == null)
            {
                return HttpNotFound();
            }
            return View(measureTable);
        }

        // POST: Measure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MeasureTable measureTable = await db.MeasureTable.FindAsync(id);
            db.MeasureTable.Remove(measureTable);
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
