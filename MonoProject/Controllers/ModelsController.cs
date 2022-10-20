using System.Collections.Generic;
using System.Linq;
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

        //[Route]
        //// GET: Models
        //public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //    ViewBag.CurrentSort = sortOrder;
        //    ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.NameSortParmAbrv = string.IsNullOrEmpty(sortOrder) ? "abrv_desc" : "";
        //    var modelsVM = mapper.Map<List<ModelViewModel>>(await modelService.GetModelAsync());

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    //ViewBag.CurrentFilter = searchString;
        //    //int pageSize = 3;
        //    //int pageNumber = (page ?? 1);
        //    //if (!string.IsNullOrEmpty(searchString))
        //    //{
        //    //    return View(modelsVM.Where(x => x.Name.Contains(searchString) || x.Abrv.Contains(searchString)).ToPagedList(pageNumber, pageSize));
        //    //}
        //    //switch (sortOrder)
        //    //{
        //    //    case "name_desc":
        //    //        return View(modelsVM.OrderByDescending(x => x.Name).ToPagedList(pageNumber, pageSize));
        //    //    case "Abrv":
        //    //        return View(modelsVM.OrderBy(x => x.Abrv).ToPagedList(pageNumber, pageSize));
        //    //    case "abrv_desc":
        //    //        return View(modelsVM.OrderByDescending(x => x.Abrv).ToPagedList(pageNumber, pageSize));
        //    //    default:
        //    //        return View(modelsVM.OrderBy(x => x.Name).ToPagedList(pageNumber, pageSize));
        //    //}
        //}

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
            {
                await modelService.CreateModelAsync(model);
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
