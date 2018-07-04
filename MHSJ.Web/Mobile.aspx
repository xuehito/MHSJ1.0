<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileIndex.aspx.cs" Inherits="MHSJ.Web.MobileIndex" %>

<script src="common/scripts/lanrenjiazai.js" type="text/javascript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>梅花书检</title>
<meta name="keywords" content="<%=Keywords %>"/>
<meta name="description" content="<%=Description %>" />

<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<link href="common/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
<link href="common/css/admin.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="/common/css/mobile.css" />
<link href="common/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript" src="/common/scripts/jquery-1.7.2.min.js"></script>
<script src="common/scripts/bootstrap.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="/common/scripts/main.js"></script>
<script src="common/scripts/lanrenjiazai.js" type="text/javascript"></script>

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

<div class="main">
    <div>
        <form  id="form1" method="get" class="navbar-form" action > 
            <div class="row-fluid">
                <div class="span12 header-logo">
                     <a href="<%=IndexUrl%>" title="梅花书检">
                         <img class="logo" src="/common/images/logo.png" alt="梅花书检" class="logo" />
                     </a>
                </div>
            </div>
            <div class="row-fluid main-center">
                <div class="span12">
                    <input type="text" class="span2" name="keyword" value="<%=Keyword %>" id="main_key"  style="margin:10px 0;min-width: 220px" placeholder="请输入一个汉字（支持繁简）"/>
                    <button type="submit" id="main_so" title="搜索" class="btn btn-danger" style="margin:10px 0">搜索</button>
                </div>
                
                <div class="span12">
                   
                </div>
                </div>
            
          </form>
          <div class="row-fluid main-center">
                <div class="span12 container">
                        <!--文字详情-->
                <%if (!string.IsNullOrEmpty(Xiangqing))
                  {%>
		            <%=Xiangqing%>
	            <%}%>
                <!--文字图片-->
                <%if(!string.IsNullOrEmpty(List)) {%>
		            <%=List %>
	            <%}%>
              </div>
       </div>   
<!--翻页-->
    <%= Pager%>
</div>
<div style="height:20px;"></div>
    
    <div class="bottom">
        
    </div>
    </div>
</body>


</html>
