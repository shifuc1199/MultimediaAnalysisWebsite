<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="多媒体分享网站.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/MainPage.css" type="text/css">
	</head>
<body>
    <div class="bt" style="width:100%;height:100%;">
	<form id="form1" runat="server">
        <div class="wapper">
				<div class="logo">
                    <div class="shouye"></div>
					<asp:Button class="returnmain" ID="Button4" runat="server" OnClick="Button4_Click1" Text="主站"/>
				</div>
	             <div class="head" >
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label class="ID" ID="Label1" runat="server" Text="Label"></asp:Label>
                     <asp:Button class="btn" ID="Button2" runat="server" OnClick="Button2_Click1" Text="投稿管理" />
                     <asp:Button class="btn" ID="Button3" runat="server" OnClick="Button3_Click1" Text="收藏管理" />
                     <asp:Button class="btn" ID="Button1" runat="server" OnClick="Button1_Click1" Text="退出" />
	             </div>	 
			</div>

		 
 <style>
	table	caption{font-size:80px}  
    td{
        border: 1px solid #e5e9ef;
    border-radius: 4px;
    }
	 </style> 
		 
			 <center>
		<asp:Table ID="Table1" runat="server" CaptionAlign="Top" Height="153px" style="margin-top: 99px; margin-bottom: 0px;" Width="1047px" BorderWidth="1px"   Caption="视频列表" CellPadding="0" CellSpacing="10" TabIndex="10" BackColor="White" BorderColor="#757575" ForeColor="Black" BorderStyle="None" Font-Bold="False" Font-Italic="False" Font-Names="华文细黑" Font-Overline="False" Font-Strikeout="False">
		</asp:Table>
		 	 </center>
	</form>
   

    
    </div>
    <footer class="footer-container white-text-container"></footer>
    </body>
</html>
