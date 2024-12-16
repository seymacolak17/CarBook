﻿using CarBook.Dto.ServiceDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult  Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "En Güncel Hizmetlerimiz";
            return View();
        }
    }
}
