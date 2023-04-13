using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_KATA_solid_.Interfaces;
using The_KATA_solid_.Models;
using The_KATA_solid_.Services;

namespace The_KATA_solid_
{
    public class Calculater
    {
        Product product=new Product
        {
            Name= "The Little Prince",
            Price=20.25,
            UPC=12345,
            TypeCurrencies = "USD"
        };
        Tax tax=new Tax {TaxPercentage=21.00};
        PrintMethod print=new PrintMethod();
        Discount discount = new Discount
        {
            discountPercentage = 15.00,
            discountPercentageUPC=7.00,
            precedenceDiscount="before",
            precedenceDiscountUPC="after"
        };
        Expenses expenses = new Expenses
        {
            transportCost = 3,
            packegingCost=1.0
    };
        Compining compining = new Compining
        {
            discountType= "multiplicative"
        };
        Cap cap = new Cap
        {
           capValue=4,
           capPercentage=0
        };
        public Calculater(ITaxOperation taxOperation,IDiscountOperation discountOperation,IExpensesOperation expensesOperation,ICapOperation capOperation)
        {
            double _taxAmount;
            double _discountAmount;
            double _discountAmountUpc;
            double remainingPrice;
            double totalDiscount;
            double finalPrice;
            double ExtraPrice;
            double _packegingCost;
            double _transportCost;
            double finalDiscount;
            if (discount.precedenceDiscount == "after" && discount.precedenceDiscountUPC == "before")
            {
                _discountAmountUpc = discountOperation.discountUpc(product.Price, discount.discountPercentageUPC, product.UPC);
                remainingPrice = product.Price - _discountAmountUpc;
                _taxAmount = taxOperation.TaxAmount(remainingPrice, tax.TaxPercentage);
                _discountAmount = discountOperation.discount(remainingPrice, discount.discountPercentage);
                totalDiscount=_discountAmount+_discountAmountUpc;
                finalPrice=product.Price - _discountAmountUpc+_taxAmount-_discountAmount;
               // print.PrintDiscountUpc(finalPrice, totalDiscount, _discountAmountUpc);
            }
            else if (discount.precedenceDiscount == "before" && discount.precedenceDiscountUPC == "before")
            {
                _discountAmountUpc = discountOperation.discountUpc(product.Price, discount.discountPercentageUPC, product.UPC);
              
                _discountAmount = discountOperation.discount(product.Price, discount.discountPercentage);
                remainingPrice = product.Price - _discountAmountUpc-_discountAmount;
                totalDiscount = _discountAmount + _discountAmountUpc;
                _taxAmount = taxOperation.TaxAmount(remainingPrice, tax.TaxPercentage);
                
                
                finalPrice = product.Price - _discountAmountUpc + _taxAmount - _discountAmount;
              //  print.PrintDiscountUpc(finalPrice, totalDiscount, _discountAmountUpc);
            }
            else if (discount.precedenceDiscount == "before" && discount.precedenceDiscountUPC == "after")
            {
                _discountAmount = discountOperation.discount(product.Price, discount.discountPercentage);
                remainingPrice = product.Price  - _discountAmount;

                _taxAmount = taxOperation.TaxAmount(remainingPrice, tax.TaxPercentage);
                _discountAmountUpc = discountOperation.discountUpc(remainingPrice, discount.discountPercentageUPC, product.UPC);
                totalDiscount = _discountAmountUpc + _discountAmount;
                finalPrice = product.Price - _discountAmountUpc + _taxAmount - _discountAmount;
              //  print.PrintDiscountUpc(finalPrice, totalDiscount, _discountAmountUpc);
            }
            else
            {
                _taxAmount = taxOperation.TaxAmount(product.Price, tax.TaxPercentage);
                double FinalPrice = product.Price + _taxAmount;
                _discountAmount = discountOperation.discount(product.Price, discount.discountPercentage) + discountOperation.discountUpc(product.Price, discount.discountPercentageUPC, product.UPC);
                _discountAmountUpc = discountOperation.discountUpc(product.Price, discount.discountPercentageUPC, product.UPC);
                double priceAfterDiscount = FinalPrice - _discountAmount;

             //   print.PrintDiscountUpc(priceAfterDiscount, _discountAmount, _discountAmountUpc);
            }
            /*   _taxAmount = taxOperation.TaxAmount(product.Price, tax.TaxPercentage);
                _discountAmount = discountOperation.discount(product.Price, discount.discountPercentage) + discountOperation.discountUpc(product.Price, discount.discountPercentageUPC, product.UPC);
                _discountAmountUpc = discountOperation.discountUpc(product.Price, discount.discountPercentageUPC, product.UPC);
                ExtraPrice = expensesOperation.expenses(expenses.packegingCost, product.Price, expenses.transportCost);
                finalPrice=product.Price+_taxAmount-_discountAmount+ExtraPrice;
                _packegingCost=product.Price*expenses.packegingCost/100;
                     print.PrintExpenses(product.Price, _taxAmount, _discountAmount,_packegingCost ,expenses.transportCost, finalPrice);
                */
            _taxAmount =Math.Round( taxOperation.TaxAmount(product.Price, tax.TaxPercentage),2);
            finalPrice = product.Price + _taxAmount;
          //  print.PrintCurr(product.Price,_taxAmount,finalPrice,product.TypeCurrencies);
            
            
            if (compining.discountType == "additive")
            {
                _taxAmount = taxOperation.TaxAmount(product.Price, tax.TaxPercentage);
                _discountAmount = discountOperation.discount(product.Price, discount.discountPercentage) ;
                _discountAmountUpc = discountOperation.discountUpc(product.Price, discount.discountPercentageUPC, product.UPC);
                totalDiscount = _discountAmount + _discountAmountUpc;
                finalDiscount= capOperation.capProcess(product.Price, totalDiscount, cap.capValue, cap.capPercentage);
                ExtraPrice = expensesOperation.expenses(expenses.packegingCost, product.Price, expenses.transportCost);
                finalPrice = product.Price + _taxAmount - finalDiscount + ExtraPrice;
                _packegingCost=product.Price*expenses.packegingCost/100;
                
           //      print.PrintExpenses(product.Price, _taxAmount, finalDiscount,_packegingCost ,expenses.transportCost, finalPrice);
                

            }
            else if(compining.discountType== "multiplicative")
            {
                _taxAmount = taxOperation.TaxAmount(product.Price, tax.TaxPercentage);
                _discountAmount = discountOperation.discount(product.Price, discount.discountPercentage);
                _discountAmountUpc = discountOperation.discountUpc(product.Price-_discountAmount, discount.discountPercentageUPC, product.UPC);
                ExtraPrice = expensesOperation.expensesTransportPercentage(product.Price, expenses.transportCost);
                totalDiscount = _discountAmount + _discountAmountUpc;
                finalPrice = product.Price + _taxAmount - totalDiscount + ExtraPrice;
                _packegingCost = product.Price * expenses.packegingCost / 100;
                _transportCost = product.Price * expenses.transportCost / 100;
                //print.PrintExpenses(product.Price, _taxAmount, totalDiscount, _packegingCost, _transportCost, finalPrice);
                print.PrintExpensesCurr(product.Price, _taxAmount,totalDiscount,_transportCost,finalPrice,product.TypeCurrencies);
            }
           

        }


    }
}
