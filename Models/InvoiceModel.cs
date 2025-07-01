using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NMCNPM_Nhom7.Models;

[Table("tblInvoices")]
public class InvoiceModel
{
    [Key]
    [Column("iInvoiceID")]
    public int IInvoiceID { get; set; }

    [Column("iEmployeeID")]
    public int? IEmployeeID { get; set; }

    [Column("iCustomerID")]
    public int? ICustomerID { get; set; }

    [Column("dCreatedDate")]
    public DateTime DCreatedDate { get; set; }

    [Column("fTotal", TypeName = "decimal(18,2)")]
    public decimal FTotal { get; set; }

    [Column("fVAT", TypeName = "decimal(5,2)")]
    public decimal FVAT { get; set; }

    [ForeignKey("IEmployeeID")]
    public virtual EmployeeModel? Employee { get; set; }

    [ForeignKey("ICustomerID")]
    public virtual CustomersModel? Customer { get; set; }
}
