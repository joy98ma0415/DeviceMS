using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DeviceMS
{
    public partial class DeviceTypeManage : System.Web.UI.Page
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
            string typeName = this.TypeName.Text;
            if (typeName == "")
            {
                Response.Write("<script>alert('請填寫類別名稱!');</script>");
                return;
            }

            DeviceTypeDAO deviceTypeDAO = new DeviceTypeDAO();
            if (deviceTypeDAO.AddDeviceType(typeName))
                Response.Write("<script>alert('設備類別添加成功！');location.href='DeviceTypeManage.aspx';</script>");
            else
                Response.Write("<script>alert('" + deviceTypeDAO.getErrMessage() + "');location.href='DeviceTypeManage.aspx';</script>");
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;  //GridView编辑项索引等于单击行的索引
            InitDeviceTypeInfo();
        }

        private void InitDeviceTypeInfo()
        {
            DataSet deviceTypeDs = DeviceTypeDAO.QueryAllDeviceType();
            this.GridView1.DataSourceID = null;
            GridView1.DataSource = deviceTypeDs;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标选择某行时变颜色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00ffee';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            /*取得该记录编号*/
            int typeId = Int32.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
            DeviceTypeDAO deviceTypeDAO = new DeviceTypeDAO();
            if (deviceTypeDAO.DeleteDeviceType(typeId))
            {
                Response.Write("<script language=javascript>alert('成功删除类别！');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('" + deviceTypeDAO.getErrMessage() + "');</script>");
            }
            GridView1.EditIndex = -1;
            InitDeviceTypeInfo();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            InitDeviceTypeInfo();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*取得该类别编号和类别名称*/
            int typeId = Int32.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
            string typeName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TypeName")).Text;
            /*调用业务层执行更新操作*/
            DeviceTypeDAO deviceTypeDAO = new DeviceTypeDAO();
            if (deviceTypeDAO.UpdateDeviceType(typeId, typeName))
            {
                Response.Write("<script language=javascript>alert('修改成功!');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('" + deviceTypeDAO.getErrMessage() + "');</script>");
            }
            GridView1.EditIndex = -1;
            InitDeviceTypeInfo();
        }
    }
}