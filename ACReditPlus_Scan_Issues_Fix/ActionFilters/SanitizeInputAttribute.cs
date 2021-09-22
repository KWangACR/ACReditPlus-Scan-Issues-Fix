using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ACReditPlus_Scan_Issues_Fix.ActionFilters
{
	public class SanitizeInputAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if(context.ActionArguments != null)
			{
				var requestParam = context.ActionArguments.First();
				var properties = requestParam.Value.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
				var sanitizer = new HtmlSanitizer();
				foreach (var propInfo in properties)
				{
					propInfo.SetValue(requestParam.Value, sanitizer.Sanitize(propInfo.GetValue(requestParam.Value) as string));
				}
			}
		}
	}
}
