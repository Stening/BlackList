﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlackList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            return View();
        }
    }
}
