using System;
using System.Collections.Generic;

namespace Partner_Management.Models;

public partial class PartnerProduct
{
    public int ProductId { get; set; }

    public int PartnerId { get; set; }

    public int Amount { get; set; }

    public DateOnly SellDate { get; set; }

    public virtual Partner Partner { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
