using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_KATA_solid_.Interfaces;

namespace The_KATA_solid_.Services
{
    public class CapOperation : ICapOperation
    {
        double capvalue;
        public double capProcess(double productPrice, double totalDiscount, double capValue, double capPercentage)
        {
            capvalue = productPrice * capPercentage / 100;
            if (totalDiscount>capValue&&capPercentage==0)
                {
                    return capValue;
                }
                else if(capValue>totalDiscount&&capPercentage==0)
                {
                    return totalDiscount;
                }
            else if(totalDiscount>capvalue) {
                return capvalue;
            }

            return totalDiscount;
            

                
        }
    }
}
