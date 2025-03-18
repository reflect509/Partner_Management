namespace Partner_Management.Models;

public partial class MaterialType
{
    public int MaterialTypeId { get; set; }

    public string MaterialTypeName { get; set; } = null!;

    public decimal BrokenCoefficient { get; set; }
}
