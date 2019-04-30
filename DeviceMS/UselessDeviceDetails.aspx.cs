using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DeviceMS
{
    public partial class UselessDeviceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('請先登入系統！');top.location.href='login.aspx';</script>");
                return;
            }
            if (!IsPostBack)
            {
                DataSet deviceTypeDs = DeviceTypeDAO.QueryAllDeviceType();
                for (int i = 0; i < deviceTypeDs.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = deviceTypeDs.Tables[0].Rows[i];
                    ListItem li = new ListItem(dr["typeName"].ToString(), dr["typeId"].ToString());
                    this.TypeId.Items.Add(li);
                }
                int id = Int32.Parse(Request.QueryString["id"]);
                UselessDeviceModel uselessDevice = UselessDeviceDAO.GetUselessDevice(id);
                this.TypeId.SelectedValue = uselessDevice.getTypeId().ToString();
                this.DeviceName.Text = uselessDevice.getDeviceName();
                this.DeviceModel.Text = uselessDevice.getDeviceModel();
                this.DeviceFrom.Text = uselessDevice.getDeviceFrom();
                this.DeviceCount.Text = uselessDevice.getDeviceCount().ToString();
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            UselessDeviceModel uselessDevice = new UselessDeviceModel();
            int id = Int32.Parse(Request.QueryString["id"]);
            uselessDevice.setId(id);
            uselessDevice.setTypeId(Int32.Parse(this.TypeId.SelectedValue));
            uselessDevice.setDeviceName(this.DeviceName.Text);
            uselessDevice.setDeviceModel(this.DeviceModel.Text);
            uselessDevice.setDeviceFrom(this.DeviceFrom.Text);
            uselessDevice.setDeviceCount(Int32.Parse(this.DeviceCount.Text));

            if (UselessDeviceDAO.UpdateUselessDevice(uselessDevice))
                Response.Write("<script>alert('更新成功!');location.href='UselessDeviceManage.aspx';</script>");
            else
                Response.Write("<script>alert('更新失败!');</script>");
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UselessDeviceManage.aspx");
        }
    }
}