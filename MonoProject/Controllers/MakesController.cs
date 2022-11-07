using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MonoProject.Service.Models.Common;

using Service.Service;
using AutoMapper;
using MonoProject.Models;
using MonoProject.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using static MonoProject.App_Profile;
using Service.Models;

namespace MonoProject.Controllers
{
    public class MakesController : Controller
    {
        IMakeService makeService;
        private IMapper mapper;

        public MakesController(IMakeService makeService, IMapper mapper)
        {
            this.makeService = makeService;
            this.mapper = mapper;
        }

        // GET: Makes
        public async Task<ActionResult> Index( int currentPage = 1, string filtering = "", string sorting = "name")
        {
            ViewBag.Pagination = currentPage;
            ViewBag.CurrentSort = sorting;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sorting) ? "Name" : sorting;
            ViewBag.NameSortParmAbrv = string.IsNullOrEmpty(sorting) ? "Abrv" : sorting;
            ViewBag.CurrentFilter = filtering;
            PaginationData paginationData = new PaginationData { CurrentPage = currentPage };
            FilteringData filteringData = new FilteringData { SearchString = filtering };
            SortingData sortingData = new SortingData { SortOrder = sorting };
            PagedList<Make> makeList = await makeService.GetMakesAsync(paginationData, filteringData, sortingData);
            PagedList<MakeViewModel> viewModel = mapper.Map<PagedList<Make>, PagedList<MakeViewModel>>(makeList);
            return View(viewModel);

        }
   
        // GET: Makes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeViewModel makeVM = mapper.Map<MakeViewModel>(await makeService.GetMakeByIdAsync(id));
            if (makeVM == null)
            {
                return HttpNotFound();
            }
            return View(makeVM);
        }

        // GET: Makes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Makes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Abrv")] Make make)
        {
            if (ModelState.IsValid)
            {
              await  makeService.CreateMakeAsync(make);
              return RedirectToAction("Index");
            }

            return View(make);
        }

        // GET: Makes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeViewModel makeVM = mapper.Map<MakeViewModel>(await makeService.GetMakeByIdAsync(id));
            if (makeVM == null)
            {
                return HttpNotFound();
            }
            return View(makeVM);
        }

        //// POST: Makes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Abrv")] Make make)
        {
            if (ModelState.IsValid)
            {
                await makeService.UpdateMakeAsync(make);
                return RedirectToAction("Index");
            }
            return View(make);
        }

        // GET: Makes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Make make = await makeService.GetMakeByIdAsync(id);
            MakeViewModel viewModel = mapper.Map<MakeViewModel>(make);

            if (make == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Makes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await makeService.DeleteMakeAsync(id);
            return RedirectToAction("Index");
        }


    }
}
