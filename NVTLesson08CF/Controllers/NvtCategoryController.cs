using NVTLesson08CF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NVTLesson08CF.Controllers
{
    public class NvtCategoryController : Controller
    {
        private static NvtBookStore _NvtBookStore;
        public NvtCategoryController()
        {
            _NvtBookStore = new NvtBookStore();
        }
        // GET: NvtCategory
        public ActionResult NvtIndex()
        {
            var nvtCategory = _NvtBookStore.NvtCategories.ToList();
            return View(nvtCategory);
        }
        [HttpGet]
        public ActionResult NvtCreate()
        {
            var nvtCategory = new NvtCategory();
            return View(nvtCategory);
        }
        [HttpPost]
        public ActionResult NvtCreate(NvtCategory nvtCategory)
        {
            _NvtBookStore.NvtCategories.Add(nvtCategory);
            _NvtBookStore.SaveChanges();
            return RedirectToAction("NvtIndex");
        }
    }
}