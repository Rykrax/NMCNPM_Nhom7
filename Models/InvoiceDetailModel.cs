using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblInvoiceDetails")]
public class InvoiceDetailModel
{
    [Key]
    [Column("iInvoiceDetailID")]
    public int IInvoiceDetailID { get; set; }

    [Column("iInvoiceID")]
    public int? IInvoiceID { get; set; }

    [Column("iProductID")]
    public int? IProductID { get; set; }

    [Column("iQuantity")]
    public int IQuantity { get; set; } = 0;

    [Column("fUnitPrice", TypeName = "decimal(18,2)")]
    public decimal FUnitPrice { get; set; }

    [ForeignKey("IInvoiceID")]
    public virtual InvoiceModel? Invoice { get; set; }

    [ForeignKey("IProductID")]
    public virtual ProductModel? Product { get; set; }
}
