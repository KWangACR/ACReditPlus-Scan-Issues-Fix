using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ACReditPlus_Scan_Issues_Fix.Controllers
{
	public class TestClass
	{
		public string Name { get; set; }
	}

	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult FilteredReviewerFeedbackList([FromBody] TestClass searchModel)
		{
			return Json(searchModel);
		}
	}
}
