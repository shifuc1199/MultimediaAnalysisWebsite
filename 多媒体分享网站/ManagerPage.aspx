<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerPage.aspx.cs" Inherits="多媒体分享网站.ManagerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/common.css" type="text/css">
    <title></title>
	 
</head>
<body>
    <form id="form1" runat="server">
        <div class="wapper">
				<div class="logo">
                    <div class="shouye"></div>
					<asp:Button class="returnmain" ID="Button2" runat="server"  Text="主站" />
				</div>
	             <div class="head" >
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label class="ID" ID="Label6" runat="server" Text="Label"></asp:Label>
                     <asp:Button class="btn" ID="Button1" runat="server" OnClick="Button1_Click" Text="退出" />
	             </div>	 
			</div>

        <div>
			 <style>
	table	caption{font-size:40px}  
	 </style> 
			 <center>
		<asp:Table ID="Table1" runat="server" BorderStyle="Ridge" CaptionAlign="Top" Height="153px" style="margin-top: 99px; margin-bottom: 0px;" Width="935px" BorderWidth="5px"   Caption="视频列表" CellPadding="10" CellSpacing="10" GridLines="Both" TabIndex="10">
		</asp:Table>
		 	  
		 	 </center>
        </div>
    </form>
    <footer class="footer-container white-text-container"></footer>
</body>
</html>
