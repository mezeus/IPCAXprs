using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeed.DataAccess;
using eSunSpeedDomain;
using eSunSpeed.Formatting;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public class TdsCategoryBL
    {
        private DBHelper _dbHelper = new DBHelper();

        public bool SaveTdsCategory(TdsModel objtdsmod)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objtdsmod.TdsCategoryName));
                paramCollection.Add(new DBParameter("@Selectcode", objtdsmod.Selectcode));



                Query = Query = "INSERT INTO TbdsCategory (`Name`,`Selectcode`) " +
                "VALUES (@Name,@Selectcode)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }
    }
}