using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace DeviceMS
{
    public class UsingDeviceDAO
    {
        private string errMessage;  /*保存業務處理錯誤資訊*/

        public string getErrMessage()
        {
            return this.errMessage;
        }

        public UsingDeviceDAO()
        {
            this.errMessage = "";
        }

        /*添加在用設備資訊*/

        public static bool AddUsingDevice(UsingDeviceModel usingDevice)
        {
            string insertString = "insert into [t_device_using] (typeId,deviceName,deviceModel,deviceFrom,manufacturer,useDate,deviceLife,usePlace,deviceCount,deviceState) values (";
            insertString += usingDevice.getTypeId() + ",";
            insertString += SqlString.GetQuotedString(usingDevice.getDeviceName()) + ",";
            insertString += SqlString.GetQuotedString(usingDevice.getDeviceModel()) + ",";
            insertString += SqlString.GetQuotedString(usingDevice.getDeviceFrom()) + ",";
            insertString += SqlString.GetQuotedString(usingDevice.getManufacturer()) + ",";
            insertString += SqlString.GetQuotedString(usingDevice.getUseDate().ToString()) + ",";
            insertString += usingDevice.getDeviceLife() + ",";
            insertString += SqlString.GetQuotedString(usingDevice.getUsePlace()) + ",";
            insertString += usingDevice.getDeviceCount() + ",";
            insertString += SqlString.GetQuotedString(usingDevice.getDeviceState()) + ")";

            DataBase db = new DataBase();
            if (db.InsertOrUpdate(insertString) < 0)
                return false;
            return true;
        }

        /*更新在用設備資訊*/

        public static bool UpdateUsingDevice(UsingDeviceModel usingDevice)
        {
            string updateString = "update [t_device_using] set typeId=";
            updateString += usingDevice.getTypeId() + ",deviceName=";
            updateString += SqlString.GetQuotedString(usingDevice.getDeviceName()) + ",deviceModel=";
            updateString += SqlString.GetQuotedString(usingDevice.getDeviceModel()) + ",deviceFrom=";
            updateString += SqlString.GetQuotedString(usingDevice.getDeviceFrom()) + ",manufacturer=";
            updateString += SqlString.GetQuotedString(usingDevice.getManufacturer()) + ",useDate=";
            updateString += SqlString.GetQuotedString(usingDevice.getUseDate().ToString()) + ",deviceLife=";
            updateString += usingDevice.getDeviceLife() + ",usePlace=";
            updateString += SqlString.GetQuotedString(usingDevice.getUsePlace()) + ",deviceCount=";
            updateString += usingDevice.getDeviceCount() + ",deviceState=";
            updateString += SqlString.GetQuotedString(usingDevice.getDeviceState());
            updateString += " where id=" + usingDevice.getId();

            DataBase db = new DataBase();
            if (db.InsertOrUpdate(updateString) < 0)
                return false;
            return true;
        }

        /*刪除在用設備資訊*/

        public static bool DeleteUsingDevice(int id)
        {
            string deleteString = "delete from [t_device_using] where id=" + id;
            DataBase db = new DataBase();
            return db.InsertOrUpdate(deleteString) > 0 ? true : false;
        }

        /*根據設備名稱和設備類別和使用地點查詢資訊*/

        public static DataSet QueryDeviceInfo(string deviceName, int typeId, string usePlace)
        {
            string queryString = "select * from [t_device_using] where 1=1";
            if (deviceName != "")
                queryString += " and deviceName like '%" + deviceName + "%'";
            if (typeId != 0)
                queryString += " and typeId=" + typeId;
            if (usePlace != "")
                queryString += " and usePlace='" + usePlace + "'";
            DataBase db = new DataBase();
            return db.GetDataSet(queryString);
        }

        /*根據記錄號碼查詢本條設備記錄的設備類型*/

        public static string GetDeviceTypeName(int id)
        {
            string queryString = "select typeId from [t_device_using] where id=" + id;
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

        /*取得某個在用設備資訊*/

        public static UsingDeviceModel GetUsingDevice(int id)
        {
            UsingDeviceModel usingDevice = null;
            string queryString = "select * from [t_device_using] where id=" + id;
            DataBase db = new DataBase();
            DataSet deviceDs = db.GetDataSet(queryString);
            if (deviceDs.Tables[0].Rows.Count > 0)
            {
                usingDevice = new UsingDeviceModel();
                DataRow dr = deviceDs.Tables[0].Rows[0];
                usingDevice.setTypeId(Convert.ToInt32(dr["typeId"]));
                usingDevice.setDeviceName(dr["deviceName"].ToString());
                usingDevice.setDeviceModel(dr["deviceModel"].ToString());
                usingDevice.setDeviceFrom(dr["deviceFrom"].ToString());
                usingDevice.setManufacturer(dr["manufacturer"].ToString());
                usingDevice.setUseDate(Convert.ToDateTime(dr["useDate"]));
                usingDevice.setDeviceLife(Convert.ToInt32(dr["deviceLife"]));
                usingDevice.setUsePlace(dr["usePlace"].ToString());
                usingDevice.setDeviceCount(Convert.ToInt32(dr["deviceCount"]));
                usingDevice.setDeviceState(dr["deviceState"].ToString());
            }
            return usingDevice;
        }

        /*找出庫存報警的設備*/

        public static ArrayList GetStockWarningDevices()
        {
            ArrayList devices = new ArrayList();
            string queryString = "select * from [t_device_using]";
            DataBase db = new DataBase();
            DataSet usingDeviceDs = db.GetDataSet(queryString);
            for (int i = 0; i < usingDeviceDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = usingDeviceDs.Tables[0].Rows[i];
                /*設備名稱*/
                string deviceName = dr["deviceName"].ToString();
                /*使用開始時間*/
                DateTime useDate = Convert.ToDateTime(dr["useDate"]);
                /*使用壽命*/
                int deviceLife = Convert.ToInt32(dr["deviceLife"]);
                /*當前時間*/
                DateTime nowDate = DateTime.Now;
                /*計算已經使用的天數*/
                TimeSpan ts = nowDate - useDate;
                int haveUsedDays = Convert.ToInt32(ts.TotalDays);
                /*計算剩餘可以使用的天數*/
                int leftDays = deviceLife - haveUsedDays;
                if (leftDays < Constant.WARNING_DAYS)
                {
                    /*如果在用設備壽命即將到期，查詢備用備件中該設備是否存在*/
                    queryString = "select * from [t_device_backup] where deviceName=" + SqlString.GetQuotedString(deviceName);
                    DataSet backupDeviceDs = db.GetDataSet(queryString);
                    if (backupDeviceDs.Tables[0].Rows.Count == 0)
                    {
                        /*如果備用設備不存在，則將該設備名稱加入到庫存報警資訊中*/
                        devices.Add(deviceName);
                    }
                }
            }

            return devices;
        }
    }
}