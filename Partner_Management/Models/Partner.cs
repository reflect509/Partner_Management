using System;
using System.Collections.Generic;

namespace Partner_Management.Models;

public partial class Partner
{
    public int PartnerId { get; set; }

    public string PartnerName { get; set; } = null!;

    public int PartnerType { get; set; }

    public string CeoName { get; set; } = null!;

    public string PartnerEmail { get; set; } = null!;

    public string PartnerPhone { get; set; } = null!;

    public string PartnerAddress { get; set; } = null!;

    public string? Tin { get; set; }

    public decimal? Rating { get; set; }

    public decimal? Discount { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual PartnerType PartnerTypeNavigation { get; set; } = null!;
}
