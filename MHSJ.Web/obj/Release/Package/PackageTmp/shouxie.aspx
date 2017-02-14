<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shouxie.aspx.cs" Inherits="MHSJ.Web.shouxie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title></title>
    
    <style type="text/css">
       #kw_text{ border: 1px #ccc solid;}
    </style>
    

    <script src="common/scripts/ybz.min.js" type="text/javascript"></script>
    <%--<script src="http://www.yibizi.com/ybz_core/core/ybz.min.js"></script>--%>
    <link href="common/css/ybz.css" rel="stylesheet" type="text/css" />
<!--引入易笔字核心脚本(utf-8编码)-->
<script>
    YBZ_win_title = "梅花书检"; //手写板名称
    YBZ_follow = true; //手写板吸附在输入框附近 false 右下角打开
    YBZ_skin = "default";
    //default||aero||chrome||opera||simple||idialog||twitter||blue||black||green
    YBZ_tipsopen = true; //是否在网页输入框中加入手写提示
    YBZ_fixed = true; //是否固定手写窗口
</script> 

</head>
<body>
    <form name="f" action="s">
        <br>
        <br>
        <br>
        <br>
        <br><br>
        <div><input type="text" name="wd" id="kw" maxlength="100"/>
        <input type="button" id="kw_text" onclick="javascript:YBZ_open();YBZ_tips.hidden();"/>手写</div>
        <input type="submit" value="搜索" id="su"/>
	    
        <br/>
         <br/>
          <br/> <br/>
        <input type="text"  id="Text1" maxlength="100"/>
    </form>
</body>
<script type="text/javascript">
    //YBZ_open(document.getElementById('kw'));

</script>
</html>
