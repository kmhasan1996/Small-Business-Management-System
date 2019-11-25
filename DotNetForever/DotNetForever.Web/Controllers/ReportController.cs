using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetForever.Manager.Manager;
using DotNetForever.Model.Model;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Web.Controllers
{
    public class ReportController : Controller
    {
        SharedManager _sharedManager=new SharedManager();
        // GET: Report
        public ActionResult PurchaseReport()
        {
            //List<PurchaseReportViewModel> model=new List<PurchaseReportViewModel>();

            List<PurchaseReport> model=new List<PurchaseReport>();

            DateTime startDate = DateTime.Today.Date;
            DateTime endDate = DateTime.Today.Date;

            model = _sharedManager.GetPurchaseReport(startDate, endDate);

            return View(model);
        }

        public ActionResult SaleReport()
        {
            List<SaleReport> model = new List<SaleReport>();

            DateTime startDate = DateTime.Today.Date;
            DateTime endDate = DateTime.Today.Date;

            model = _sharedManager.GetSalesReport(startDate, endDate);

            return View(model);
        }
    }
}