using System;
using System.Collections.Generic;
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
                // Generate the File and Get the Path.
                string fileFullPath = this.jacketLabelWorklistHelper.GetJacketLabelPDFFileByteInfo(examHasFormDocId);
                // Read The File Bytes
                byte[] fileBytes = System.IO.File.ReadAllBytes(fileFullPath.GetValidFilename());
                // Get the File Info from The Path 
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileFullPath);
                // Return the File Bytes with File Name so it can be Downloaded.
                return File(fileBytes, "application/pdf", fileInfo.Name);
            }
            catch (Exception e)
            {
                HttpContextHelper.HttpContext.RiseError(e);
                throw e;
            }

        }
    }
}
