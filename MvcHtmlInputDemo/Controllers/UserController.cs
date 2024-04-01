using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcHtmlInputDemo.Dto;
using MvcHtmlInputDemo.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MvcHtmlInputDemo.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult<List<UserDto>> Index()
        {
            var userService = new UserService();
            var data = userService.GetAll();
            return View(data);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var cityService = new CityService();
            var data = cityService.GetAll();
            ViewBag.CityList = new SelectList(data.AsEnumerable(), "CityId", "Name");
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Fullname,CityId,Gender,Cricket,Kabbdai,Tenies,ProfilePicture,ProfilePictureName")] AddUserDto requestDto)
        {
            try
            {
                var files = Request.Form.Files;
                if (files != null && files.Count() > 0)
                {
                    var file = files.FirstOrDefault();
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            requestDto.ProfilePicture = fileBytes;
                            requestDto.ProfilePictureName = file.FileName;
                        }
                    }
                }
                else
                {
                    requestDto.ProfilePicture = new byte[0];
                    requestDto.ProfilePictureName = string.Empty;
                }
                var userService = new UserService();
                var result = userService.Add(requestDto);
                if (result != "Success")
                    return RedirectToPage("Error.cshtml");

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var cityService = new CityService();
            var cityDetails = cityService.GetAll();
            ViewBag.CityList = new SelectList(cityDetails.AsEnumerable(), "CityId", "Name");

            var userService = new UserService();
            var data = userService.GetById(id);
            if (data.ProfilePicture != null && data.ProfilePicture.Length > 0)
            {
                data.Image = $"data:image/{data.ProfilePictureName};base64, {Convert.ToBase64String(data.ProfilePicture)}";
            }
            return View(data);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Fullname,CityId,Gender,Cricket,Kabbdai,Tenies,ProfilePicture,ProfilePictureName")] UpdateUserdto requestDto)
        {
            try
            {
                var files = Request.Form.Files;
                if (files != null && files.Count() > 0)
                {
                    var file = files.FirstOrDefault();
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            requestDto.ProfilePicture = fileBytes;
                            requestDto.ProfilePictureName = file.FileName;
                        }
                    }
                }
                else
                {
                    requestDto.ProfilePicture = new byte[0];
                    requestDto.ProfilePictureName = string.Empty;
                }
                var userService = new UserService();
                var result = userService.Update(requestDto);
                if (result != "Success")
                    return RedirectToPage("Error.cshtml");

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public string Base64ImageTo(int id)
        {
            var userService = new UserService();
            var data = userService.GetById(id);
            
            var base64 = Convert.ToBase64String(data.ProfilePicture);
            return $"data:image/gif;base64,{base64}";
        }
    }
}
