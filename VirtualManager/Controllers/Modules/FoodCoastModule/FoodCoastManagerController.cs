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
    public class FoodCoastManagerController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: FoodCoastManager
        public async Task<ActionResult> Index()
        {
            var foodDrinkProjectAssignment = db.FoodDrinkProjectAssignment.Include(f => f.FoodDrinkTable).Include(f => f.ProjectTable);
            return View(await foodDrinkProjectAssignment.ToListAsync());
        }

        // GET: FoodCoastManager/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinkProjectAssignment foodDrinkProjectAssignment = await db.FoodDrinkProjectAssignment.FindAsync(id);
            if (foodDrinkProjectAssignment == null)
            {
                return HttpNotFound();
            }
            return View(foodDrinkProjectAssignment);
        }

        // GET: FoodCoastManager/Create
        public ActionResult Create()
        {
            ViewBag.FoodDrinkId = new SelectList(db.FoodDrinkTable, "Id", "FullName");
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName");
            return View();
        }

        // POST: FoodCoastManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectId,FoodDrinkId,FoodDrinkPrice,DateCreated,IsEnabled,HowMany,Description")] FoodDrinkProjectAssignment foodDrinkProjectAssignment)
        {
            if (ModelState.IsValid)
            {
                db.FoodDrinkProjectAssignment.Add(foodDrinkProjectAssignment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FoodDrinkId = new SelectList(db.FoodDrinkTable, "Id", "FullName", foodDrinkProjectAssignment.FoodDrinkId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", foodDrinkProjectAssignment.ProjectId);
            return View(foodDrinkProjectAssignment);
        }

        // GET: FoodCoastManager/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinkProjectAssignment foodDrinkProjectAssignment = await db.FoodDrinkProjectAssignment.FindAsync(id);
            if (foodDrinkProjectAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodDrinkId = new SelectList(db.FoodDrinkTable, "Id", "FullName", foodDrinkProjectAssignment.FoodDrinkId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", foodDrinkProjectAssignment.ProjectId);
            return View(foodDrinkProjectAssignment);
        }

        // POST: FoodCoastManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,FoodDrinkId,FoodDrinkPrice,DateCreated,IsEnabled,HowMany,Description")] FoodDrinkProjectAssignment foodDrinkProjectAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodDrinkProjectAssignment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FoodDrinkId = new SelectList(db.FoodDrinkTable, "Id", "FullName", foodDrinkProjectAssignment.FoodDrinkId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", foodDrinkProjectAssignment.ProjectId);
            return View(foodDrinkProjectAssignment);
        }

        // GET: FoodCoastManager/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinkProjectAssignment foodDrinkProjectAssignment = await db.FoodDrinkProjectAssignment.FindAsync(id);
            if (foodDrinkProjectAssignment == null)
            {
                return HttpNotFound();
            }
            return View(foodDrinkProjectAssignment);
        }

        // POST: FoodCoastManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FoodDrinkProjectAssignment foodDrinkProjectAssignment = await db.FoodDrinkProjectAssignment.FindAsync(id);
            db.FoodDrinkProjectAssignment.Remove(foodDrinkProjectAssignment);
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
