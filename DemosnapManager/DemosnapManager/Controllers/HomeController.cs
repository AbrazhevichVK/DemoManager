using DemosnapManager.Models;
using DemosnapManager.Models.Snapshot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemosnapManager.Controllers
{
    public class HomeController : Controller
    {
        IDemoSnapshotRepository repository;

        public HomeController(IDemoSnapshotRepository demoRepository)
        {
            repository = demoRepository;
        }

        public IActionResult Index()
        {
            return View(repository.GetDemoSnapshotModels());
        }

        public ActionResult Details(int id)
        {
            DemoSnapshotModel model = repository.Get(id);
            if (model != null)
                return View(model);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DemoSnapshotModel model)
        {
            repository.Create(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            DemoSnapshotModel model = repository.Get(id);
            if (model != null)
                return View(model);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(DemoSnapshotModel model)
        {
            repository.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            DemoSnapshotModel model = repository.Get(id);
            if (model != null)
                return View(model);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
