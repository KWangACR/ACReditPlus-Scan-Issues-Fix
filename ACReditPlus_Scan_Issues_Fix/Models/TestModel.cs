using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
				return "Step: <b>Step Content</b>";
			}
		}
	}
}
