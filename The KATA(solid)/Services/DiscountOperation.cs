using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_KATA_solid_.Interfaces;

namespace The_KATA_solid_.Services
{
    class DiscountOperation : IDiscountOperation
    {
        public double discount(double productPrice, double discountPercentage)
        {
            return productPrice* discountPercentage/100;
        }

        public double discountUpc(double productPrice, double discountPercentage, int upc)
        {
            if(upc == 12345)
            {
                return productPrice*discountPercentage/100;
            }
            else
            {
                return 0;
            }
        }
    }
}
