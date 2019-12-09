using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.DatabaseContext.DatabaseContext;
using DotNetForever.Model.Model;
using DotNetForever.Web.Models;


namespace DotNetForever.Repository.Repository
{
    public class SharedRepository
    {
        PurchaseRepository _purchaseRepository=new PurchaseRepository();
        PurchaseDetailsRepository _purchaseDetailsRepository=new PurchaseDetailsRepository();
        SaleRepository _saleRepository=new SaleRepository();
        SaleDetailsRepository _saledetailsRepository=new SaleDetailsRepository();

        public List<PurchaseReport> GetPurchaseReport(DateTime startDate, DateTime endDate)
        {
            List<PurchaseReport> purchaseReportViewModels=new List<PurchaseReport>();

            using (var context = new SMSDbContext())
            {
                var allProduct = context.Products.Include(x => x.Category).ToList();

                foreach (var product in allProduct)
                {
                    int productId = product.Id;
                    int purchaseQty = _purchaseRepository.GetTotalProductByIdAndDate(productId, startDate);
                    int salesQty = _saledetailsRepository.GetTotalProductByIdAndDate(productId, startDate);

                    int inQty = _purchaseRepository.GetTotalProductByIdAndStartAndEndDate(productId, startDate, endDate);
                    int outQty = _saledetailsRepository.GetTotalProductByIdAndStartAndEndDate(productId, startDate, endDate);
                    PurchaseReport model=new PurchaseReport();

                    model.Code = product.Code;
                    model.Product = product.Name;
                    model.Category = product.Category.Name;
                    model.AvailableQty = (purchaseQty - salesQty) + inQty - outQty;
                    var pDetails= _purchaseDetailsRepository.GetPurchaseDetailByProductId(productId);
                    if (pDetails!=null)
                    {
                        model.MRP = model.AvailableQty * pDetails.MRP;
                        model.CP = model.AvailableQty * pDetails.UnitPrice;
                    }
                   

                    model.Profit =model.MRP - model.CP;

                        purchaseReportViewModels.Add(model);

                }


            }

            return purchaseReportViewModels;

        }
       
        public List<SaleReport> GetSalesReport(DateTime startDate, DateTime endDate)
        {
            List<SaleReport> saleReports = new List<SaleReport>();

            using (var context = new SMSDbContext())
            {
                var allProduct = context.Products.Include(x => x.Category).ToList();

                foreach (var product in allProduct)
                {
                    int productId = product.Id;
                    //int purchaseQty = _purchaseRepository.GetTotalProductByIdAndDate(productId, startDate);
                    //int salesQty = _saledetailsRepository.GetTotalProductByIdAndDate(productId, startDate);

                    //int inQty = _purchaseRepository.GetTotalProductByIdAndStartAndEndDate(productId, startDate, endDate);
                    int outQty = _saledetailsRepository.GetTotalProductByIdAndStartAndEndDate(productId, startDate, endDate);
                    SaleReport model = new SaleReport();

                    model.Code = product.Code;
                    model.Product = product.Name;
                    model.Category = product.Category.Name;
                    model.SoldQty = outQty;
                    var pDetails = _purchaseDetailsRepository.GetPurchaseDetailByProductId(productId);
                    if (pDetails!=null)
                    {
                        model.MRP = model.SoldQty * pDetails.MRP;
                        model.CP = model.SoldQty * pDetails.UnitPrice;
                    }
                   

                    model.Profit = model.MRP - model.CP;

                    saleReports.Add(model);

                }


            }

            return saleReports;
        }


        public List<Stock> GetStockReport(int? categoryId,int? productId, DateTime startDate, DateTime endDate)
        {
            List<Stock> stocks = new List<Stock>();
           
            using (var context = new SMSDbContext())
            {
                var allProduct = (dynamic)null;

                allProduct = context.Products.Include(x => x.Category).ToList();
                if (categoryId.HasValue)
                {
                    allProduct = context.Products.Include(x => x.Category).Where(x=>x.CategoryId==categoryId).ToList();
                }

                if ( productId != null && productId != 0)
                {
                    allProduct = context.Products.Include(x => x.Category).Where(x=>x.CategoryId==categoryId && x.Id==productId).ToList();
                }


                foreach (var product in allProduct)
                {
                    int proId = product.Id;
                    int purchaseQty = _purchaseRepository.GetTotalProductByIdAndDate(proId, startDate);
                    int salesQty = _saledetailsRepository.GetTotalProductByIdAndDate(proId, startDate);

                    int inQty = _purchaseRepository.GetTotalProductByIdAndStartAndEndDate(proId, startDate,
                        endDate);
                    int outQty =
                        _saledetailsRepository.GetTotalProductByIdAndStartAndEndDate(proId, startDate, endDate);
                    Stock model = new Stock();

                    model.Code = product.Code;
                    model.Product = product.Name;
                    model.Category = product.Category.Name;
                    model.ReorderLevel = product.ReorderLevel;
                    model.OpeningBalance = purchaseQty - salesQty;
                    model.In = inQty;
                    model.Out = outQty;
                    model.ClosingBalance = model.OpeningBalance + inQty - outQty; 

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
