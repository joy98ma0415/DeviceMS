<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UselessDeviceAdd.aspx.cs" Inherits="DeviceMS.UselessDeviceAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <script src="script/calendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="600" border="0" cellpadding="0" cellspacing="0" align="center">
            <tr style="color: blue; font-size: 14px;">
                <td style="height: 14px; width: 502px;">
                    <img src="images/ADD.gif" width="14px" height="14px">
                    報廢設備資訊管理--&gt;添加報廢設備</td>
            </tr>
            <tr>
                <td style="height: 42px">
                    <br />
                    設備類型：
            <asp:DropDownList ID="TypeId" runat="server" DataSourceID="DeviceTypeDataSource" DataTextField="typeName" DataValueField="typeId">
            </asp:DropDownList><br />
                    <br />
                    設備名稱：
            <asp:TextBox ID="DeviceName" runat="server" Width="208px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DeviceName"
                        ErrorMessage=" 請輸入裝置名稱！"></asp:RequiredFieldValidator><br />
                    <br />
                    設備型號：
            <asp:TextBox ID="DeviceModel" runat="server" Width="208px"></asp:TextBox>
                    &nbsp; &nbsp; &nbsp;<br />
                    <br />
                    設備來源：
            <asp:TextBox ID="DeviceFrom" runat="server" Width="208px"></asp:TextBox>&nbsp; &nbsp;&nbsp;&nbsp;
            <br />
                    <br />
                    數 &nbsp; &nbsp; &nbsp; 量：
            <asp:TextBox ID="DeviceCount" runat="server" Width="92px"></asp:TextBox><br />
                    <br />
                    <asp:Button ID="Btn_Add" runat="server" Text="登記" OnClick="Btn_Add_Click" /></td>
            </tr>
        </table>
        <asp:SqlDataSource ID="DeviceTypeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DeviceDBConnectionString %>" SelectCommand="SELECT [typeId], [typeName] FROM [t_device_type]"></asp:SqlDataSource>
        &nbsp;&nbsp;
    </form>
</body>
</html>