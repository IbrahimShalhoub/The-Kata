using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_KATA_solid_.Interfaces
{
    public interface IDiscountOperation
    {
        public double discount(double productPrice, double discountPercentage);
        public double discountUpc(double productPrice, double discountPercentage,int upc);
    }
}
