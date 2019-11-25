

namespace DotNetForever.Model.Model
{
    public class PurchaseReport
    {
        public string Code { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public int AvailableQty { get; set; }
        public double CP { get; set; }
        public double MRP { get; set; }
        public double Profit { get; set; }
    }
}