namespace Inventory.Models
{
    public class ProductDetailsModels
    {
        public int Productid { get; set; }
        public string ProducatName { get; set; }
        public string VendorName { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int ProductCount { get; set; }

        public int PurchaseCount { get; set; }
        public string CustomerName { get; set; }

    }
}
