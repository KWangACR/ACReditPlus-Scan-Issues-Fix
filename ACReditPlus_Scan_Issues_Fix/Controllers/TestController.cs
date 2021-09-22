using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Security.Application;
using Newtonsoft.Json;
using ACReditPlus_Scan_Issues_Fix.ActionFilters;

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

		//[HttpPost]
		//public ActionResult Test_1([FromBody] TestClass searchModel)
		//{
		//	//var serializerSettings = new JsonSerializerSettings()
		//	//{
		//	//	StringEscapeHandling = StringEscapeHandling.EscapeHtml
		//	//};
		//	//return Json(searchModel, serializerSettings);

		//	//TestClass testClass = new TestClass { };
		//	//testClass.Name = searchModel.Name;
		//	//return Json(testClass);


		//	// <a>malicious link</a>
		//	TestClass testClass = JsonConvert.DeserializeObject<TestClass>(Sanitizer.GetSafeHtmlFragment(JsonConvert.SerializeObject(searchModel)));

		//	return Json(testClass);
		//}

		//[HttpPost]
		//public ActionResult Test_2([FromBody] TestClass searchModel)
		//{
		//	// return Sanitizer.GetSafeHtml(JsonConvert.SerializeObject(searchModel));
		//	// return JsonConvert.SerializeObject(searchModel);

		//	searchModel.Name = Sanitizer.GetSafeHtmlFragment(searchModel.Name);
		//	return Json(searchModel);
		//}

		[HttpPost]
		[SanitizeInput]
		public ActionResult Test_3([FromBody] TestClass searchModel)
		{
			return Json(searchModel);
		}
	}
}
