using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACReditPlus_Scan_Issues_Fix.Helpers
{
	public static class ExtensionMethods
	{
		public static string DbConnStringEnableColumnEncryption(this string dbConnectionString)
		{
			return $"{dbConnectionString} Column Encryption Setting=enabled;";
		}

		public static string GetValidFilename(this string filename)
		{
			Regex rg = new Regex("^[A-Za-z0-9#_.-]+$");
			if (String.IsNullOrEmpty(filename) || !rg.IsMatch(filename))
			{
				throw new Exception($"Filename '{filename}' is invalid.");
			}
			return filename;
		}
	}
}
