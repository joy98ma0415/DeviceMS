using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DeviceMS
{
    public partial class BackupDeviceDetails : System.Web.UI.Page
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
                BackupDeviceModel backupDevice = BackupDeviceDAO.GetBackupDevice(id);
                this.TypeId.SelectedValue = backupDevice.getTypeId().ToString();
                this.DeviceName.Text = backupDevice.getDeviceName();
                this.DeviceModel.Text = backupDevice.getDeviceModel();
                this.Price.Text = backupDevice.getPrice().ToString();
                this.DeviceFrom.Text = backupDevice.getDeviceFrom();
                this.Manufacturer.Text = backupDevice.getManufacturer();
                this.InDate.Text = backupDevice.getInDate();
                this.OutDate.Text = backupDevice.getOutDate();
                this.StockCount.Text = backupDevice.getStockCount().ToString();
                this.InOperator.Text = backupDevice.getInOperator();
                this.OutOperator.Text = backupDevice.getOutOperator();
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            BackupDeviceModel backupDevice = new BackupDeviceModel();
            int id = Int32.Parse(Request.QueryString["id"]);
            backupDevice.setId(id);
            backupDevice.setTypeId(Int32.Parse(this.TypeId.SelectedValue));
            backupDevice.setDeviceName(this.DeviceName.Text);
            backupDevice.setDeviceModel(this.DeviceModel.Text);
            backupDevice.setPrice(Convert.ToSingle(this.Price.Text));
            backupDevice.setDeviceFrom(this.DeviceFrom.Text);
            backupDevice.setManufacturer(this.Manufacturer.Text);
            backupDevice.setInDate(this.InDate.Text);
            backupDevice.setOutDate(this.OutDate.Text);
            backupDevice.setStockCount(Int32.Parse(this.StockCount.Text));
            backupDevice.setInOperator(this.InOperator.Text);
            backupDevice.setOutOperator(this.OutOperator.Text);

            if (BackupDeviceDAO.UpdateDeviceModel(backupDevice))
                Response.Write("<script>alert('更新成功!');location.href='BackupDeviceManage.aspx';</script>");
            else
                Response.Write("<script>alert('更新失敗!');</script>");
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("BackupDeviceManage.aspx");
        }
    }
}