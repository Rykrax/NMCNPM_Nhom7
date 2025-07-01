using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NMCNPM_Nhom7.Models;

[Table("tblEmployees")]
[Index(nameof(SPhone), IsUnique = true)]
[Index(nameof(SEmail), IsUnique = true)]
[Index(nameof(SCCCD), IsUnique = true)]
public class EmployeeModel
{
    [Key]
    [Column("iEmployeeID")]
    public int IEmployeeID { get; set; }

    [Required]
    [Column("sFullName")]
    [StringLength(255)]
    public string SFullName { get; set; } = null!;

    [Column("bGender")]
    public bool BGender { get; set; } = true;

    [Column("dBirthDate", TypeName = "date")]
    public DateTime? DBirthDate { get; set; }

    [Required]
    [Column("sPhone")]
    [StringLength(10)]
    public string SPhone { get; set; } = null!;

    [Column("sEmail")]
    [StringLength(255)]
    public string? SEmail { get; set; }

    [Required]
    [Column("sCCCD")]
    [StringLength(12)]
    public string SCCCD { get; set; } = null!;

    [Column("sAddress")]
    [StringLength(255)]
    public string? SAddress { get; set; }

    [Required]
    [Column("sPasswordHash")]
    [StringLength(255)]
    public string SPasswordHash { get; set; } = null!;

    [Column("iRoleID")]
    public byte IRoleID { get; set; }

    [Column("sStatus")]
    [StringLength(10)]
    public string? SStatus { get; set; } = "active";

    [ForeignKey("IRoleID")]
    [InverseProperty("TblEmployees")]
    public virtual RoleModel? IRole { get; set; }
}
