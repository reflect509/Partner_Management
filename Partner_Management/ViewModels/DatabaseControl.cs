using Microsoft.EntityFrameworkCore;
using Partner_Management.Models;
using System.Windows;

namespace Partner_Management.ViewModels
{
    public static class DatabaseControl
    {
        public static void GetDiscountForPartner()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Partners.Include(p => p.PartnerProducts).ToList().ForEach(p =>
                {
                    {
                        var sum = p.PartnerProducts.Sum(pp => pp.Amount);
                        p.Discount = sum < 10000 ? 0M :
                                     sum < 30000 ? 0.05M :
                                     sum < 50000 ? 0.1M :
                                     0.15M;
                    }
                });

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

        public static List<ProductType> GetProductTypes()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.ProductTypes.ToList();
            }
        }

        public static List<MaterialType> GetMaterialTypes()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.MaterialTypes.ToList();
            }
        }
    }
}
