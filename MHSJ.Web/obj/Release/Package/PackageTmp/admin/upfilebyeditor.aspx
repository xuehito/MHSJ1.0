<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upfilebyeditor.aspx.cs" Inherits="MHSJ.Web.admin.admin_upfilebyeditor" %>
<%@ Register src="UserControls/upfilemanager.ascx" tagname="upfilemanager" tagprefix="uc1" %>

<script src="../common/scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../common/scripts/lanrenjiazai.js" type="text/javascript"></script>
<script src="../common/scripts/jquery.scrollstop.js" type="text/javascript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="../common/css/admin.css" />
    <style type="text/css">
        #content { margin :0px; border:0px;} 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">   
        <uc1:upfilemanager ID="upfilemanager1" runat="server" />
        <div style="clear:both;"></div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function lazyload(option) {
        var settings = {
            defObj: null,
            defHeight: 0
        };
        settings = $.extend(settings, option || {});
        var defHeight = settings.defHeight, defObj = (typeof settings.defObj == "object") ? settings.defObj.find("img") : $(settings.defObj).find("img");
        var pageTop = function () {
            return document.documentElement.clientHeight + Math.max(document.documentElement.scrollTop, document.body.scrollTop) - settings.defHeight;
        };
        var imgLoad = function () {
            defObj.each(function () {
                if ($(this).offset().top <= pageTop()) {
                    var src2 = $(this).attr("src2");
                    if (src2) {
                        $(this).attr("src", src2).removeAttr("src2");
                    }
                }
            });
        };
        imgLoad();

        // 绑定滚动事件 
        $(window).bind("scroll", function () {
            imgLoad();
        });
    }

    lazyload({
        defObj: "#plist"
    }) 
</script>
