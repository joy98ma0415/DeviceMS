using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DeviceMS
{
    public class UselessDeviceDAO
    {
        private string errMessage;

        public string getErrMessage()
        {
            return this.errMessage;
        }

        public UselessDeviceDAO()
        {
            this.errMessage = "";
        }

        /*登記報廢設備資訊*/

        public static bool AddUselessDevice(UselessDeviceModel uselessDevice)
        {
            string insertString = "insert into [t_device_useless] (typeId,deviceName,deviceModel,deviceFrom,deviceCount) values (";
            insertString += uselessDevice.getTypeId() + ",";
            insertString += SqlString.GetQuotedString(uselessDevice.getDeviceName()) + ",";
            insertString += SqlString.GetQuotedString(uselessDevice.getDeviceModel()) + ",";
            insertString += SqlString.GetQuotedString(uselessDevice.getDeviceFrom()) + ",";
            insertString += uselessDevice.getDeviceCount() + ")";

            DataBase db = new DataBase();
            if (db.InsertOrUpdate(insertString) > 0)
                return true;
            return false;
        }

        /*更新報廢設備資訊*/

        public static bool UpdateUselessDevice(UselessDeviceModel uselessDevice)
        {
            string updateString = "update [t_device_useless] set typeId=";
            updateString += uselessDevice.getTypeId() + ",deviceName=";
            updateString += SqlString.GetQuotedString(uselessDevice.getDeviceName()) + ",deviceModel=";
            updateString += SqlString.GetQuotedString(uselessDevice.getDeviceModel()) + ",deviceFrom=";
            updateString += SqlString.GetQuotedString(uselessDevice.getDeviceFrom()) + ",deviceCount=";
            updateString += uselessDevice.getDeviceCount() + " where id=" + uselessDevice.getId();

            DataBase db = new DataBase();
            if (db.InsertOrUpdate(updateString) > 0)
                return true;
            return true;
        }

        /*刪除報廢設備資訊*/

        public static bool DeleteUselessDevice(int id)
        {
            string deleteString = "delete from [t_device_useless] where id=" + id;
            DataBase db = new DataBase();
            return db.InsertOrUpdate(deleteString) > 0 ? true : false;
        }

        /*根據記錄號碼查詢本條設備記錄的設備類型*/

        public static string GetDeviceTypeName(int id)
        {
            string queryString = "select typeId from [t_device_useless] where id=" + id;
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

        /*根據設備名稱和設備類別查詢資訊*/

        public static DataSet QueryDeviceInfo(string deviceName, int typeId)
        {
            string queryString = "select * from [t_device_useless] where 1=1";
            if (deviceName != "")
                queryString += " and deviceName like '%" + deviceName + "%'";
            if (typeId != 0)
                queryString += " and typeId=" + typeId;
            DataBase db = new DataBase();
            return db.GetDataSet(queryString);
        }

        /*取得某個報廢設備資訊*/

        public static UselessDeviceModel GetUselessDevice(int id)
        {
            UselessDeviceModel uselessDevice = null;
            string queryString = "select * from [t_device_useless] where id=" + id;
            DataBase db = new DataBase();
            DataSet deviceDs = db.GetDataSet(queryString);
            if (deviceDs.Tables[0].Rows.Count > 0)
            {
                uselessDevice = new UselessDeviceModel();
                DataRow dr = deviceDs.Tables[0].Rows[0];
                uselessDevice.setTypeId(Convert.ToInt32(dr["typeId"]));
                uselessDevice.setDeviceName(dr["deviceName"].ToString());
                uselessDevice.setDeviceModel(dr["deviceModel"].ToString());
                uselessDevice.setDeviceFrom(dr["deviceFrom"].ToString());
                uselessDevice.setDeviceCount(Convert.ToInt32(dr["deviceCount"]));
            }
            return uselessDevice;
        }
    }
}