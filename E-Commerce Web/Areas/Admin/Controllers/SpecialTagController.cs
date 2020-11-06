using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETic.Data;
using ETic.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private ApplicationDbContext _db;

        public SpecialTagController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(specialTags);
                await _db.SaveChangesAsync();
                TempData["save"] = "Etiket Kayıt İşlemi Başarı İle Gerçekleşti!";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(specialTags);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _specialTag = _db.SpecialTags.Find(id);
            if (_specialTag == null)
            {
                return NotFound();
            }
            return View(_specialTag);
        }

        /// POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags _specialTag)
        {
            if (ModelState.IsValid)
            {
                _db.Update(_specialTag);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Etiket Güncelleme İşlemi Başarı İle Gerçekleşti!";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(_specialTag);
        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _specialTag = _db.SpecialTags.Find(id);
            if (_specialTag == null)
            {
                return NotFound();
            }
            return View(_specialTag);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTags _specialTag)
        {
            return RedirectToAction(actionName: nameof(Index));
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _specialTags = _db.SpecialTags.Find(id);
            if (_specialTags == null)
            {
                return NotFound();
            }
            return View(_specialTags);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTags _specialTags)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != _specialTags.Id)
            {
                return NotFound();
            }
            var tag = _db.SpecialTags.Find(id);
            if (tag == null)
            {
                return NotFound();

            }
            if (ModelState.IsValid)
            {
                _db.Remove(tag);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Etiket Silme İşlemi Başarı İle Gerçekleşti!";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(tag);
        }
    }
}