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
    public class UselessDeviceModel
    {
        private int id;
        private int typeId;
        private string deviceName;
        private string deviceModel;
        private string deviceFrom;
        private int deviceCount;

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setTypeId(int typeId)
        {
            this.typeId = typeId;
        }

        public int getTypeId()
        {
            return this.typeId;
        }

        public void setDeviceName(string deviceName)
        {
            this.deviceName = deviceName;
        }

        public string getDeviceName()
        {
            return this.deviceName;
        }

        public void setDeviceModel(string deviceModel)
        {
            this.deviceModel = deviceModel;
        }

        public string getDeviceModel()
        {
            return this.deviceModel;
        }

        public void setDeviceFrom(string deviceFrom)
        {
            this.deviceFrom = deviceFrom;
        }

        public string getDeviceFrom()
        {
            return this.deviceFrom;
        }

        public void setDeviceCount(int deviceCount)
        {
            this.deviceCount = deviceCount;
        }

        public int getDeviceCount()
        {
            return this.deviceCount;
        }
    }
}