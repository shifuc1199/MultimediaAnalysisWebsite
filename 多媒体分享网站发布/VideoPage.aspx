<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoPage.aspx.cs" Inherits="多媒体分享网站.VideoPage" %>
<%@ import Namespace="多媒体分享网站.Model" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

	<link rel="stylesheet" href="css/common.css" type="text/css">
	<link rel="stylesheet" href="css/VideoPage.css" type="text/css">
	<link rel="stylesheet" href="css/iconfont.css" type="text/css">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	
</head>
	 <script>
         
	 </script>
<body>

    <center>
    <form id="form1" runat="server">
        <div class="wapper">
                    <div class="logo">
                        <div class="shouye"></div>
                         <asp:Button class="returnmain" ID="Button1" runat="server" OnClick="Button1_Click1" Text="主站" />
                    </div>
                     <div class="head" >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Label class="ID"  ID="Label6" runat="server" Text="Label"></asp:Label>
                         <asp:Button class="btn" ID="return1" runat="server" OnClick="Button6_Click1" Text="返回主页" />
                     <asp:Button class="btn" ID="tougao" runat="server" OnClick="Button2_Click1" Text="投稿管理" />
                     <asp:Button class="btn" ID="shoucang" runat="server" OnClick="Button3_Click1" Text="收藏管理" />
                     <asp:Button class="btn" ID="exit" runat="server" OnClick="Button4_Click1" Text="退出" />
                     </div>	 
			</div>
		 
        <div class="auto-style1" >
        	<asp:Label ID="Label1" runat="server" Text="标题"></asp:Label>
            <video width="800" height="600"  controls="controls"  >
                <source src="" id="play_video" type="video/mp4"/>
            </video>
        </div>

        <div class="style2">
            <asp:Label ID="Label2" runat="server" Text="描述"></asp:Label>
        </div>
        
        <div class="style">
            <span class="click">
                
                <asp:Button ID="Button2" runat="server" OnClick="Yes_Click" class="iconbtn iconfont icon-dianzan" Text="&#xe627;" ForeColor="#757575"/>
                
                <asp:Label ID="Label3" runat="server" Text="赞:0" CssClass="auto-style4"></asp:Label>
			</span>
			<span class="click">
                <asp:Button ID="Button3" runat="server" OnClick="Collect_Click" class="iconbtn iconfont icon-collection-b" Text="&#xe60d;" ForeColor="#757575"/>
				<asp:Label ID="Label4" runat="server" Text="收藏:0" CssClass="auto-style4"></asp:Label>
			</span>
			<span class="click">
                <asp:Button ID="Button4" runat="server" OnClick="No_Click" class="iconbtn iconfont icon-dianzan icon-cai" Text="&#xe627;" ForeColor="#757575"/>
				<asp:Label ID="Label5" runat="server" Text="踩:0" CssClass="auto-style4"></asp:Label>
			</span>
            
			<br>
            <br />
            
            <div class="comment">
                <asp:TextBox class="commentarea" ID="TextBox1" runat="server" TextMode="MultiLine" Text="请输入评论"
                onfocus='if(this.value=="请输入评论"){this.value="";}; '   
            onblur='if(this.value==""){this.value="请输入评论";};'></asp:TextBox>
                <asp:Button class="upcomment" ID="Button5" runat="server" Text="提交" OnClick="Button5_Click" />
            </div>
            <br> <br> 
            <asp:Table ID="Table1" runat="server" Height="114px" Width="793px" CssClass="auto-style6">

            </asp:Table>

        </div>

    	 
    	 </center>
    <script>
        var video_id = '<%=(Session["video"] as VideoModel).video_id%>';
        document.getElementById("play_video").src = "/Video/" + video_id;

    </script>
	 
    	  
    </form>

	</body>
	    
</html>
