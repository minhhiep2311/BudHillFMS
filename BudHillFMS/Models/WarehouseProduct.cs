namespace BudHillFMS.Models;

public partial class WarehouseProduct
{
    public int Id { get; set; }
    public int WarehouseId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; } = null!;

    public virtual Product? Product { get; set; } 
    public virtual Warehouse? Warehouse { get; set; } 
}