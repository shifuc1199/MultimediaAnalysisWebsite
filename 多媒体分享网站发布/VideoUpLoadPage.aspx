<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoUpLoadPage.aspx.cs" Inherits="多媒体分享网站.VideoUpLoadPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/VideoUpLoadPage.css" type="text/css">
    <link rel="stylesheet" href="css/common.css" type="text/css">
	<link rel="stylesheet" type="text/css" href="/Scripts/uploadify-v3.1/Huploadify.css"/>
<script type="text/javascript" src="/Scripts/uploadify-v3.1/jquery.js"></script>
<script type="text/javascript" src="/Scripts/uploadify-v3.1/jquery.Huploadify.js"></script>
<style type="text/css">
</style>

<script type="text/javascript">
	 
$(function(){
	   var up = $('#upload').Huploadify({
		   auto: false,
		  
		  fileTypeExts: '*.mp4;*.MP4',
		 multi: true,
		fileSizeLimit:99999999999,
		showUploadedPercent:true,
		showUploadedSize:true,
		removeTimeout:9999999,
		uploader:'/Tool/UploadHandler.ashx',
		   onUploadStart: function (file) {
			console.log(file.name+'开始上传');
			},

		onInit: function (obj) {
		 
			console.log('初始化');
			console.log(obj);
		},
		onUploadComplete: function (file) {
			alert("上传成功！");
			window.location.href = "VideoUpLoadPage.aspx";
		},
		onCancel:function(file){
			console.log(file.name+'删除成功');
		},
		onClearQueue:function(queueItemCount){
			console.log('有'+queueItemCount+'个文件被删除了');
		},
		onDestroy:function(){
			console.log('destroyed!');
		},
		onSelect:function(file){
			console.log(file.name+'加入上传队列');
		},
		onQueueComplete:function(queueData){

			console.log('队列中的文件全部上传完成',queueData);
		  }
	});
	$('#upload_button').click(function () {
		  if (document.getElementById("<%=TextBox1.ClientID%>").value == "请输入视频标题") {
             alert("请输入视频标题!");
 return;
		} 	
		var des = document.getElementById('TextBox2').value;

		if (document.getElementById("<%=TextBox2.ClientID%>").value == "请输入视频描述")
			des = "";

	    option.formData = { 'video_title': document.getElementById('TextBox1').value, 'video_des': des, 'user_id': '<%=(Session["user"] as 多媒体分享网站.Model.UserModel).id%>' };
		up.upload('*');
	});
	});
</script>
	 

  
	 

	</head>
<body>

 
		 
    <form id="form1" runat="server"  >
         <div class="wapper">
                    <div class="logo">
                        <div class="shouye"></div>
                         <asp:Button class="returnmain" ID="Button1" runat="server" OnClick="Button1_Click1" Text="主站" />
                    </div>
                     <div class="head" >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Label class="ID"  ID="Label3" runat="server" Text="Label"></asp:Label>
                     <asp:Button class="btn" ID="Button2" runat="server" OnClick="Button2_Click1" Text="投稿管理" />
                     <asp:Button class="btn" ID="Button3" runat="server" OnClick="Button3_Click1" Text="收藏管理" />
                     <asp:Button class="btn" ID="Button4" runat="server" OnClick="Button4_Click1" Text="退出" />
                     </div>	 
			</div>


			 
    <div class="uploaddiv">
        <div class="upload_up">
            <center>
                <br><br><br><br><br><br>
             <div id="upload"></div>
		    <br><br>
		     
            <asp:TextBox class="texta" ID="TextBox1" runat="server" Text="请输入视频标题"
                onfocus='if(this.value=="请输入视频标题"){this.value="";}; '   
            onblur='if(this.value==""){this.value="请输入视频标题";};' Width="300px" ></asp:TextBox>
		    <br>
			<br>
		     
            <asp:TextBox class="texta" ID="TextBox2" runat="server" TextMode="MultiLine" Text="请输入视频描述"
                onfocus='if(this.value=="请输入视频描述"){this.value="";}; '   
            onblur='if(this.value==""){this.value="请输入视频描述";};' Height="100px" Width="300px"></asp:TextBox>
            <br>
			<br>

            <input type="button" id="upload_button" value="上传" class="auto-style6 upload_button">
         
		  
		 </center>
        </div>		 
		 

	<div class="upload_list">
		<asp:Table ID="Table1" runat="server" BorderStyle="Ridge" CaptionAlign="Top" Height="153px" style="margin-bottom: 0px;"  BorderWidth="1px"   Caption="投稿列表" CellPadding="10" CellSpacing="10" GridLines="Both" TabIndex="10" CssClass="auto-style3" Width="100%">
		</asp:Table>
		 	  
	</div>
		 

	</div>
	<div class="footer-container"></div>
    </form>
	  
		
	</body>
	 
</html>
