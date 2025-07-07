namespace NMCNPM_Nhom7.DTOs
{
    public class ProductDetailDTO
    {
        public int ProductDetailID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? ImportPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public string UnitName { get; set; }
    }
}