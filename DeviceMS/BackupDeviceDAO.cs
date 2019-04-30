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
    public class BackupDeviceDAO
    {
        private string errMessage; /*保存業務處理時的錯誤資訊*/

        public string getErrMessage()
        {
            return this.errMessage;
        }

        public BackupDeviceDAO()
        {
            this.errMessage = "";
        }

        /*登記備用備件資訊*/

        public static bool AddBackupDevice(BackupDeviceModel backupDevice)
        {
            //string sqlString = string.Format("insert into [t_device_backup] (typeId,deviceName,deviceModel,price,deviceFrom,manufacturer,inDate,outDate,stockCount,inOperator,outOperator) values '{0}', '{1}', N'{2}', N'{3}', '{4}', N'{5}', N'{6}', '{7}', '{8}', N'{9}', N'{10}'",
            string sqlString = "insert into [t_device_backup] (typeId,deviceName,deviceModel,price,deviceFrom,manufacturer,inDate,outDate,stockCount,inOperator,outOperator) values (";
            sqlString += backupDevice.getTypeId() + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getDeviceName()) + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getDeviceModel()) + ",";
            sqlString += backupDevice.getPrice() + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getDeviceFrom()) + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getManufacturer()) + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getInDate()) + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getOutDate()) + ",";
            sqlString += backupDevice.getStockCount() + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getInOperator()) + ",";
            sqlString += SqlString.GetQuotedString(backupDevice.getOutOperator()) + ")";

            DataBase db = new DataBase();
            if (db.InsertOrUpdate(sqlString) < 0)
                return false;
            return true;
        }

        /*更新備用備件資訊*/

        public static bool UpdateDeviceModel(BackupDeviceModel backupDevice)
        {
            string updateSql = "update [t_device_backup] set ";
            updateSql += "typeId=" + backupDevice.getTypeId() + ",";
            updateSql += "deviceName=" + SqlString.GetQuotedString(backupDevice.getDeviceName()) + ",";
            updateSql += "deviceModel=" + SqlString.GetQuotedString(backupDevice.getDeviceModel()) + ",";
            updateSql += "price=" + backupDevice.getPrice() + ",";
            updateSql += "deviceFrom=" + SqlString.GetQuotedString(backupDevice.getDeviceFrom()) + ",";
            updateSql += "manufacturer=" + SqlString.GetQuotedString(backupDevice.getManufacturer()) + ",";
            updateSql += "inDate=" + SqlString.GetQuotedString(backupDevice.getInDate()) + ",";
            updateSql += "outDate=" + SqlString.GetQuotedString(backupDevice.getOutDate()) + ",";
            updateSql += "stockCount=" + backupDevice.getStockCount() + ",";
            updateSql += "inOperator=" + SqlString.GetQuotedString(backupDevice.getInOperator()) + ",";
            updateSql += "outOperator=" + SqlString.GetQuotedString(backupDevice.getOutOperator());
            updateSql += " where id=" + backupDevice.getId();

            DataBase db = new DataBase();
            if (db.InsertOrUpdate(updateSql) < 0)
                return false;
            return true;
        }

        /*刪除某個備用設備資訊*/

        public static bool DeleteDevice(int id)
        {
            string deleteString = "delete from [t_device_backup] where id=" + id;
            DataBase db = new DataBase();
            return db.InsertOrUpdate(deleteString) > 0 ? true : false;
        }

        /*取得某個備用設備資訊*/

        public static BackupDeviceModel GetBackupDevice(int id)
        {
            BackupDeviceModel backupDevice = null;
            string queryString = "select * from [t_device_backup] where id=" + id;
            DataBase db = new DataBase();
            DataSet deviceDs = db.GetDataSet(queryString);
            if (deviceDs.Tables[0].Rows.Count > 0)
            {
                backupDevice = new BackupDeviceModel();
                DataRow dr = deviceDs.Tables[0].Rows[0];
                backupDevice.setTypeId(Convert.ToInt32(dr["typeId"]));
                backupDevice.setDeviceName(dr["deviceName"].ToString());
                backupDevice.setDeviceModel(dr["deviceModel"].ToString());
                backupDevice.setPrice(Convert.ToSingle(dr["price"]));
                backupDevice.setDeviceFrom(dr["deviceFrom"].ToString());
                backupDevice.setManufacturer(dr["manufacturer"].ToString());
                backupDevice.setInDate(dr["inDate"].ToString());
                backupDevice.setOutDate(dr["outDate"].ToString());
                backupDevice.setStockCount(Convert.ToInt32(dr["stockCount"]));
                backupDevice.setInOperator(dr["inOperator"].ToString());
                backupDevice.setOutOperator(dr["outOperator"].ToString());
            }
            return backupDevice;
        }

        /*根據設備名稱和設備類別查詢資訊*/

        public static DataSet QueryDeviceInfo(string deviceName, int typeId)
        {
            string queryString = "select * from [t_device_backup] where 1=1";
            if (deviceName != "")
                queryString += " and deviceName like '%" + deviceName + "%'";
            if (typeId != 0)
                queryString += " and typeId=" + typeId;
            DataBase db = new DataBase();
            return db.GetDataSet(queryString);
        }

        /*根據記錄號碼查詢本條設備記錄的設備類型*/

        public static string GetDeviceTypeName(int id)
        {
            string queryString = "select typeId from [t_device_backup] where id=" + id;
            DataBase db = new DataBase();
            DataSet deviceDs = db.GetDataSet(queryString);
            int typeId = 0;
            if (deviceDs.Tables[0].Rows.Count > 0)
            {
                DataRow dr = deviceDs.Tables[0].Rows[0];
                typeId = Convert.ToInt32(dr["typeId"]);
            }

            return DeviceTypeDAO.GetTypeNameById(typeId);
        }
    }
}