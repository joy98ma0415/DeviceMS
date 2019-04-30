<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UselessDeviceManage.aspx.cs" Inherits="DeviceMS.UselessDeviceManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form method="post" id="frmAnnounce" runat="server">
        <table width="880" border="0" cellpadding="0" cellspacing="0" align="center">
            <tr style="color: blue; font-size: 14px;">
                <td style="height: 14px; width: 600px;">
                    <img src="images/list.gif" width="14px" height="14px">&nbsp;報廢設備資訊管理--&gt;報廢設備資訊</td>
            </tr>
            <tr>
                <td style="width: 600px;" valign="top">&nbsp;設備名稱：<asp:TextBox ID="DeviceName" runat="server" Width="136px"></asp:TextBox>設備類別：<asp:DropDownList ID="TypeId" runat="server">
                </asp:DropDownList>
                    &nbsp;&nbsp;
              <asp:Button ID="Btn_Query" runat="server" OnClick="Btn_Query_Click" Text="查詢" />&nbsp;&nbsp;&nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                  CellPadding="3" CellSpacing="2" DataSourceID="UselessDeviceDataSource" DataKeyNames="id"
                  Width="600px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" PageSize="15">
                  <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                  <Columns>

                      <asp:BoundField DataField="deviceName" HeaderText="設備名稱" SortExpression="deviceName" />
                      <asp:TemplateField HeaderText="設備類型">
                          <ItemTemplate>
                              <asp:Literal ID="TypeName" runat="server"></asp:Literal>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="deviceModel" HeaderText="設備型號" SortExpression="deviceModel" />
                      <asp:BoundField DataField="deviceFrom" HeaderText="設備來源" SortExpression="deviceFrom" />

                      <asp:BoundField DataField="deviceCount" HeaderText="數量" SortExpression="deviceCount" />

                      <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="UselessDeviceDetails.aspx?id={0}"
                          HeaderText="更新" Text="進入" />
                      <asp:TemplateField HeaderText="刪除">
                          <ItemTemplate>
                              <a href='UselessDeviceDel.aspx?id=<%#Eval("id") %>' onclick="return confirm('確定刪除本記錄!');">刪除</a>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
                  <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                  <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                  <PagerStyle ForeColor="#8C4510" HorizontalAlign="Left" />
                  <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
              </asp:GridView>
                    <asp:SqlDataSource ID="UselessDeviceDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DeviceDBConnectionString %>"
                        SelectCommand="SELECT * FROM [t_device_useless]"></asp:SqlDataSource>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            </tr>
        </table>
    </form>
</body>
</html>