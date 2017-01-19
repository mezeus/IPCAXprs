﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
    public class MarkupStructureBL
    {
        private DBHelper _dbHelper = new DBHelper();
        public bool SaveMarkupStructure(MarkupStructureMasterModel objMS)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@StructureName", objMS.StructureName));
                paramCollection.Add(new DBParameter("@SimpleDiscount", Convert.ToBoolean(objMS.SimpleDiscount),System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CompoundMarkupwithSameNature", objMS.CompoundMarkupwithSameNature, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CompoundMarkupDifferentNature",objMS.CompoundMarkupDifferentNature, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@NoOfMarkups", objMS.NoOfMarkups, System.Data.DbType.Int32));
                paramCollection.Add(new DBParameter("@SpecifyCaptionForMarkup", objMS.SpecifyCaptionForMarkup));
                paramCollection.Add(new DBParameter("@AbsoluteAmount", objMS.AbsoluteDiscount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PerMainQty", objMS.PerMainQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Percentage", objMS.Percentage, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PerAltQty", objMS.PerAltQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemPrice", objMS.ItemPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemMRP", objMS.ItemMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemAmount", objMS.ItemAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemListPrice", objMS.ItemListPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));

                System.Data.IDataReader dr =
                       _dbHelper.ExecuteDataReader("spInsertMarkupStructure", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveAccountPosting(objMS.ListofAccountPosting, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }
          
            return isSaved;
        }

        public bool SaveAccountPosting(List<DSAccountPosting> lstDSPosting,int parentid)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (DSAccountPosting objMSPosting in lstDSPosting)
            {
                objMSPosting.MS_Id = parentid;
                try
                {

                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@MS_Id", objMSPosting.MS_Id));
                    paramCollection.Add(new DBParameter("@AccountPosting", objMSPosting.AccountPost, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@AccountHeadPost", objMSPosting.AccountHeadPost));
                    paramCollection.Add(new DBParameter("@AffectsGoods", objMSPosting.AffectsGoods, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@CreatedBy", objMSPosting.CreatedBy));

                    System.Data.IDataReader dr =
                          _dbHelper.ExecuteDataReader("spInsertMSAccountPosting", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }

            return isSaved;
        }
     
    }
}


