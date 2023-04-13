using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_KATA_solid_.Interfaces;

namespace The_KATA_solid_.Services
{
    public class ExpensesOperation : IExpensesOperation
    {
        public double expenses(double packegingCost, double price,double transportCost)
        {
            return ((packegingCost * price) / 100) + transportCost;
        }
        public double expensesTransportPercentage(double price,double transportCost)
        {
            return (price * transportCost) / 100;
        }
    }
}
