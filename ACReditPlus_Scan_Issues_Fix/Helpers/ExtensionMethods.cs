using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACReditPlus_Scan_Issues_Fix.Helpers
{
	public static class ExtensionMethods
	{
		public static string DbConnStringEnableColumnEncryption(this string dbConnectionString)
		{
			return $"{dbConnectionString} Column Encryption Setting=enabled;";
		}
	}
}
