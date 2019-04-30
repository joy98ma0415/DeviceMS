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
    public class BackupDeviceModel
    {
        private int id;

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        private int typeId;

        public void setTypeId(int typeId)
        {
            this.typeId = typeId;
        }

        public int getTypeId()
        {
            return this.typeId;
        }

        private string deviceName;

        public void setDeviceName(string deviceName)
        {
            this.deviceName = deviceName;
        }

        public string getDeviceName()
        {
            return this.deviceName;
        }

        private string deviceModel;

        public void setDeviceModel(string deviceModel)
        {
            this.deviceModel = deviceModel;
        }

        public string getDeviceModel()
        {
            return this.deviceModel;
        }

        private float price;

        public void setPrice(float price)
        {
            this.price = price;
        }

        public float getPrice()
        {
            return this.price;
        }

        private string deviceFrom;

        public void setDeviceFrom(string deviceFrom)
        {
            this.deviceFrom = deviceFrom;
        }

        public string getDeviceFrom()
        {
            return this.deviceFrom;
        }

        private string manufacturer;

        public void setManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public string getManufacturer()
        {
            return this.manufacturer;
        }

        private string inDate;

        public void setInDate(string inDate)
        {
            this.inDate = inDate;
        }

        public string getInDate()
        {
            return this.inDate;
        }

        private string outDate;

        public void setOutDate(string outDate)
        {
            this.outDate = outDate;
        }

        public string getOutDate()
        {
            return this.outDate;
        }

        private int stockCount;

        public void setStockCount(int stockCount)
        {
            this.stockCount = stockCount;
        }

        public int getStockCount()
        {
            return this.stockCount;
        }

        private string inOperator;

        public void setInOperator(string inOperator)
        {
            this.inOperator = inOperator;
        }

        public string getInOperator()
        {
            return this.inOperator;
        }

        private string outOperator;

        public void setOutOperator(string outOperator)
        {
            this.outOperator = outOperator;
        }

        public string getOutOperator()
        {
            return this.outOperator;
        }
    }
}