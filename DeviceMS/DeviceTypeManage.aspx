<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceTypeManage.aspx.cs" Inherits="DeviceMS.DeviceTypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form method="post" id="frmAnnounce" runat="server">
      <table width=880 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px; width: 600px;">
          <img src="images/list.gif" width=14px height=14px>&nbsp;設備類別資訊管理--&gt;設備類別資訊</td>
        </tr>
        <tr>
        <td style="width: 600px; height: 212px;"　valign=top>
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                CellPadding="3" CellSpacing="2" DataSourceID="DeviceTypeDataSource" DataKeyNames="typeId"
                Width="500px"  OnRowDataBound="GridView1_RowDataBound" PageSize="8"
                 OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <Columns>

                     <asp:BoundField DataField="typeId" HeaderText="類別編號" ReadOnly=True SortExpression="typeId" />
                      <asp:TemplateField HeaderText="類別名稱">
                         <EditItemTemplate>
                             <asp:TextBox ID="TypeName" runat="server" Text='<%# Eval("typeName") %>' Width="80"></asp:TextBox>
                         </EditItemTemplate>
                          <ItemTemplate>
                             <asp:Label ID="Label2" runat="server"><%# Eval("typeName") %></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>

                  <asp:CommandField HeaderText="編輯" EditText="修改" UpdateText="更新" ShowEditButton="True" />
                      <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                         <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('確認要刪除嗎？');"
                                        Text="刪除"></asp:LinkButton>
                         </ItemTemplate>
                      </asp:TemplateField>
                </Columns>
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Left" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            &nbsp;<br />
            添加設備類別：
            <asp:TextBox ID="TypeName" runat="server"></asp:TextBox>
            &nbsp; &nbsp;<asp:Button ID="Btn_Add" runat="server" OnClick="Btn_Add_Click" Text="添加" />
            &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;&nbsp;
        </tr>
      </table>
             <asp:SqlDataSource ID="DeviceTypeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DeviceDBConnectionString %>"
                  SelectCommand="SELECT * FROM [t_device_type]">
              </asp:SqlDataSource>
    </form>
</body>
</html>