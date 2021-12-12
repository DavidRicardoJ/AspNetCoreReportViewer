using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace AspNetCoreReportViewer.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Print()
        {
            string mimetype = "";
            int extension = 1;
            var path = $"{webHostEnvironment.WebRootPath}//Report//Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("RP1", "Hello Report!");

            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);

            return File(result.MainStream, "application/pdf");
        }
    }
}
