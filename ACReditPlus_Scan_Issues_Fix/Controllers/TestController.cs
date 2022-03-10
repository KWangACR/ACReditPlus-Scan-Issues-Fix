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
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ACReditPlus_Scan_Issues_Fix.Helpers;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ACReditPlus_Scan_Issues_Fix.Controllers
{
	public class TestController : Controller
	{
		private readonly string ACREDIT_LEGACY_DB_CONN_STRING;

		public TestController(IConfiguration configuration)
		{
			ACREDIT_LEGACY_DB_CONN_STRING = configuration.GetConnectionString("NON_EXISTING_DB_CONNECTION_STRING");
		}

		public IActionResult Index()
		{
			return View();
		}

		public void DbConnection()
		{
			using (SqlConnection conn = new SqlConnection($"{ACREDIT_LEGACY_DB_CONN_STRING} Column Encryption Setting=enabled;"))
			{
				conn.Open();

				conn.Close();
			}
		}

		//// Dirty fix (accepted by Checkmarx):
		//[HttpPost]
		//public ActionResult Test_1([FromBody] TestModel testModel)
		//{
		//	var sanitizer = new HtmlSanitizer();
		//	testModel.Name = sanitizer.Sanitize(testModel.Name);
		//	return Json(testModel);
		//}

		// Recommended fix (NOT recognized by Checkmarx...):
		[HttpPost]
		//[SanitizeInput]
		public ActionResult Test_2([FromBody] TestModel testModel)
		{
			AntiForgery.Validate();

			var properties = testModel.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
			// var sanitizer = new HtmlSanitizer();
			foreach (var propInfo in properties)
			{
				propInfo.SetValue(testModel, HttpUtility.HtmlEncode(propInfo.GetValue(testModel) as string));
			}
			return Json(testModel);
		}

		[HttpPost]
		public IActionResult Save([FromBody] TestModel testModel)
		{
			string key = "_" + testModel.ModalityNumber;
			String serialized = ConstStrings.REVIEWSHEET_MENU + key;
			string item = HttpContext.Session.GetString(serialized);
			TestModel_2 new_testModel = JsonConvert.DeserializeObject<TestModel_2>(item, new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace, TypeNameHandling = TypeNameHandling.Objects });
			Console.WriteLine(new_testModel.Name);
			return Json(new { ok = true });
		}

		[HttpPost]
		public void FlattenXFAForm(string dstFilePath)
		{
			using (var dstStream = System.IO.File.Create(dstFilePath.GetValidFilename()))
			{
				
			}
		}
	}
}
