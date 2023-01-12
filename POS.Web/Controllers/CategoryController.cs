﻿using Microsoft.AspNetCore.Mvc;
using POS.Service;
using POS.Repository;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        public CategoryController(ApplicationDbContext context)
        {
            _service = new CategoryService(context);
        }

        public IActionResult Index()
        {
            var Data = _service.Get();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save([Bind("CategoryName, Description")] CategoryModel request)
        {
            if(ModelState.IsValid)
            {
                _service.Add(new CategoryEntity(request));
                return Redirect("Index");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var category = _service.View(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var category = _service.View(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CategoryName, Description")] CategoryEntity category)
        {
            _service.Update(category);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Category");
        }
    }
}
