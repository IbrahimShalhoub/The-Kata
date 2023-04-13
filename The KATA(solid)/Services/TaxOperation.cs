using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_KATA_solid_.Interfaces;

namespace The_KATA_solid_.Services
{
    public class TaxOperation : ITaxOperation
    {
        public double TaxAmount(double productPrice, double taxAmount)
        {
            return productPrice* taxAmount/100;
        }
    }
}
