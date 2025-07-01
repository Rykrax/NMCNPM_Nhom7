using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblProducts")]
public class ProductModel
{
    [Key]
    [Column("iProductID")]
    public int IProductID { get; set; }

    [Column("sProductName")]
    [StringLength(255)]
    public string? SProductName { get; set; }

    [Column("iCategoryID")]
    public int? ICategoryID { get; set; }

    [Column("fPrice", TypeName = "decimal(18,2)")]
    public decimal? FPrice { get; set; }

    [Column("iQuantity")]
    public int IQuantity { get; set; } = 0;

    [Column("iUnitID")]
    public int? IUnitID { get; set; }

    [Column("iSupplierID")]
    public int? ISupplierID { get; set; }

    [ForeignKey("ICategoryID")]
    public virtual ProductCategoryModel? Category { get; set; }

    [ForeignKey("IUnitID")]
    public virtual UnitModel? Unit { get; set; }

    [ForeignKey("ISupplierID")]
    public virtual SupplierModel? Supplier { get; set; }
}
