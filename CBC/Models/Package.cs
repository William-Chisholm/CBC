namespace CBC.Models
{
    public class Package
    {
        public string Item { get; set; }
        public string Description { get; set; }
        public string PreferredVendor { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public Package()
        {
            this.Item = "";
            this.Description = "";
            this.PreferredVendor = "";
            this.Price = 0;
            this.Quantity = 0;
        }

        public Package(string item, string description, string preferredVendor, int price, int quantity)
        {
            this.Item = item;
            this.Description = description;
            this.PreferredVendor = preferredVendor;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
