using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_KATA_solid_.Interfaces
{
    public interface ICapOperation
    {
        public double capProcess(double productPrice ,double totalDiscount,double capValue,double capPercentage);
    }
}
