<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DeviceMS.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <style type="text/css">
        <!--
        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #016aa9;
            overflow: hidden;
        }

        .STYLE1 {
            color: #000000;
            font-size: 12px;
        }
        -->
    </style>
</head>

<body>

    <form runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table width="962" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="235" background="images/login_03.gif">&nbsp;</td>
                        </tr>
                        <tr>
                            <td height="53">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="394" height="53" background="images/login_05.gif">&nbsp;</td>
                                        <td width="206" background="images/login_06.gif">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="16%" height="25">
                                                        <div align="right"><span class="STYLE1">�Ñ�</span></div>
                                                    </td>
                                                    <td width="57%" height="25">
                                                        <div align="center">
                                                            <input type="text" name="username" style="width: 105px; height: 17px; background-color: #292929; border: solid 1px #7dbad7; font-size: 12px; color: #6cd0ff" id="Username" value="admin" runat="server">
                                                        </div>
                                                    </td>
                                                    <td width="27%" height="25">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td height="25">
                                                        <div align="right"><span class="STYLE1">�ܴa</span></div>
                                                    </td>
                                                    <td height="25">
                                                        <div align="center">
                                                            <input type="password" name="password" style="width: 105px; height: 17px; background-color: #292929; border: solid 1px #7dbad7; font-size: 12px; color: #6cd0ff" id="Password" value="admin" runat="server">
                                                        </div>
                                                    </td>
                                                    <td height="25">
                                                        <div align="left">
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/dl.gif" OnClick="ImageButton1_Click" /><a href="main.html"></a>&nbsp;
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="362" background="images/login_07.gif">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="213" background="images/login_08.gif">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>