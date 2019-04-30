using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeviceMS
{
    public partial class UsingDeviceAdd : System.Web.UI.Page
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
            UsingDeviceModel usingDevice = new UsingDeviceModel();
            usingDevice.setTypeId(Int32.Parse(this.TypeId.SelectedValue));
            usingDevice.setDeviceName(this.DeviceName.Text);
            usingDevice.setDeviceModel(this.DeviceModel.Text);
            usingDevice.setDeviceFrom(this.DeviceFrom.Text);
            usingDevice.setManufacturer(this.Manufacturer.Text);
            usingDevice.setUseDate(Convert.ToDateTime(this.UseDate.Text));
            usingDevice.setDeviceLife(Int32.Parse(this.deviceLife.Text));
            usingDevice.setUsePlace(this.UsePlace.SelectedValue);
            usingDevice.setDeviceCount(Int32.Parse(this.DeviceCount.Text));
            usingDevice.setDeviceState(this.DeviceState.Text);

            if (UsingDeviceDAO.AddUsingDevice(usingDevice))
                Response.Write("<script>alert('在用設備登記成功!');location.href='UsingDeviceAdd.aspx';</script>");
            else
                Response.Write("<script>alert('在用設備登記失敗!');location.href='UsingDeviceAdd.aspx';</script>");
        }
    }
}