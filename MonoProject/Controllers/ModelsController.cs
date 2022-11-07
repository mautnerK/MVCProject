using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MonoProject.Models;
using MonoProject.Service.Models;
using Service.Models;
using Service.Service;

namespace MonoProject.Controllers
{
    [RoutePrefix("vehiclemodels")]
    public class ModelsController : Controller
    {
        IModelService modelService;
        IMakeService makeService;
        private IMapper mapper;


        public ModelsController(IModelService modelService, IMakeService makeService, IMapper imapper)
        {
            this.makeService = makeService;
            this.modelService = modelService;
            mapper = imapper;
        }

        [Route]
        // GET: Models
        public async Task<ActionResult> Index(int currentPage = 1, string filtering = "", string sorting = "name")
        {
            ViewBag.CurrentSort = sorting;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sorting) ? "name" : sorting;
            ViewBag.NameSortParmAbrv = string.IsNullOrEmpty(sorting) ? "Abrv" : sorting;
            ViewBag.CurrentFilter = filtering;
            PaginationData paginationData = new PaginationData { CurrentPage = currentPage };
            FilteringData filteringData = new FilteringData { SearchString = filtering };
            SortingData sortingData = new SortingData { SortOrder = sorting };
            PagedList<Model> makeList = await modelService.GetModelAsync(paginationData, filteringData, sortingData);
            PagedList<ModelViewModel> viewModel = mapper.Map<PagedList<Model>, PagedList<ModelViewModel>>(makeList);
            return View(viewModel);
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
        public async Task<ActionResult> Create()
        {
            ViewBag.MakeList = new SelectList(await makeService.GetAllMakesAsync(),"id","Name","Abrv");
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Abrv,Make")] CreateModelViewModel modelCVM)
        {
            ModelViewModel modelVM = new ModelViewModel();
            modelVM.Name = modelCVM.Name;
            modelVM.Abrv = modelCVM.Abrv;
            var model = mapper.Map<Model>(modelVM);
            model.Make = await makeService.GetMakeByIdAsync(modelCVM.Make);

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
