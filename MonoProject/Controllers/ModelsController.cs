using System.Threading.Tasks;
using System.Web.Mvc;
using Service.Repositories;

namespace MonoProject.Controllers
{
    [RoutePrefix("vehiclemodels")]
    public class ModelsController : Controller
    {
       IMakeRepository makeRepo;

        public ModelsController(IMakeRepository makeRepo)
        {
            this.makeRepo = makeRepo;
        }

        [Route]
        // GET: Models
        public async Task<ActionResult> Index()
        {
            return View(makeRepo.GetMakesAsync());
        }

        //// GET: Models/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Model model = await db.Models.FindAsync(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        //// GET: Models/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Models/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "ID,Name,Abrv")] Model model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Models.Add(model);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

        //// GET: Models/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Model model = await db.Models.FindAsync(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        //// POST: Models/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Abrv")] Model model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(model).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        //// GET: Models/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Model model = await db.Models.FindAsync(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        //// POST: Models/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Model model = await db.Models.FindAsync(id);
        //    db.Models.Remove(model);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
