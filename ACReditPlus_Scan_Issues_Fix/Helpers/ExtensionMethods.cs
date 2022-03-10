using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

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

		public static string GetValidPath(this string filePath)
		{
			string dirPath = Path.GetDirectoryName(filePath);
			string filename = Path.GetFileName(filePath).GetValidFilename();
			return Path.Combine(dirPath, filename);
		}
	}
}
