using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult PurchaseReport()
        {
            List<PurchaseReportViewModel> model=new List<PurchaseReportViewModel>();

            return View(model);
        }

        public ActionResult SaleReport()
        {
            List<SaleReportViewModel> model = new List<SaleReportViewModel>();

            return View(model);
        }
    }
}