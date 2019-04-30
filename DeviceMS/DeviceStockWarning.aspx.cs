using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace DeviceMS
{
    public partial class DeviceStockWarning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('請先登入系統！');top.location.href='login.aspx';</script>");
                return;
            }

            ArrayList devices = UsingDeviceDAO.GetStockWarningDevices();
            if (devices.Count == 0)
            {
                this.Devices.Text = "<font color=blue>暫時還沒有設備需要購買！</font>";
            }
            else
            {
                this.Devices.Text += "<font color=blue>";
                for (int i = 0; i < devices.Count; i++)
                {
                    this.Devices.Text += devices[i].ToString() + "<br>";
                }
                this.Devices.Text += "</font>";
            }
        }
    }
}