using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ACReditPlus_Scan_Issues_Fix.Helpers
{
	public static class Utilities
	{
		public static void CreateDirectory(string filePath)
		{
			try
			{
				Directory.CreateDirectory(filePath);
			}
			catch (Exception ex)
			{
				throw new Exception($"CreateDirectory failed due to: {ex.Message}");
			}
		}
	}
}
