<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="DeviceMS.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>無封面頁</title>
      <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <table width="80%" border="0" cellpadding="0" cellspacing="2" align="center">
<tr>
    <td height="21" bgcolor="magenta">&nbsp;<img src="images/edit.gif" width="32" height="32" hspace="2" vspace="2" align="absmiddle"><font size="+1"><strong>系統安全密碼設置</strong></font></td>
  </tr>
</table>
<table width="80%" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td>
	  <table width="100%" border="0" cellspacing="1" cellpadding="2" align="center" class="TableMenu">

      <tr>
        <td  class="a3">重新設置密碼</td>
		    <td>
                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="144px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NewPassword"
                    ErrorMessage="密碼輸入不能為空！"></asp:RequiredFieldValidator>&nbsp;&nbsp;
				</td>
      </tr>
		  <tr>
		    <td style="height: 31px">再次確認新密碼:</td>
			  <td style="height: 31px">
                  <asp:TextBox ID="NewPassAgain" runat="server" TextMode="Password" Width="145px"></asp:TextBox>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword"
                      ControlToValidate="NewPassAgain" ErrorMessage="兩次密碼輸入不一致！"></asp:CompareValidator></td>
			</tr>
      <tr bgcolor="#ffffff">
        <td height="30" colspan="4" align="center">
            &nbsp;<asp:Button ID="Btn_ChangePassword" runat="server" OnClick="Btn_ChangePassword_Click"
                Text="修改密碼" />
            <br />
            <asp:Literal ID="ErrMessage" runat="server"></asp:Literal></td>
      </tr>
	  </table>
	</td>
  </tr>
</table>
    </form>
</body>
</html>