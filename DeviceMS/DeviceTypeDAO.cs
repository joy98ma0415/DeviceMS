using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DeviceMS
{
    public class DeviceTypeDAO
    {
        private string errMessage;  /*保存業務處理錯誤資訊*/

        public string getErrMessage()
        {
            return this.errMessage;
        }

        public DeviceTypeDAO()
        {
            this.errMessage = "";
        }

        /*查詢所有的設備類別資訊*/

        public static DataSet QueryAllDeviceType()
        {
            string sqlString = "select * from [t_device_type]";
            DataBase db = new DataBase();
            return db.GetDataSet(sqlString);
        }

        /*根據類別編號得到類別名稱*/

        public static string GetTypeNameById(int typeId)
        {
            string typeName = "";
            string queryString = "select typeName from [t_device_type] where typeId=" + typeId;
            DataBase db = new DataBase();
            DataSet deviceTypeDs = db.GetDataSet(queryString);
            if (deviceTypeDs.Tables[0].Rows.Count > 0)
            {
                DataRow dr = deviceTypeDs.Tables[0].Rows[0];
                typeName = dr["typeName"].ToString();
            }

            return typeName;
        }

        /*更新某個設備類別*/

        public bool UpdateDeviceType(int typeId, string typeName)
        {
            string queryString = "select * from [t_device_type] where typeName='" + typeName + "' and typeId <>" + typeId;
            DataBase db = new DataBase();
            DataSet ds = db.GetDataSet(queryString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.errMessage = "改類別已經存在!";
                return false;
            }
            string updateString = "update [t_device_type] set typeName='" + typeName + "' where typeId=" + typeId;
            if (db.InsertOrUpdate(updateString) < 0)
            {
                this.errMessage = "更新失敗!";
                return false;
            }
            return true;
        }

        /*刪除某個設備類別*/

        public bool DeleteDeviceType(int typeId)
        {
            string queryString = "select * from [t_device_backup] where typeId=" + typeId;
            DataBase db = new DataBase();
            DataSet ds = db.GetDataSet(queryString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.errMessage = "備用備件中還存在本類別的設備!不能刪除!";
                return false;
            }
            queryString = "select * from [t_device_using] where typeId=" + typeId;
            ds = db.GetDataSet(queryString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.errMessage = "在用設備中還存在本類別的設備!不能刪除!";
                return false;
            }
            queryString = "select * from [t_device_useless] where typeId=" + typeId;
            ds = db.GetDataSet(queryString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.errMessage = "報廢設備中還存在本類別的設備!不能刪除!";
                return false;
            }

            string deleteString = "delete from [t_device_type] where typeId=" + typeId;
            if (db.InsertOrUpdate(deleteString) < 0)
            {
                this.errMessage = "刪除類別失敗！";
                return false;
            }

            return true;
        }

        /*添加設備類別資訊*/

        public bool AddDeviceType(string typeName)
        {
            string queryString = "select * from [t_device_type] where typeName=" + SqlString.GetQuotedString(typeName);
            DataBase db = new DataBase();
            DataSet ds = db.GetDataSet(queryString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.errMessage = "此類別名稱已經存在！";
                return false;
            }
            string insertString = "insert into [t_device_type] (typeName) values ('" + typeName + "')";
            if (db.InsertOrUpdate(insertString) < 0)
            {
                this.errMessage = "添加類別失敗!";
                return false;
            }

            return true;
        }
    }
}