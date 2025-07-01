using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblSuppliers")]
[Index(nameof(SPhone), IsUnique = true)]
[Index(nameof(SEmail), IsUnique = true)]
public class SupplierModel
{
    [Key]
    [Column("iSupplierID")]
    public int ISupplierID { get; set; }

    [Required]
    [Column("sCompanyName")]
    [StringLength(255)]
    public string SCompanyName { get; set; } = null!;

    [Column("sAddress")]
    [StringLength(255)]
    public string? SAddress { get; set; }

    [Column("sPhone")]
    [StringLength(10)]
    public string? SPhone { get; set; }

    [Column("sEmail")]
    [StringLength(255)]
    public string? SEmail { get; set; }
}
