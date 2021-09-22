using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ACReditPlus_Scan_Issues_Fix.ActionFilters;
using ACReditPlus_Scan_Issues_Fix.Models;

namespace ACReditPlus_Scan_Issues_Fix.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		//// Dirty fix (accepted by Checkmarx):
		//[HttpPost]
		//public ActionResult Test_1([FromBody] TestModel testModel)
		//{
		//	var sanitizer = new HtmlSanitizer();
		//	testModel.Name = sanitizer.Sanitize(testModel.Name);
		//	return Json(testModel);
		//}

		//// Recommended fix (NOT recognized by Checkmarx...):
		//[HttpPost]
		//[SanitizeInput]
		//public ActionResult Test_2([FromBody] TestModel testModel)
		//{
		//	return Json(testModel);
		//}
	}
}
