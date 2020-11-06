using ETic.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETic.Components
{
    public class CategoryMenu : ViewComponent
    {
        private ApplicationDbContext _db;
        public CategoryMenu(ApplicationDbContext db)
        {
            _db = db;
        }


        public IViewComponentResult Invoke()
        {
            var categories = _db.ProductTypes.OrderBy(p => p.ProductType).ToList();
            return View(categories);
        }



    }
}
