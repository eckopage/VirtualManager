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
    public class FoodCoastController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: FoodCoast
        public async Task<ActionResult> Index()
        {
            var foodDrinkTable = db.FoodDrinkTable.Include(f => f.MeasureTable).Include(f => f.ProviderFoodCoastTable);
            return View(await foodDrinkTable.ToListAsync());
        }

        // GET: FoodCoast/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinkTable foodDrinkTable = await db.FoodDrinkTable.FindAsync(id);
            if (foodDrinkTable == null)
            {
                return HttpNotFound();
            }
            return View(foodDrinkTable);
        }

        // GET: FoodCoast/Create
        public ActionResult Create()
        {
            ViewBag.MeasureId = new SelectList(db.MeasureTable, "Id", "Name");
            ViewBag.ProviderId = new SelectList(db.ProviderFoodCoastTable, "Id", "CompanyName");
            return View();
        }

        // POST: FoodCoast/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,ShortNameProduct,MeasureId,Description,PhotoPath,ProviderId,HowMuch")] FoodDrinkTable foodDrinkTable)
        {
            if (ModelState.IsValid)
            {
                db.FoodDrinkTable.Add(foodDrinkTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MeasureId = new SelectList(db.MeasureTable, "Id", "Name", foodDrinkTable.MeasureId);
            ViewBag.ProviderId = new SelectList(db.ProviderFoodCoastTable, "Id", "CompanyName", foodDrinkTable.ProviderId);
            return View(foodDrinkTable);
        }

        // GET: FoodCoast/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinkTable foodDrinkTable = await db.FoodDrinkTable.FindAsync(id);
            if (foodDrinkTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeasureId = new SelectList(db.MeasureTable, "Id", "Name", foodDrinkTable.MeasureId);
            ViewBag.ProviderId = new SelectList(db.ProviderFoodCoastTable, "Id", "CompanyName", foodDrinkTable.ProviderId);
            return View(foodDrinkTable);
        }

        // POST: FoodCoast/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,ShortNameProduct,MeasureId,Description,PhotoPath,ProviderId,HowMuch")] FoodDrinkTable foodDrinkTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodDrinkTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MeasureId = new SelectList(db.MeasureTable, "Id", "Name", foodDrinkTable.MeasureId);
            ViewBag.ProviderId = new SelectList(db.ProviderFoodCoastTable, "Id", "CompanyName", foodDrinkTable.ProviderId);
            return View(foodDrinkTable);
        }

        // GET: FoodCoast/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinkTable foodDrinkTable = await db.FoodDrinkTable.FindAsync(id);
            if (foodDrinkTable == null)
            {
                return HttpNotFound();
            }
            return View(foodDrinkTable);
        }

        // POST: FoodCoast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FoodDrinkTable foodDrinkTable = await db.FoodDrinkTable.FindAsync(id);
            db.FoodDrinkTable.Remove(foodDrinkTable);
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
