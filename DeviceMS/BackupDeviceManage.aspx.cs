using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DeviceMS
{
    public partial class BackupDeviceManage : System.Web.UI.Page
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
                /*初始化設備類別下拉清單*/
                ListItem li = new ListItem("請選擇", "0");
                this.TypeId.Items.Add(li);
                DataSet deviceTypeDs = DeviceTypeDAO.QueryAllDeviceType();
                for (int i = 0; i < deviceTypeDs.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = deviceTypeDs.Tables[0].Rows[i];
                    li = new ListItem(dr["typeName"].ToString(), dr["typeId"].ToString());
                    this.TypeId.Items.Add(li);
                }
            }
        }

        protected void Btn_Query_Click(object sender, EventArgs e)
        {
            string deviceName = this.DeviceName.Text;
            int typeId = Int32.Parse(this.TypeId.SelectedValue);
            DataSet ds = BackupDeviceDAO.QueryDeviceInfo(deviceName, typeId);
            this.GridView1.DataSourceID = null;
            this.GridView1.DataSource = ds;
            this.GridView1.PageIndex = 0;
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string deviceName = this.DeviceName.Text;
            int typeId = Int32.Parse(this.TypeId.SelectedValue);
            DataSet ds = BackupDeviceDAO.QueryDeviceInfo(deviceName, typeId);
            this.GridView1.DataSourceID = null;
            this.GridView1.DataSource = ds;
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //當滑鼠選擇某行時變顏色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00ffee';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");

                Literal TypeName = (Literal)e.Row.Cells[1].FindControl("TypeName");

                int id = Convert.ToInt32(this.GridView1.DataKeys[e.Row.RowIndex].Value.ToString());
                TypeName.Text = BackupDeviceDAO.GetDeviceTypeName(id);
            }
        }
    }
}