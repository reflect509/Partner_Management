using Microsoft.EntityFrameworkCore;
using Partner_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                    else if (sum < 5000000)
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

        public static void AddPartner(Partner partner)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Partners.Add(partner);
                ctx.SaveChanges();
            }
        }

        public static void UpdatePartner(Partner partner)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                Partner? _partner = ctx.Partners.FirstOrDefault(p => p.PartnerId == partner.PartnerId);

                if (_partner == null)
                {
                    MessageBox.Show("Ошибка при обновлении данных");
                    return;
                }

                _partner.PartnerName = partner.PartnerName;
                _partner.PartnerType = partner.PartnerType;
                _partner.CeoName = partner.CeoName;
                _partner.PartnerAddress = partner.PartnerAddress;
                _partner.PartnerEmail = partner.PartnerEmail;
                _partner.PartnerPhone = partner.PartnerPhone;
                _partner.Rating = partner.Rating;

                ctx.SaveChanges();
                MessageBox.Show("Изменения сохранены успешно");
            }
        }

        public static int GetPartnerId(string partnerName)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.PartnerTypes.First(t => t.PartnerTypeName == partnerName).PartnerTypeId;
            }
        }

        public static Partner GetPartnerByName(string partnerName)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Partners.First(p => p.PartnerName == partnerName);
            }
        }

        public static List<PartnerProduct> GetPartnerProducts(int partnerId)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.PartnerProducts.Include(p => p.Product).Where(p => p.PartnerId == partnerId).ToList();
            }
        }

        internal static decimal GetProductCoefficient(int productTypeId)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                var type = ctx.ProductTypes.FirstOrDefault(t => t.ProductTypeId == productTypeId);
                if (type == null)
                {
                    return -1;
                }

                return type.TypeCoefficient;
            }
        }

        internal static decimal GetMaterialCoefficient(int materialTypeId)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                var type = ctx.MaterialTypes.FirstOrDefault(t => t.MaterialTypeId == materialTypeId);
                if (type == null)
                {
                    return -1;
                }

                return type.BrokenCoefficient;
            }
        }
    }
}
