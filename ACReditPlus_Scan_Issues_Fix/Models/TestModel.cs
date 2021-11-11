using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ACReditPlus_Scan_Issues_Fix.Models
{
	public class TestModel
	{
		public int ModalityNumber { get; set; }
		public string Name => HttpUtility.HtmlEncode("Step: <b>Step Content</b>");
	}

	public class TestModel_2
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}

	public class ApplicationSummaryStepModel
	{
		public string HeaderText
		{
			get
			{
				return "Step: <b>some bold content</b>";
			}
		}
	}
}
