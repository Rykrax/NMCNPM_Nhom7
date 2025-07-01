using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblCustomers")]
[Index(nameof(SPhone), IsUnique = true)]
public class CustomersModel
{
    [Key]
    [Column("iCustomerID")]
    public int ICustomerID { get; set; }

    [Required]
    [Column("sFullName")]
    [StringLength(255)]
    public string SFullName { get; set; } = null!;

    [Required]
    [Column("sPhone")]
    [StringLength(10)]
    public string SPhone { get; set; } = null!;

    [Column("iLoyaltyPoints")]
    public int ILoyaltyPoints { get; set; } = 0;
}
