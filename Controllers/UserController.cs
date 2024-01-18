using CURD_Using_Repository.Models;
using CURD_Using_Repository.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURD_Using_Repository.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser userRepo;

        public UserController(IUser userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<IActionResult> GetUserList()
        {
            var data = await userRepo.GetUsers();
            return View(data);
        }

        public async Task<IActionResult> AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                else
                {
                    await userRepo.AddUser(user);
                    if(user.UserId == 0)
                    {
                        TempData["userError"] = "Recode Not Saved!";
                    }
                    else
                    {
                        TempData["userSuccess"] = "Recode has been Successfully Inserted!";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUserList");

        }

        public async Task<IActionResult> Edit(int id)
        {
            User user = new User();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    user = await userRepo.GetUserById(id);
                    if (user == null)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                else
                {
                    bool status = await userRepo.UpdateRecode(user);
                    if (status)
                    {
                        TempData["userSuccess"] = "Recod has been Successfully Updated...";
                    }
                    else
                    {
                        TempData["userError"] = "Recode Not Updated!";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUserList");

        }

        public async Task<IActionResult> Detail(int id)
        {
            User user = new User();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    user = await userRepo.GetUserById(id);
                    if (user == null)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    bool status = await userRepo.DeleteRecode(id);
                    if (status)
                    {
                        TempData["userSuccess"] = "Recod has been Successfully Deleted...";
                    }
                    else
                    {
                        TempData["userError"] = "Recode Not Deleted!";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUserList");
        }
    }
}
