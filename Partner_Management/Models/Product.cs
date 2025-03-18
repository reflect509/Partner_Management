namespace Partner_Management.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Articul { get; set; } = null!;

    public decimal MinCost { get; set; }

    public int ProductTypeId { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType ProductType { get; set; } = null!;
}
