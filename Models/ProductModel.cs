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

    [ForeignKey("ICategoryID")]
    public virtual ProductCategoryModel? Category { get; set; }

    public virtual ICollection<ProductDetailModel>? ProductDetails { get; set; }
}
