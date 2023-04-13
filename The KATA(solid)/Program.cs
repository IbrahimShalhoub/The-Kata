using System;
using The_KATA_solid_.Services;

namespace The_KATA_solid_
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxOperation taxOperation = new TaxOperation();
            DiscountOperation discountOperation = new DiscountOperation();
            ExpensesOperation expensesOperation = new ExpensesOperation();
            CapOperation capOperation = new CapOperation();
            Calculater calculate = new Calculater(taxOperation,discountOperation,expensesOperation,capOperation);
        }
    }
}