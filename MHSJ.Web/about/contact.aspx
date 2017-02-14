<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="MHSJ.Web.about.contact" %>
<%@ Import Namespace="MHSJ.Web" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>梅花书检</title>
<meta name="keywords" content="<%=Keywords %>"/>
<meta name="description" content="<%=Description %>" />

<link rel="stylesheet" type="text/css" href="/common/css/base.css" />
<link rel="stylesheet" type="text/css" href="/common/css/main.css" />
<link href="/common/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/common/scripts/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript" src="/common/scripts/main.js"></script>


<script language="javascript" type="text/javascript" src="/common/scripts/jquery-ui-1.8.20.custom.js"></script>
<link rel="stylesheet" href="/common/css/jquery.ui.autocomplete.css" type="text/css" media="screen"/>
<style type="text/css">
        .ui-menu .ui-menu-item a.ui-state-hover,
        .ui-menu .ui-menu-item a.ui-state-active {
	        background:#60666f;
	        font-weight: normal;
        }
    </style>
</head>
<body>
    <!--头部-->
    <div class="header">
    <ul class="link_ul">
    	<li><a href="/index.aspx" title="梅花书检首页"><img class="logo" src="/common/images/logo.png" alt="梅花书检" /></a></li>
    	<%--<li><a href="#" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('');">设为首页</a>|</li>
        <li><a target="_self" href="javascript:void(0)" onclick="shoucang(document.title,window.location)">收藏本站</a>|</li>
        <li><a href="#">会员登录</a>|</li>
        <li><a href="#">会员注册</a></li>--%>
    </ul>
</div>
<div class="main">
    <div class="con aboutus">
        <h1>
            <em></em>
            联系我们
        </h1> 
        <div>
            <h2>联系我们：</h2>
            <p>联系方式：欢迎致电我们，我们将竭诚为您服务！</p>
            <p>工作时间：周一至周六：早晨：8：00—12：00 下午：14：00—18：00</p>
            <p>QQ：2050991408
                <a href="tencent://message/?uin=2050991408&Site=梅花书检&Menu=yes">
                    <img src="../common/images/qq.gif" alt="在线qq交流"  title="点击这里给我发消息">
                </a>
            </p>
            <p>电 话: 0317一5760612</p>
            <p>邮箱：<a href="mailto:2050991408@qq.com?subject=梅花书检">2050991408@qq.com</a></p>
            <p>技术支持：<a href="mailto:xhito@foxmail.com?subject=梅花书检">xhito@foxmail.com</a></p>
        </div>
    </div>
</div>
<div style="height:20px;"></div>
    
    <div class="bottom">
        <!--友情链接-->
        <div class="link">
            
        </div>

        <!--底部-->
        <div class="footer">
            <p>
                <a href="/about/contact.aspx" target="_blank">联系我们</a>
                <%--<a href="#" target="_blank">关于我们</a>
                <a href="#" target="_blank">网站地图</a>--%>
                <a href="#" target="_blank">友情链接</a>
            </p>
            <p>
                <%=Bottom%> <a href="http://www.miitbeian.gov.cn/">冀ICP备15011226号</a>
            <script type="text/javascript">
                var cnzz_protocol = (("https:" == document.location.protocol) ? " https://" : " http://");
                document.write(unescape("%3Cspan id='cnzz_stat_icon_1254860356'%3E%3C/span%3E%3Cscript src='" + cnzz_protocol + "s4.cnzz.com/z_stat.php%3Fid%3D1254860356%26show%3Dpic' type='text/javascript'%3E%3C/script%3E"));
            </script>
            </p>
            
        </div>
        
    </div>
</body>
