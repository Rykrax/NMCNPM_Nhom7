using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tblProductDetails")]
public class ProductDetailModel
{
    [Key]
    [Column("iProductDetailID")]
    public int IProductDetailID { get; set; }

    [Required]
    [Column("iProductID")]
    public int IProductID { get; set; }

    [Required]
    [Column("iUnitID")]
    public int IUnitID { get; set; }

    [Required]
    [Column("iSupplierID")]
    public int ISupplierID { get; set; }

    [Column("fImportPrice", TypeName = "decimal(18,2)")]
    public decimal? FImportPrice { get; set; }

    [Column("fSellPrice", TypeName = "decimal(18,2)")]
    public decimal FSellPrice { get; set; } = 0;

    [Column("iQuantity")]
    public int IQuantity { get; set; } = 0;

    [ForeignKey(nameof(IProductID))]
    public virtual ProductModel? Product { get; set; }

    [ForeignKey(nameof(IUnitID))]
    public virtual UnitModel? Unit { get; set; }

    [ForeignKey(nameof(ISupplierID))]
    public virtual SupplierModel? Supplier { get; set; }
}
