using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public enum TaxType
    {
        VATIncl,
        VATExl,
        CSTIncl,
        CSTExl,
        GSTInclLocal,
        GSTInclCentral,
        GSTExclLocal,
        GSTExclCentral
    }

    public class SaleTypeTaxCalculation
    {

        public TaxCalculationModel GetCalculatedTax(TaxType eTaxType, decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab,decimal totalAmount)
        {
            TaxCalculationModel objIncTax = new TaxCalculationModel();

            switch(eTaxType)
            {
                case TaxType.VATExl:

                    break;
                case TaxType.VATIncl:
                    objIncTax=VATInclusive(Qty,Price,BasicAmt,Taxslab,totalAmount);
                    break;
                case TaxType.CSTExl:

                    break;
                case TaxType.CSTIncl:

                    break;
            }


            return objIncTax;
        }

        private TaxCalculationModel VATInclusive(decimal Qty, decimal Price,decimal BasicAmt, decimal Taxslab,decimal totalAmount)
        {
            //1. Qty, Taxslab, (price or basic amount or total amount)
            
            TaxCalculationModel objIncTax = new TaxCalculationModel();

            if(Qty==0 && Price==0 && BasicAmt==0 && totalAmount==0)
            {
                return objIncTax;
            }

            //1. Only Qty and Total Amount is given

            if (totalAmount>0)
               Price = Price==0? (totalAmount / Qty) - (totalAmount / Qty) * (Taxslab / (100 + Taxslab)):Price;

            //2. Only Qty and Price is given

            //3. Only Qty and Basic Amount is given
            if(BasicAmt>0)
                Price = Price == 0 ? BasicAmt / Qty : Price;

            //4. Only Qty, Price and Basic Amount is given
                        
            objIncTax.NetAmount = (Qty * Price);
            objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
            objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
            objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;

            objIncTax.Price = Price;


            //if (Price == 0)
            //{
            //    Price = BasicAmt / Qty;
            //    objIncTax.NetAmount = (Qty * Price);
            //    objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
            //    objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
            //    objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
            //    objIncTax.Price = Price;

            //}
            //else
            //{
            //    objIncTax.NetAmount = (Qty * Price);
            //    objIncTax.TaxAmount = (objIncTax.NetAmount * Taxslab) / (100 + Taxslab);
            //    objIncTax.BasicAmount = objIncTax.NetAmount - objIncTax.TaxAmount;
            //    objIncTax.TotalAmount = objIncTax.BasicAmount + objIncTax.TaxAmount;
            //    objIncTax.Price = Price;
            //}

            return objIncTax;
        }
        private TaxCalculationModel CSTInclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
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
        public TaxCalculationModel VATExclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
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
        public TaxCalculationModel LGSTExclusive(decimal Qty, decimal Price, decimal BasicAmt, decimal Taxslab)
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
