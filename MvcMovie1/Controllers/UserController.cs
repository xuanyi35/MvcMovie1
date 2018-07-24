using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using System.Diagnostics;

namespace MvcMovie1.Controllers
{
    public class UserController : Controller
    {
        private readonly MvcMovie1Context _context;

        public UserController(MvcMovie1Context context)
        {
            _context = context;
        }

        
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }
        ////////////////////////////////////////

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,UserName, Password,ConfirmPassword")] User user)
        {
            var dbuser = await _context.User.SingleOrDefaultAsync(m => m.UserName == user.UserName);
            if (dbuser != null) {
                TempData["ERROR"] = "UserName has been taken";
                return View(user);
            }
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(user);
        }


        public  IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Success([Bind("UserID,UserName, Password")] User user)
        {
            if (user.UserName == null)
            {
                TempData["ERROR"] = "UserName cannot be empty";
                return RedirectToAction(nameof(Login));
            }

            var dbuser = await _context.User.SingleOrDefaultAsync(m => m.UserName == user.UserName);
            if (dbuser == null)
            {
                TempData["ERROR"] = "User does not exist";
                return RedirectToAction(nameof(Login));
            }

            if (user.Password == "") {
                TempData["ERROR"] = "password cannot be empty";
                return RedirectToAction(nameof(Login));
            }
            else if (user.Password == dbuser.Password) {
                TempData["UserName"] = user.UserName;
                TempData["UserID"] = dbuser.UserID;
                var url = Convert.ToString(TempData["url"]);
                return Redirect(url); 
            }
            else {
                TempData["ERROR"] = "UserName or Password is incorrect";
                return RedirectToAction(nameof(Login));
            }
            
        }

        public IActionResult Signout()
        {
            TempData["UserName"] = null;
            TempData["UserID"] = null;
            return RedirectToAction("Index", "Home");
        }


    }

}