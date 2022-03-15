using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ACReditPlus_Scan_Issues_Fix.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ACReditPlus_Scan_Issues_Fix.Controllers
{
	public class JacketLabelController : Controller
	{
        public ActionResult ConstructJacketLabelPDF(string examHasFormDocId)
        {
            try
            {
                // Read The File Bytes
                byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\acreditplus_DEV\Application\Source");
                // Return the File Bytes with File Name so it can be Downloaded.
                return File(fileBytes, "application/pdf", "fileName");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
