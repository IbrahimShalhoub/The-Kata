using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_KATA_solid_.Interfaces
{
    public interface ITaxOperation
    {
        double TaxAmount(double productPrice,double taxAmount);
    }
}
