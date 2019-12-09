using System.Collections.Generic;


namespace DotNetForever.Model.Model
{
    public class Stock
    {
        public string Code { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public int ReorderLevel { get; set; }
        public int OpeningBalance { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int ClosingBalance { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Sale> Sales { get; set; }
    }
}