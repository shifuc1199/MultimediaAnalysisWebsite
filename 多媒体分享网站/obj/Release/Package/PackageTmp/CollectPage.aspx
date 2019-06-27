<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CollectPage.aspx.cs" Inherits="多媒体分享网站.CollectPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/common.css" type="text/css">
    <link rel="stylesheet" href="css/CollectPage.css" type="text/css">
    <title></title>
</head>
    
<body>;
    <form id="form1" class="bt" runat="server">
       	 <div class="wapper" >
				<div class="logo">
                    <div class="shouye"></div>
					<asp:Button class="returnmain" ID="mainpage" runat="server" OnClick="Mainpage" Text="主站" />
				</div>
	             <div class="head" >
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label class="ID" ID="Label1" runat="server" Text="Label"></asp:Label>
                     <asp:Button class="btn" ID="tougao" runat="server" OnClick="Tougao" Text="投稿管理" />
                     <asp:Button class="btn" ID="shoucang" runat="server" OnClick="Shoucang" Text="收藏管理" />
                     <asp:Button class="btn" ID="tuichu" runat="server" OnClick="Tuichu" Text="退出" />
	             </div>	 
			</div>
        <div>

			 <style>
	table	caption{font-size:80px} 
    
        
	 </style> 
			 <center>
                
                 
		<asp:Table ID="Table1" runat="server" CaptionAlign="Top" Height="153px" style="margin-top: 99px; margin-bottom: 0px;" Width="70%" BorderWidth="1px"   Caption="收藏列表" CellPadding="10" CellSpacing="10" GridLines="Both" TabIndex="10" Font-Names="华文细黑">
		</asp:Table>
		 	    <br />
                 <br />
                 <br />
                 <br /><br />
                 <br /><br />
                 <br />
                 <br />
                 <br /><br />
                 <br /><br />
                 <br />
                 <br />
                 <br /><br />
                 <br /><br />
                 <br />
                 <br />
                 <br /><br />
                 <br />
		 	 </center>
        </div>
        <footer class="footer-container white-text-container" ></footer>
    </form>
    
     
</body>
</html>
