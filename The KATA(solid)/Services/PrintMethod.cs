using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_KATA_solid_.Services
{
    public class PrintMethod
    {
       public void PrintCurr(double price,double tax,double totalPrice,string typeCurr)
        {
            Console.WriteLine($"Cost = {price} {typeCurr} Tax = {tax} {typeCurr} TOTAL = {totalPrice} {typeCurr} Program reports no discount");
        }
        public void PrintReport(double price,double discount) {
            if (discount > 0)
            {
                Console.WriteLine($"price {price:c} Program displays {discount:c} amount which was deduced");
            }else 
            {
                Console.WriteLine($"price {price:c} Program doesn’t show any discounted amount."); 
            }
        }
        public void PrintDiscountUpc(double price, double discount,double discountUpc)
        {
            if (discountUpc > 0)
            {
                Console.WriteLine($"price {price:c} Program reports total discount amount {discount:c}");
            }
            else {
                Console.WriteLine($"price {price:c} Program reports discount amount {discount:c}.");
            }
        }
        public void PrintPrice(double price)
        {
            Console.WriteLine($"\nTotal Price = {price:c}");
        }
        public void PrintExpenses(double price,double tax,double totalDiscount,double packeging,double transport,double totalPrice)
        {
            if (totalDiscount>0&&transport>0&&packeging>0)
            {
                Console.WriteLine($"Cost = {price:c} Tax = {tax:c} Discounts = {totalDiscount:c} Packaging = {packeging:c} Transport = {transport:c} TOTAL = {totalPrice:c} Program separately reports {totalDiscount:c} total discount");

            }
            else
            {
                Console.WriteLine($"Cost = {price:c} Tax = {tax:c} TOTAL = {totalPrice:c} Program reports no discounts");
            }
        }
        public void PrintExpensesCurr(double price, double tax, double totalDiscount, double transport, double totalPrice,string currType)
        {
            
                Console.WriteLine($"Cost = {price} {currType} Tax = {Math.Round(tax,2)} {currType} Discounts = {Math.Round(totalDiscount,2)} {currType} Transport = {Math.Round(transport,2)} {currType} TOTAL = {Math.Round(totalPrice, 2)} {currType} Program separately reports discount {Math.Round(totalDiscount, 2)} {currType}");
            
        }

    }
}
