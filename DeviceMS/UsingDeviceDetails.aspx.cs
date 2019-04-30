using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DeviceMS
{
    public partial class UsingDeviceDetails : System.Web.UI.Page
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

                DataSet placeDs = PlaceDAO.QueryAllPlace();
                this.UsePlace.DataSource = placeDs;
                this.UsePlace.DataBind();

                int id = Int32.Parse(Request.QueryString["id"]);
                UsingDeviceModel usingDevice = UsingDeviceDAO.GetUsingDevice(id);
                this.TypeId.SelectedValue = usingDevice.getTypeId().ToString();
                this.DeviceName.Text = usingDevice.getDeviceName().ToString();
                this.DeviceModel.Text = usingDevice.getDeviceModel().ToString();
                this.DeviceFrom.Text = usingDevice.getDeviceFrom().ToString();
                this.Manufacturer.Text = usingDevice.getManufacturer().ToString();
                this.UseDate.Text = usingDevice.getUseDate().ToShortDateString();
                this.DeviceLife.Text = usingDevice.getDeviceLife().ToString();
                this.UsePlace.SelectedValue = usingDevice.getUsePlace().ToString();
                this.DeviceCount.Text = usingDevice.getDeviceCount().ToString();
                this.DeviceState.Text = usingDevice.getDeviceState().ToString();
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            UsingDeviceModel usingDevice = new UsingDeviceModel();
            int id = Int32.Parse(Request.QueryString["id"]);
            usingDevice.setId(id);
            usingDevice.setTypeId(Int32.Parse(this.TypeId.SelectedValue));
            usingDevice.setDeviceName(this.DeviceName.Text);
            usingDevice.setDeviceModel(this.DeviceModel.Text);
            usingDevice.setDeviceFrom(this.DeviceFrom.Text);
            usingDevice.setManufacturer(this.Manufacturer.Text);
            usingDevice.setUseDate(Convert.ToDateTime(this.UseDate.Text));
            usingDevice.setDeviceLife(Int32.Parse(this.DeviceLife.Text));
            usingDevice.setUsePlace(this.UsePlace.SelectedValue);
            usingDevice.setDeviceCount(Int32.Parse(this.DeviceCount.Text));
            usingDevice.setDeviceState(this.DeviceState.Text);
            if (UsingDeviceDAO.UpdateUsingDevice(usingDevice))
                Response.Write("<script>alert('更新成功!');location.href='UsingDeviceManage.aspx';</script>");
            else
                Response.Write("<script>alert('更新失敗!');</script>");
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsingDeviceManage.aspx");
        }
    }
}