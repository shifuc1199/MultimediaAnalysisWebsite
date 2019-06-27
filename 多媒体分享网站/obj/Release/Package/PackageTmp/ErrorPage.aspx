<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="多媒体分享网站.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
	 
<body>
	<style type="text/css">

		.auto-style1 {
			  
			
			 
			 font-size:80px;
			
		}
		 
		.auto-style2 {
			height: 242px;
		}
		 
	</style>
    <form id="form1" runat="server">
		<div align="right" class="auto-style2">
			<asp:Button ID="Button1" runat="server" Text="主菜单" Width="99px" Height="29px" OnClick="Button1_Click" />
			</div>
       
       <center>
    	<asp:Label ID="Label1" runat="server" Text="您的稿件正在审核！" CssClass="auto-style1" ></asp:Label>
 </center>
		 
    	 
    </form>
</body>
</html>
