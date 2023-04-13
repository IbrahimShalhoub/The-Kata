using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_KATA_solid_.Interfaces
{
    public interface IExpensesOperation
    {
        public double expenses(double packegingCost,double price,double transportCost);
        public double expensesTransportPercentage(double price, double transportCost);
    }
}
