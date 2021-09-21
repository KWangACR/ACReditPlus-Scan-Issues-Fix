using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Security.Application;
using Newtonsoft.Json;

namespace ACReditPlus_Scan_Issues_Fix.Controllers
{
	public class TestClass
	{
		//public int ID { get; set; }
		public string Name { get; set; }
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

			//TestClass testClass = new TestClass { };
			//testClass.Name = searchModel.Name;
			//return Json(testClass);

			//TestClass testClass = JsonConvert.DeserializeObject<TestClass>(JsonConvert.SerializeObject(searchModel));

			TestClass testClass = JsonConvert.DeserializeObject<TestClass>(Sanitizer.GetSafeHtmlFragment(JsonConvert.SerializeObject(searchModel)));

			return Json(testClass);
		}

		[HttpPost]
		public TestClass Test_2([FromBody] TestClass searchModel)
		{
			return searchModel;
		}
	}
}
