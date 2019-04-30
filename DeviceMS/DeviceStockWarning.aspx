<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceStockWarning.aspx.cs" Inherits="DeviceMS.DeviceStockWarning" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="600" border="0" cellpadding="0" cellspacing="0" align="center">
            <tr style="color: blue; font-size: 14px;">
                <td style="height: 14px; width: 502px;">
                    <img src="images/ADD.gif" width="14px" height="14px">
                    系統管理--&gt;備用設備庫存報警</td>
            </tr>
            <tr>
                <td>功能介紹:<br>
                    &nbsp;&nbsp;系統根據在用設備的使用時間和使用壽命判斷壽命即將到期的在用設備，然後查詢備用設備資訊，如果備用設備資訊中不存在該設備，則提示該設備需要購買了，設備庫存報警天數設置在DB/Constant.cs文件，默認30天。<br />
                    <br />
                    <font color="red">當前需要購買的設備清單：</font>
                    <br />
                    <asp:Literal ID="Devices" runat="server"></asp:Literal></td>
            </tr>
        </table>
        &nbsp;
         &nbsp;&nbsp;
    </form>
</body>
</html>