using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeviceMS
{
    public partial class UselessDeviceAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('請先登入系統！');top.location.href='login.aspx';</script>");
                return;
            }
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            UselessDeviceModel uselessDevice = new UselessDeviceModel();
            uselessDevice.setTypeId(Int32.Parse(this.TypeId.SelectedValue));
            uselessDevice.setDeviceName(this.DeviceName.Text);
            uselessDevice.setDeviceModel(this.DeviceModel.Text);
            uselessDevice.setDeviceFrom(this.DeviceFrom.Text);
            uselessDevice.setDeviceCount(Int32.Parse(this.DeviceCount.Text));

            if (UselessDeviceDAO.AddUselessDevice(uselessDevice))
                Response.Write("<script>alert('報廢設備登記成功!');location.href='UselessDeviceAdd.aspx';</script>");
            else
                Response.Write("<script>alert('報廢設備登記失敗!');location.href='UselessDeviceAdd.aspx';</script>");
        }
    }
}