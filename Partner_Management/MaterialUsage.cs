using Partner_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner_Management
{
    public static class MaterialUsage
    {
        public static int CalculateMaterialUsage(
            int productTypeId,
            int materialTypeId,
            int quantity,
            decimal parameter1,
            decimal parameter2
            )
        {
            if (quantity <= 0)
            {
                return -1;
            }
            if (parameter1 <= 0 || parameter2 <= 0)
            {
                return -1;
            }

            decimal productCoefficient = DatabaseControl.GetProductCoefficient(productTypeId);
            decimal materialBrokeCoefficient = DatabaseControl.GetMaterialCoefficient(materialTypeId);

            if (productCoefficient == -1 || materialBrokeCoefficient == -1)
            {
                return -1;
            }

            int materialUsage = (int)(quantity * (parameter1 * parameter2 * productCoefficient) * (materialBrokeCoefficient + 1)) + 1;

            return materialUsage;
        }
    }
}
