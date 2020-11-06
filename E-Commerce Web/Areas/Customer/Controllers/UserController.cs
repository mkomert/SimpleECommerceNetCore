using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETic.Data;
using ETic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETic.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> _userManager;
        ApplicationDbContext _db;
        public UserController(UserManager<IdentityUser>userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult listUsers()
        {
            return View(_db.ApplicationUsers.ToList());
        }




        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    var isSaveRole = await _userManager.AddToRoleAsync(user, "User");
                    TempData["Save"] = "Kullanıcı Kayıt Başarılı!";
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            }

            return View();
        }


        public async Task<IActionResult> Edit(string id)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser _user)
        {
            var userInf = _db.ApplicationUsers.FirstOrDefault(x => x.Id == _user.Id);
            if (userInf == null)
            {
                return NotFound();
            }
            userInf.FirstName = _user.FirstName;
            userInf.LastName = _user.LastName;
            userInf.UserName = _user.UserName;
            var result = await _userManager.UpdateAsync(userInf);
            if (result.Succeeded)
            {
                TempData["Save"] = "Kullanıcı Güncelleme Başarılı!";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public async Task<IActionResult> Details(string id)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(string id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var user = _db.ApplicationUsers.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser User)
        {
            var userInf = _db.ApplicationUsers.FirstOrDefault(c => c.Id == User.Id);
            if (userInf == null)
            {
                return NotFound();
            }
            userInf.LockoutEnd = DateTime.Now.AddYears(100);
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0 )
            {
                TempData["Save"] = "Kullanıcı " +User.FirstName+" "+ User.LastName+ " Engellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(userInf);
        }


        public async Task<IActionResult> Active(string id)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Active(ApplicationUser User)
        {
            var userInf = _db.ApplicationUsers.FirstOrDefault(c => c.Id == User.Id);
            if (userInf == null)
            {
                return NotFound();
            }
            userInf.LockoutEnd = DateTime.Now.AddDays(-1);
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["Save"] = "Kullanıcı " + User.FirstName + " " + User.LastName + " Aktifleştirildi!";
                return RedirectToAction(nameof(Index));
            }
            return View(userInf);
        }


    }
}