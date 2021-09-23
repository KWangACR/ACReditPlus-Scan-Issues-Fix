using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ACReditPlus_Scan_Issues_Fix.Models
{
	public class TestModel
	{
		public string Name => "Step: <b>Step Content</b>";
	}

	public class ApplicationSummaryStepModel
	{
		public string HeaderText
		{
			get
			{
				//return "Step: <script>alert('You are hacked!')</script>";
				return HttpUtility.HtmlEncode("Bad link: & <IMG SRC=javascript:alert('XSS')>");
				//return "Styled text: <b>bold</b>";
			}
		}
	}
}
