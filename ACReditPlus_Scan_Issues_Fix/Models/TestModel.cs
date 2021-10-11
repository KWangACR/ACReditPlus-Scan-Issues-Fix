using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ACReditPlus_Scan_Issues_Fix.Models
{
	public class TestModel
	{
		public string Name => HttpUtility.HtmlEncode("Step: <b>Step Content</b>");
	}

	public class ApplicationSummaryStepModel
	{
		public string HeaderText
		{
			get
			{
				return $"Step: <b>{HttpUtility.HtmlEncode("some bold content")}</b>";
			}
		}
	}
}
