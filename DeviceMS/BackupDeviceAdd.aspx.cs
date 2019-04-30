using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeviceMS
{
    public partial class BackupDeviceAdd : System.Web.UI.Page
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
            BackupDeviceModel backupDevice = new BackupDeviceModel();
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

            if (BackupDeviceDAO.AddBackupDevice(backupDevice))
                Response.Write("<script>alert('備用備件登記成功!');location.href='BackupDeviceAdd.aspx';</script>");
            else
                Response.Write("<script>alert('備用備件登記失敗!');location.href='BackupDeviceAdd.aspx';</script>");
        }
    }
}