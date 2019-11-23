using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.DatabaseContext.DatabaseContext;
using DotNetForever.Web.Models;

namespace DotNetForever.Repository.Repository
{
    public class SharedRepository
    {
        PurchaseRepository _purchaseRepository=new PurchaseRepository();
        SaleRepository _saleRepository=new SaleRepository();
        SaleDetailsRepository _saledetailsRepository=new SaleDetailsRepository();

        //public List<PurchaseReportViewModel> GetPurchaseReport(string startDate, string endDate)
        //{


        //}
        //public List<PurchaseReportViewModel> SearchPurchaseReportByDate(string startDate, string endDate)
        //{


        //}


        //public List<SalesReportViewModel> GetSalesReport()
        //{

        //}

        //public List<SalesReportViewModel> SearchSalesReportByDate(string startDate, string endDate)
        //{


        //}


        public List<Stock> GetStockReport(DateTime startDate, DateTime endDate)
        {
            List<Stock> stocks = new List<Stock>();

            using (var context = new SMSDbContext())
            {
                var allProduct= context.Products.Include(x => x.Category).ToList();

                foreach (var product in allProduct)
                {
                    int productId = product.Id;
                    int purchaseQty = _purchaseRepository.GetTotalProductByIdAndDate(productId, startDate);
                    int salesQty = _saledetailsRepository.GetTotalProductByIdAndDate(productId, startDate);

                    int inQty = _purchaseRepository.GetTotalProductByIdAndStartAndEndDate(productId, startDate,
                        endDate);
                    int outQty =
                        _saledetailsRepository.GetTotalProductByIdAndStartAndEndDate(productId, startDate, endDate);
                    Stock model = new Stock();

                    model.Code = product.Code;
                    model.Product = product.Name;
                    model.Category = product.Category.Name;
                    model.ReorderLevel = product.ReorderLevel;
                    model.OpeningBalance = purchaseQty - salesQty;
                    model.In = inQty;
                    model.Out = outQty;
                    model.ClosingBalance = model.OpeningBalance+inQty+outQty;

                    stocks.Add(model);

                }

               
            }

            return stocks;
        }

        //public List<Stock> SearchStockReportByDate(string startDate, string endDate, int categoryId, int productId)
        //{
            
        //}
    }
}
