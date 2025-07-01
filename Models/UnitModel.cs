using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblUnits")]
[Index(nameof(SUnitName), IsUnique = true)]
public class UnitModel
{
    [Key]
    [Column("iUnitID")]
    public int IUnitID { get; set; }

    [Required]
    [Column("sUnitName")]
    [StringLength(255)]
    public string SUnitName { get; set; } = null!;
}
