using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetForever.Manager.Manager;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Web.Controllers
{
    public class ReportController : Controller
    {
        SharedManager _sharedManager=new SharedManager();
        // GET: Report
        public ActionResult PurchaseReport()
        {
            List<PurchaseReportViewModel> model=new List<PurchaseReportViewModel>();

            //DateTime startDate = new DateTime(2019, 11, 22, 0, 0, 0);
            //DateTime endDate = new DateTime(2019, 11, 30, 0, 0, 0);

            //model = _sharedManager.GetPurchaseReport(startDate, endDate);

            return View(model);
        }

        public ActionResult SaleReport()
        {
            List<SaleReportViewModel> model = new List<SaleReportViewModel>();

            return View(model);
        }
    }
}