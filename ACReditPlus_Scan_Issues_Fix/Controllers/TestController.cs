﻿using System;
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
			var properties = testModel.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
			var sanitizer = new HtmlSanitizer();
			foreach (var propInfo in properties)
			{
				propInfo.SetValue(testModel, sanitizer.Sanitize(propInfo.GetValue(testModel) as string));
			}
			return Json(testModel);
		}
	}
}
