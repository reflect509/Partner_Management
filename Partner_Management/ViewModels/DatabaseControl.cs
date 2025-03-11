using Microsoft.EntityFrameworkCore;
using Partner_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner_Management.ViewModels
{
    public static class DatabaseControl
    {
        public static void GetDiscountForPartner()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                Dictionary<int, decimal> PartnerIdSales = new Dictionary<int, decimal>();
                var deals = ctx.PartnerProducts.Include(p => p.Product).ToList();
                foreach (var deal in deals)
                {
                    if (!PartnerIdSales.ContainsKey(deal.PartnerId))
                    {
                        PartnerIdSales[deal.PartnerId] = 0;
                    }
                    else
                    {
                        PartnerIdSales[deal.PartnerId] += deal.Amount * deal.Product.MinCost;
                    }
                }

                foreach (var partner in PartnerIdSales)
                {
                    var sum = partner.Value;
                    decimal discount;

                    if (sum < 1000000)
                    {
                        discount = 0;
                    }
                    else if (sum <  5000000)
                    {
                        discount = 0.05M;
                    }
                    else if (sum < 30000000)
                    {
                        discount = 0.1M;
                    }
                    else
                    {
                        discount = 0.15M;
                    }

                    ctx.Partners.Find(partner.Key).Discount = discount;
                }
                ctx.SaveChanges();
            }
        }

        public static List<Partner> GetPartners()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Partners.Include(p => p.PartnerTypeNavigation).ToList();
            }
        }
    }
}
