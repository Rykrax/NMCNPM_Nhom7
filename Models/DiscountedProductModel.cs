using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblDiscountedProducts")]
public class DiscountedProductModel
{
    [Key]
    [Column("iDiscountID")]
    public int IDiscountID { get; set; }

    [Column("iProductID")]
    public int IProductID { get; set; }

    [Column("fDiscountPercent", TypeName = "decimal(5,2)")]
    public decimal FDiscountPercent { get; set; } = 0;

    [Column("fDiscountAmount", TypeName = "decimal(18,2)")]
    public decimal FDiscountAmount { get; set; } = 0;

    [Column("dStartDate")]
    public DateTime DStartDate { get; set; }

    [Column("dEndDate")]
    public DateTime DEndDate { get; set; }

    [Column("sDescription")]
    [StringLength(255)]
    public string? SDescription { get; set; }

    [ForeignKey("IProductID")]
    public virtual ProductModel? Product { get; set; }
}
