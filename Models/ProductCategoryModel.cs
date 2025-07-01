using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblProductCategories")]
public class ProductCategoryModel
{
    [Key]
    [Column("iCategoryID")]
    public int ICategoryID { get; set; }

    [Required]
    [Column("sCategoryName")]
    [StringLength(255)]
    public string SCategoryName { get; set; } = null!;
}
