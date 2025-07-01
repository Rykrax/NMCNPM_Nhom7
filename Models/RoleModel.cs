using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NMCNPM_Nhom7.Models;

[Table("tblRoles")]
[Index(nameof(SRoleName), IsUnique = true)]  // tạo chỉ mục unique
public class RoleModel
{
    [Key]
    [Column("iRoleID")]
    public byte IRoleID { get; set; }  // tinyint tương ứng byte

    [Required]
    [Column("sRoleName")]
    [StringLength(50)]
    public string SRoleName { get; set; } = null!;

    [InverseProperty("IRole")]
    public virtual ICollection<EmployeeModel> TblEmployee { get; set; } = new List<EmployeeModel>();
}