<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="desk.aspx.cs" Inherits="DeviceMS.desk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
</script>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>關於系統和作者- 桌面</title>
<link href="style.css" rel="stylesheet" type="text/css">
</head>

<body>
<table align=center width="90%" border="0" cellspacing="0" cellpadding="0" height="100%">
      <tr>
        <td>
		      系統功能:<br>
					&nbsp;&nbsp;(1)備品備件：設備類別、名稱 規格型號 價格 設備來源 生產廠家 入庫時間 出庫時間 庫存數量、入庫人、出庫人<br>
	&nbsp&nbsp;&nbsp;(2)在用設備：設備類別、名稱 規格型號 設備來源 生產廠家 使用時間、地點  數量  狀態 <br>
	&nbsp;&nbsp;(3)報廢設備:  設備類別、名稱 規格型號 設備來源  數量<br>
	&nbsp;&nbsp;(4)查詢的時候: />
	&nbsp&nbsp;&nbsp;&nbsp;&nbsp;1、按設備狀態查詢  即 備品備件、在用設備、報廢設備  要能選擇<br />
    &nbsp;&nbsp;&nbsp;&nbsp;2、按收費站查詢 即 光復店、木柵店、和平店、安和店  也得能選擇<br />
    &nbsp;&nbsp;&nbsp;&nbsp;3、按設備類別查詢 即 監控系統 收費系統 通訊系統  要能選擇>
    &nbsp;&nbsp;&nbsp;&nbsp;4、按設備名稱查詢 <br />
    &nbsp;&nbsp;(5)在用設備庫存報警:如果在用設備壽命將盡，備品中又不存在，需要提示！<br />
            系統特點：<br />
            &nbsp; (1)系統採用美化的功能表和GridView控制項<br />
            &nbsp; (2)最優化資料庫設計，解決了資料一致性問題<br />
            &nbsp; (3)程式使用三層架構思想，採用完全物件導向的思想方法設計<Br>
            &nbsp; (4)完美的資訊管理系統範本.<Br>
            <br />
					本系統完成時間: 2017年4月9日
				</td>
      </tr>
    </table>
</body>
</html>