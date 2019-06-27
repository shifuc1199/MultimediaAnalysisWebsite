<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="多媒体分享网站.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/LoginPage.css" type="text/css">
    <title>标题</title>
	
</head>

<body bgcolor="white">
	<div class="out">
		<div class="bg_up"></div>
        <div class="bg_d"></div>
    </div>
    <div class="login">
            <form id="form1" runat="server">
                
                    <a class="auto-style4">多媒体分享网站</a>
                    <br />
                    <br />
                    <br />
		            <div style="position:static;">
                        <div class="yonghu">
                             
                        </div>
                        <asp:TextBox class="input" ID="TextBox1" runat="server" style="margin-left: 8px" Height="25px" 
                            value="请输入用户名"  
            onfocus='if(this.value=="请输入用户名"){this.value="";}; '   
            onblur='if(this.value==""){this.value="请输入用户名";};'></asp:TextBox>
		            </div>
                    <br />
		            <div style="position:static;">
                        <div class="mima">
                             
                        </div>
			            <asp:TextBox class="input" ID="TextBox2" runat="server" style="margin-left: 8px" Height="25px" 
                            value="请输入密码"  
            onfocus='if(this.value=="请输入密码"){this.value="";this.type = "password";}; '   
            onblur='if(this.value==""){this.value="请输入密码";this.type = "text";};'></asp:TextBox>
		            </div>
		            <br />
                    <br />
                    <br />
		            <asp:Button class="btn" ID="Button1" runat="server" Height="29px" OnClick="Button1_Click" style="margin-left: 30px" Text="登录" Width="77px" />
		            <asp:Button class="btn" ID="Button2" runat="server" Height="29px" OnClick="Button2_Click" style="margin-left: 38px" Text="注册" Width="77px" />
               
            </form>
        </div>
</body>

</html>
 