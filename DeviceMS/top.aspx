<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="DeviceMS.top" %>

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
        }

        .STYLE1 {
            font-size: 12px;
            color: #FFFFFF;
        }

        .STYLE2 {
            font-size: 9px
        }

        .STYLE3 {
            color: #033d61;
            font-size: 12px;
        }
        -->
    </style>

    <script language="JavaScript">
        function tick() {
            var hours, minutes, seconds;
            var intHours, intMinutes, intSeconds;
            var today;
            today = new Date();
            intYear = today.getFullYear();
            intMonth = today.getMonth() + 1;
            intDay = today.getDate();
            intHours = today.getHours();
            intMinutes = today.getMinutes();
            intSeconds = today.getSeconds();

            if (intHours == 0) {
                hours = "00:";
            } else if (intHours < 10) {
                hours = "0" + intHours + ":";
            } else {
                hours = intHours + ":";
            }

            if (intMinutes < 10) {
                minutes = "0" + intMinutes + ":";
            } else {
                minutes = intMinutes + ":";
            }
            if (intSeconds < 10) {
                seconds = "0" + intSeconds + " ";
            } else {
                seconds = intSeconds + " ";
            }
            timeString = intYear + "��" + intMonth + "��" + intDay + "��" + " " + hours + minutes + seconds;
            Clock.innerHTML = timeString;
            window.setTimeout("tick();", 1000);
        }

        window.onload = tick;
//-->
    </script>
</head>

<body>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="70" background="images/main_05.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="24">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="270" height="24" background="images/main_03.gif">&nbsp;</td>
                                    <td width="505" background="images/main_04.gif">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td width="21">
                                        <img src="images/main_07.gif" width="21" height="24"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="38">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="270" height="38" background="images/main_09.gif">&nbsp;</td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="77%" height="25" valign="bottom">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="50" style="height: 19px">
                                                                <div align="center" style="cursor: hand;" onclick="top.mainFrame.location.href='middel.html';">
                                                                    <img src="images/main_12.gif" width="49" height="19" border="0">
                                                                </div>
                                                            </td>
                                                            <td width="50" style="height: 19px">
                                                                <div align="center" style="cursor: hand;" onclick="top.mainFrame.history.go(-1);">
                                                                    <img src="images/main_14.gif" width="48" height="19">
                                                                </div>
                                                            </td>
                                                            <td width="50" style="height: 19px">
                                                                <div align="center" style="cursor: hand;" onclick="top.mainFrame.history.go(1);">
                                                                    <img src="images/main_16.gif" width="48" height="19">
                                                                </div>
                                                            </td>
                                                            <td width="50" style="height: 19px">
                                                                <div align="center" style="cursor: hand;" onclick="top.mainFrame.location.reload();">
                                                                    <img src="images/main_18.gif" width="48" height="19">
                                                                </div>
                                                            </td>
                                                            <td width="50" style="height: 19px">
                                                                <div align="center" style="cursor: hand;" onclick="if (confirm('��_��Ҫ�˳�ϵ�y�᣿')){top.location.href='logout.aspx';}">
                                                                    <img src="images/main_20.gif" width="48" height="19">
                                                                </div>
                                                            </td>
                                                            <td width="26" style="height: 19px">
                                                                <div align="center">
                                                                    <img src="images/main_21.gif" width="26" height="19">
                                                                </div>
                                                            </td>
                                                            <!--
                    <td width="100" style="height: 19px"><div align="center" style="cursor:hand;" onclick="top.mainFrame.location.href='ChangePassword.aspx';"><img src="images/main_22.gif" width="98" height="19"></div></td>
                    -->
                                                            <td style="height: 19px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="360" valign="bottom" nowrap="nowrap">
                                                    <div align="right"><span class="STYLE1"><span class="STYLE2">��</span>�gӭ��:<font color="blue"><%=Session["username"].ToString() %></font>&nbsp;�F���ǣ�<span id="Clock"></span></span></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="21">
                                        <img src="images/main_11.gif" width="21" height="38"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="8" style="line-height: 8px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="270" background="images/main_29.gif" style="line-height: 8px;">&nbsp;</td>
                                    <td width="505" background="images/main_30.gif" style="line-height: 8px;">&nbsp;</td>
                                    <td style="line-height: 8px;">&nbsp;</td>
                                    <td width="21" style="line-height: 8px;">
                                        <img src="images/main_31.gif" width="21" height="8"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="28" background="images/main_36.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="177" height="28" background="images/main_32.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20%" height="22">&nbsp;</td>
                                    <td width="59%" valign="bottom">
                                        <div align="center" class="STYLE1">��ǰ�Ñ���<%=Session["username"].ToString() %><label id="UserName" runat="server"></label></div>
                                    </td>
                                    <td width="21%">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;&nbsp;</td>
                        <td width="21">
                            <img src="images/main_37.gif" width="21" height="28"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>