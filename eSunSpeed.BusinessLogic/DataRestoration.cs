using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
    public class DataRestoration
    {
        private DBHelper _dbHelper = new DBHelper();
        public bool SaveDR(DataRestorationModel objDR)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@NB_Restor", objDR.Normal_Backup,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Path",objDR.Path));
                paramCollection.Add(new DBParameter("@FTP", objDR.FTP_Backup, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Sname", objDR.Servername));
                paramCollection.Add(new DBParameter("@Port", objDR.Port));
                paramCollection.Add(new DBParameter("@Uname", objDR.Username));
                paramCollection.Add(new DBParameter("@Password", objDR.Password));
                paramCollection.Add(new DBParameter("@Folder", objDR.Folder));
                //paramCollection.Add(new DBParameter("@id", "1"));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
               
                Query = "INSERT INTO BackupRestore([NB_Restore],[Path],[FTP_Restore],[Server_Name],[Port_No],[User_Name],[Password],[BK_Folder],[Creaded_By]) " +
                    "VALUES(@NB_Restor,@Path,@FTP,@Sname,@Port,@Uname,@Password,@Folder,@CreatedBy)";

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
        public bool UpDateDR(DataRestorationModel objDR)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@NB_Restor", objDR.Normal_Backup, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Path", objDR.Path));
                paramCollection.Add(new DBParameter("@FTP", objDR.FTP_Backup, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Sname", objDR.Servername));
                paramCollection.Add(new DBParameter("@Port", objDR.Port));
                paramCollection.Add(new DBParameter("@Uname", objDR.Username));
                paramCollection.Add(new DBParameter("@Password", objDR.Password));
                paramCollection.Add(new DBParameter("@Folder", objDR.Folder));
                paramCollection.Add(new DBParameter("@id", "1"));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                Query = "INSERT INTO BackupRestore([NB_Restore],[Path],[FTP_Restore],[Server_Name],[Port_No],[User_Name],[Password],[BK_Folder],[Creaded_By]) " +
                    "VALUES(@NB_Restor,@Path,@FTP,@Sname,@Port,@Uname,@Password,@Folder,@CreatedBy)";

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
