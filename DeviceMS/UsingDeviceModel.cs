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
    public class UsingDeviceModel
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

        private DateTime useDate;

        public void setUseDate(DateTime useDate)
        {
            this.useDate = useDate;
        }

        public DateTime getUseDate()
        {
            return this.useDate;
        }

        private int deviceLife;

        public void setDeviceLife(int deviceLife)
        {
            this.deviceLife = deviceLife;
        }

        public int getDeviceLife()
        {
            return this.deviceLife;
        }

        private string usePlace;

        public void setUsePlace(string usePlace)
        {
            this.usePlace = usePlace;
        }

        public string getUsePlace()
        {
            return this.usePlace;
        }

        private int deviceCount;

        public void setDeviceCount(int deviceCount)
        {
            this.deviceCount = deviceCount;
        }

        public int getDeviceCount()
        {
            return this.deviceCount;
        }

        private string deviceState;

        public void setDeviceState(string deviceState)
        {
            this.deviceState = deviceState;
        }

        public string getDeviceState()
        {
            return this.deviceState;
        }
    }
}