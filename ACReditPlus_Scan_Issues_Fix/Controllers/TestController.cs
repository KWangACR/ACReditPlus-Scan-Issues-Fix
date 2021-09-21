﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ACReditPlus_Scan_Issues_Fix.Controllers
{
	public class TestClass
	{
		public int ID { get; set; }
		//public string Name { get; set; }
	}

	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Test_1([FromBody] TestClass searchModel)
		{
			//var serializerSettings = new JsonSerializerSettings()
			//{
			//	StringEscapeHandling = StringEscapeHandling.EscapeHtml
			//};
			//return Json(searchModel, serializerSettings);

			TestClass testClass = new TestClass { };
			testClass.ID = searchModel.ID;
			return Json(testClass);
		}

		[HttpPost]
		public TestClass Test_2([FromBody] TestClass searchModel)
		{
			return searchModel;
		}
	}
}
