<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="多媒体分享网站.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/RegisterPage.css" type="text/css">
	   


</head>
 
<body>
    <div class="out">
		<div class="bg_up"></div>
        <div class="bg_d"></div>
    </div>
    <div class="register">
        <form id="form1" runat="server">
            <center>
                <a class="auto-style4">注册</a>
                 <br />
                <br />
                <div style="position:static;">
                    <div class="yonghu">
                             
                        </div>
                <asp:TextBox class="textbox" ID="TextBox1" runat="server" Height="25px" Width="190px" 
                    value="请输入用户名"  
                    onfocus='if(this.value=="请输入用户名"){this.value="";}; '   
                    onblur='if(this.value==""){this.value="请输入用户名";};'></asp:TextBox>
                </div>
                 <br />
                <div style="position:static;">
                    <div class="mima">
                             
                        </div>
                    <asp:TextBox class="textbox" ID="TextBox2" runat="server" Height="25px" Width="190px" 
                        value="请输入密码"  
                    onfocus='if(this.value=="请输入密码"){this.value="";this.type = "password";}; '   
                    onblur='if(this.value==""){this.value="请输入密码";this.type = "text";};'></asp:TextBox>
                </div>
                 <br />
                <div style="position:static;">
                    <div class="yonghu">
                             
                        </div>
                    <asp:TextBox class="textbox" ID="TextBox3" runat="server" Height="25px" Width="190px"
                        value="请输入姓名"  
                    onfocus='if(this.value=="请输入姓名"){this.value="";}; '   
                    onblur='if(this.value==""){this.value="请输入姓名";};'></asp:TextBox>
                </div>
                 <br />
                <asp:Button class="btn" ID="Button1" runat="server"  OnClick="Button1_Click" Text="注册" Height="29px"  Width="77px" style="margin-left: 30px"/>
                <asp:Button class="btn" ID="Button2" runat="server"  OnClick="Button2_Click" Text="返回" Height="29px"  Width="77px" style="margin-left: 30px"/>
            </center>
        </form>
    </div>
</body>
        

	 
</html>
