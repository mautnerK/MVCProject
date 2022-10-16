using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MonoProject.Models;
using MonoProject.Service.Models;
using Service.Service;

namespace MonoProject.Controllers
{
    [RoutePrefix("vehiclemodels")]
    public class ModelsController : Controller
    {
       IModelService modelService;
       private IMapper mapper;


        public ModelsController(IModelService modelService, IMapper imapper)
        {
            this.modelService = modelService;
            mapper = imapper;
        }

        [Route]
        // GET: Models
        public async Task<ActionResult> Index()
        {
            return  View(await modelService.GetModelAsync());
        }

        // GET: Models/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelViewModel modelVM = mapper.Map<ModelViewModel>(await modelService.GetModelByIdAsync(id));
            if (modelVM == null)
            {
                return HttpNotFound();
            }
            return View(modelVM);
        }

        // GET: Models/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Abrv")] ModelViewModel modelVM)
        {
            var model = mapper.Map<Model>(modelVM);
            if (ModelState.IsValid)
            {   await modelService.CreateModelAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = await modelService.GetModelByIdAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Abrv")] Model model)
        {
            if (ModelState.IsValid)
            {
                await modelService.UpdateModelAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = await modelService.GetModelByIdAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Model model = await modelService.GetModelByIdAsync(id);
            await modelService.DeleteModelAsync(model.ID);
            return RedirectToAction("Index");
        }

  
    }
}
