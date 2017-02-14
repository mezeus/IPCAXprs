using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public class SaleTypeTaxCalculation
    {
        public TaxCalculationModel VATInclusive(decimal Qty, decimal Price,decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objIncTax = new TaxCalculationModel();
            if (Price == 0)
            {
                Price = BasicAmt / Qty;
                objIncTax.NetAmount = (Qty * Price);
                objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
                objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
                objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
                objIncTax.Price = Price;

            }
            else
            {
                objIncTax.NetAmount = (Qty * Price);
                objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
                objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
                objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
                objIncTax.Price = Price;
            }
            return objIncTax;
        }
        public TaxCalculationModel CSTInclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objIncTax = new TaxCalculationModel();
            if(Price==0)
            {
                Price = BasicAmt / Qty;
                objIncTax.NetAmount = (Qty * Price);
                objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
                objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
                objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
            }
            else
            {
                objIncTax.NetAmount = (Qty * Price);
                objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
                objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
                objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
            }
            
            return objIncTax;
        }
        public TaxCalculationModel VATExeclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objExeTax = new TaxCalculationModel();

            Price = BasicAmt / Qty;
            objExeTax.NetAmount = (Qty * Price);
            objExeTax.TaxAmount = (objExeTax.NetAmount * Taxslab) / (100);
            objExeTax.BasicAmount = objExeTax.NetAmount;
            objExeTax.TotalAmount = objExeTax.BasicAmount + objExeTax.TaxAmount;
            objExeTax.Price = Price;
            return objExeTax;
        }
        public TaxCalculationModel CSTExeclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objExeTax = new TaxCalculationModel();
            objExeTax.NetAmount = (Qty * Price);
            objExeTax.TaxAmount = (objExeTax.NetAmount * Taxslab) / (100);
            objExeTax.BasicAmount = objExeTax.NetAmount;
            objExeTax.TotalAmount = objExeTax.BasicAmount + objExeTax.TaxAmount;
            return objExeTax;
        }

        public TaxCalculationModel LGSTInclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objIncTax = new TaxCalculationModel();
            objIncTax.NetAmount = (Qty * Price);
            objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
            objIncTax.CGSTAmount = objIncTax.TaxAmount / 2;
            objIncTax.SGSTAmount = objIncTax.TaxAmount / 2;
            objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
            objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
            return objIncTax;
        }
        public TaxCalculationModel CGSTInclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objIncTax = new TaxCalculationModel();
            objIncTax.NetAmount = (Qty * Price);
            objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
            objIncTax.IGSTAmount = objIncTax.TaxAmount;
            objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
            objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
            return objIncTax;
        }
        public TaxCalculationModel LGSTExeclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objExeTax = new TaxCalculationModel();
            objExeTax.NetAmount = (Qty * Price);
            objExeTax.TaxAmount = (objExeTax.NetAmount * Taxslab) / (100);
            objExeTax.CGSTAmount = objExeTax.TaxAmount / 2;
            objExeTax.SGSTAmount = objExeTax.TaxAmount / 2;
            objExeTax.BasicAmount = objExeTax.NetAmount;
            objExeTax.TotalAmount = objExeTax.BasicAmount + objExeTax.TaxAmount;
            return objExeTax;
        }
        public TaxCalculationModel CGSTExeclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
        {
            TaxCalculationModel objExeTax = new TaxCalculationModel();
            objExeTax.NetAmount = (Qty * Price);
            objExeTax.TaxAmount = (objExeTax.NetAmount * Taxslab) / (100);
            objExeTax.IGSTAmount = objExeTax.TaxAmount;
            objExeTax.BasicAmount = objExeTax.NetAmount;
            objExeTax.TotalAmount = objExeTax.BasicAmount + objExeTax.TaxAmount;
            return objExeTax;
        }
    }
}
