<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MHSJ.Web.index" %>
<%@ Import Namespace="MHSJ.Web" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>梅花书检-专业为书法爱好者提供书法在线查询的平台</title>
<meta name="keywords" content="<%=Keywords %>"/>
<meta name="description" content="<%=Description %>" />

<link rel="stylesheet" type="text/css" href="/common/css/base.css" />
<link href="common/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    
<link rel="stylesheet" type="text/css" href="/common/css/main.css" />
<link href="common/css/slider.css" rel="stylesheet" type="text/css" />
<%--<link href="common/css/checkBo.min.css" rel="stylesheet" type="text/css" />--%>
<link rel="stylesheet" href="/common/css/jquery.ui.autocomplete.css" type="text/css" media="screen"/>
<script language="javascript" type="text/javascript" src="/common/scripts/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript" src="/common/scripts/main.js"></script>
<script src="common/scripts/lanrenjiazai.js" type="text/javascript"></script>
<script src="common/scripts/jquery.toaster.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="/common/scripts/jquery-ui-1.8.20.custom.js"></script>
<%--<script src="common/scripts/checkBo.min.js" type="text/javascript"></script>--%>
<script src="common/scripts/ybz.min.js" type="text/javascript"></script>
<%--<script src="http://www.yibizi.com/ybz_core/core/ybz.min.js"></script>--%>
<link href="common/css/ybz.css" rel="stylesheet" type="text/css" />
<%--<script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1256417827"></script>--%>
<style type="text/css">
    .ui-menu .ui-menu-item a.ui-state-hover,
    .ui-menu .ui-menu-item a.ui-state-active {
	    background:#60666f;
	    font-weight: normal;
    }
    input::-ms-clear, input::-ms-reveal{display: none;}
        
    .wrapper{ width:350px; height:220px; margin:-460px 900px; overflow:hidden; position:relative; }
    .iframe { width:1024px;height:768px; position:absolute; top:-300px; left:-300px; }
</style>
 
<!--引入易笔字核心脚本(utf-8编码)-->
<script type="text/javascript">
    YBZ_win_title = "梅花书检手写板"; //手写板名称
    YBZ_follow = true; //手写板吸附在输入框附近 false 右下角打开
    YBZ_skin = "default";
    //default||aero||chrome||opera||simple||idialog||twitter||blue||black||green
    YBZ_tipsopen = true; //是否在网页输入框中加入手写提示
    YBZ_fixed = true; //是否固定手写窗口
</script> 

    <!-- 请置于所有广告位代码之前 -->
<script type="text/javascript" src="http://cbjs.baidu.com/js/m.js"></script>
</head>
<body>
    <!-- 广告位：边侧广告 -->
<script type="text/javascript">BAIDU_CLB_fillSlot("1168834");</script>

    <!--头部-->
    <div class="header" >
    <ul class="link_nav link_ul">
        <li><a href="/index.aspx">首页</a></li>
       <%-- <li><a href="#">梅花消息</a></li>
        <li><a href="#">梅花鉴赏</a></li>--%>
    </ul>
        <%if(PageUtils.IsAccountLogin) %>
    <%{%>
        <ul class="link_user link_ul">
    	    <%--<li><a href="#" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('');">设为首页</a>|</li>
            <li><a target="_self" href="javascript:void(0)" onclick="shoucang(document.title,window.location)">收藏本站</a>|</li>
            <li><a href="/Account/Login">登录</a></li>
            <li><a href="#">注册</a></li>--%>

             <li class="bl"><a href="/mycenter/collections" title="我的收藏">我的收藏</a></li>
             <li class="bl"><a href="/mycenter/integral" title="查看积分">积分</a>：<%= Integral%></li>
             <li><a href="/mycenter" title="管理"><%=PageUtils.CurrentAccount.Name %></a></li>
             <li><a href="/Account/Logout">退出</a></li>
        </ul>
       <% }%>
         <%else
          {%>
        
             <ul class="link_user link_ul">
                 <li><a href="/Account/Login">登录</a></li>
                 <li><a href="/Account/Register">注册</a></li>
             </ul>
        <% }%>
</div>
    <!--搜索-->
  <div class="main">
     
      
           
  <form  id="form1" method="get" name="f" action >
     <input style="display: none" type="text" name="querytype" id="QueryType"/>

	<div style="padding-top: 30px;">
     <div class="header-logo">
          <a href="index.aspx" title="梅花书检首页" style="display:block; max-width:260px; height:70px;">
              <img class="logo" src="/common/images/logo.png" alt="梅花书检" />
          </a>
      </div>

        <div class="sousuo">
	        <div class="tabbable">
	            <ul class="nav nav-tabs" style="border-bottom: 0px;">
                <li class="dz active"><a href="#" data-toggle="tab">单字查询</a></li>
                <li class="bs"><a href="#" data-toggle="tab">部首查询</a></li>
              </ul>
          </div>
          <div style="margin-top: -20px;">
            <div class="kuan" >
                <div>
                    <input type="text" name="keyword" value="<%=Keyword %>" id="main_key" placeholder="请输入一个汉字（支持繁简）"/>
                </div>
                <div>
                    <a href="javascript:;"><span  id="kw_text" onclick="javascript:YBZ_open();YBZ_tips.hidden();" style="float:left;margin: 13px -40px;color:#60666f;width: 40px;">手写</span></a>
                </div>
                <button type="submit"class="btn btn-danger" id="main_so" title="搜索">搜索</button>
            </div><!--单字搜索框-->
          </div>
        </div>
    
     </div>

     <div>
    <ul class="ziti">
    	<li><label class="sb">楷书：</label>
    	    <label class="qb"><input id="checkAllfr1" type="checkbox" name="fr1[]" value ="0"/>全部</label> 
    	    <label><input type="checkbox" name="fr1[]" value ="1"/>大楷</label> 
    	    <label><input type="checkbox" name="fr1[]" value ="2"/>小楷</label> 
    	    <label><input type="checkbox" name="fr1[]" value ="5"/>行楷</label> 
    	    <label><input type="checkbox" name="fr1[]" value ="3"/>魏碑</label> 
    	    <label><input type="checkbox" name="fr1[]" value ="4"/>其他</label> 
		</li>
        <li><label class="sb">行书：</label>
            <label class="qb"><input type="checkbox" name="fr2[]" value ="6"/>全部</label> 
        </li>
        <li><label class="sb">草书：</label>
        	<label class="qb"><input  id="checkAllfr3" type="checkbox" name="fr3[]" value ="0"/>全部</label> 
			<label><input type="checkbox" name="fr3[]" value ="7"/>大草</label> 
            <label><input type="checkbox" name="fr3[]" value ="8"/>小草</label> 
            <label><input type="checkbox" name="fr3[]" value ="9"/>章草</label> 
		</li>
        <li><label class="sb">隶书：</label>
        	<label class="qb"><input id="checkAllfr4" type="checkbox" name="fr4[]" value ="0"/>全部</label> 
			<label><input type="checkbox" name="fr4[]" value ="10"/>汉隶</label> 
            <label><input type="checkbox" name="fr4[]" value ="11"/>简牍</label> 
            <label><input type="checkbox" name="fr4[]" value ="12"/>摩崖</label> 
            <%--<label><input type="checkbox" name="fr4[]" value ="13"/>明清</label>--%> 
            <label><input type="checkbox" name="fr4[]" value ="28"/>其他</label> 
		</li>
        <li><p class=""><%--class="zhuan"--%>
        	<label class="sb">篆书：</label>
          <%--  <label class="zheng"><input type="radio" name="direction1" value="1" checked="checked"/>正</label>  
            <label class="fan"><input type="radio" name="direction1" value="2"/>反</label> --%>
        	<label class="qb"><input id="checkAllfr5" type="checkbox" name="fr5[]" value ="0"/>全部</label> 
			<label><input type="checkbox" name="fr5[]" value ="14"/>大篆</label> 
            <label><input type="checkbox" name="fr5[]" value ="15"/>小篆</label> 
            <label><input type="checkbox" name="fr5[]" value ="16"/>甲骨</label> 
            <label><input type="checkbox" name="fr5[]" value ="17"/>中山</label> 
            <%--<label><input type="checkbox" name="fr5[]" value ="18"/>汉篆</label> --%>
            <%--<label><input type="checkbox" name="fr5[]" value ="19"/>端瓦</label>--%> 
            <label><input type="checkbox" name="fr5[]" value ="20"/>简帛</label> 
            <%--<label><input type="checkbox" name="fr5[]" value ="27"/>钱币</label> --%>
            <label><input type="checkbox" name="fr5[]" value ="29"/>其他</label> 
		</p></li>
        <li><p class="">
        	<label class="sb">篆刻：</label>
          <%--  <label class="zheng"><input type="radio" name="direction2" value="3" checked="checked"/>正</label>  
            <label class="fan"><input type="radio" name="direction2" value="4"/>反</label> --%>
        	<label class="qb"><input id="checkAllfr6" type="checkbox" name="fr6[]" value ="0"/>全部</label> 
            <label><input type="checkbox" name="fr6[]" value ="21"/>秦汉</label> 
            <label><input type="checkbox" name="fr6[]" value ="22"/>流派</label> 
            <label><input type="checkbox" name="fr6[]" value ="23"/>鸟虫</label> 
            <%--<label><input type="checkbox" name="fr6[]" value ="24"/>圆朱</label> 
            <label><input type="checkbox" name="fr6[]" value ="25"/>玉篆</label> --%>
            <label><input type="checkbox" name="fr6[]" value ="26"/>叠篆</label> 
            <label><input type="checkbox" name="fr5[]" value ="30"/>其他</label> 
		</p></li>
    </ul>
    </div>
    <!--作者-->
    <div class="zz">
        <div style="float: left">
    	<p >作者：
        <span id="pcont1"><input name="writer" class="txtWriter" type="text"  value="" data-provide="typeahead" placeholder="请输入作者" /></span>
            <a class="jiaWriter" href="javascript:void(0)" title="增加"><img src="common/images/jiabtn.png" alt=""/></a>
            <a class="jianWriter" href="javascript:void(0)" title="减少"><img src="common/images/jianbtn.png" /></a>
        </p>
        <p>出处：
        <span id="pcont2"><input name="from" type="text" class="txtFrom" value="" title="this.text" placeholder="请输入出处" /></span>
        <a class="jiaFrom" href="javascript:void(0)"  title="增加"><img src="common/images/jiabtn.png" /></a>
        <a class="jianFrom" href="javascript:void(0)" title="减少"><img src="common/images/jianbtn.png" /></a>
        </p>
        </div>

        <div style="float: right;display: none">
             <label>
                <span>
                    拼音：<span class="xianshi"><span style="width: 100px"><%=Pinyin%></span></span>
                </span>
            </label>
            <br/>
            <label>
                <span>简体：<span class="xianshi"><%=Jianti%></span></span>
                <span>通假：<span class="xianshi"><%=Tongjia%></span></span>
                <span>繁体：<span class="xianshi"><%=Fanti%></span></span>
                <span>异体：<span class="xianshi"><%=Yiti%></span></span>
            </label>
            <br/>
             <label>
        </label>
        </div>
        
        
        <!-- 轮播广告 -->
   <%-- <div id="banner_tabs" class="flexslider" style="float: right;">
	    <ul class="slides">
		    <li>
			    <a title="" target="_blank" href="#">
				    <img width="1920" height="482" alt="" style="background: url(common/images/banner1.jpg) no-repeat center;" src="common/images/alpha.png">
			    </a>
		    </li>
		    <li>
			    <a title="" href="#">
				    <img width="1920" height="482" alt="" style="background: url(common/images/banner2.jpg) no-repeat center;" src="common/images/alpha.png">
			    </a>
		    </li>
		    <li>
			    <a title="" href="#">
				    <img width="1920" height="482" alt="" style="background: url(common/images/banner3.jpg) no-repeat center;" src="common/images/alpha.png">
			    </a>
		    </li>
	    </ul>
	    <ul class="flex-direction-nav">
		    <li><a class="flex-prev" href="javascript:;"></a></li>
		    <li><a class="flex-next" href="javascript:;"></a></li>
	    </ul>
	    <ol id="bannerCtrl" class="flex-control-nav flex-control-paging">
		    <li><a>1</a></li>
		    <li><a>2</a></li>
		    <li><a>3</a></li>
	    </ol>
    </div>
--%>
    </div>

    
    </form>

    <div style="margin: 10px 30px;">
        <a href="#"><img src="common/images/tg/170508.png" /></a>
    </div>
    

    <!--翻页-->
    <%= Pager%>

    <!--文字详情-->
    <%--<%if (!string.IsNullOrEmpty(Xiangqing))
      {%>
		<%=Xiangqing%>
	<%}%>--%>
    <!--文字图片-->
    <%if(!string.IsNullOrEmpty(List)) {%>
		<%=List %>
	<%}%>
	
    <div class="albig" id="albig">
        <p class="guanbi">
            <img src="~/common/images/guanb.png" />
        </p>
        <img id="dagImg" src=""  draggable="false"/>
    </div>
    <div class="nimei"></div>
<!--翻页-->
    <%= Pager%>
</div>
<div style="height:20px;"></div>
<%--    
<div class="banner">
     <iframe id="fm-rotate-ad" src="lunbo.aspx" width="1004" height="110" frameborder="0" scrolling="no" data-campaign-start="" data-campaign-end=""></iframe>
 </div>--%>

<div class="bottom">
        <!--友情链接-->
        <div class="link">
            <p>友情链接</p>
            <div class="linkCon">
                <%=QueryLink() %>
			    <%-- <ul>
			         <li><a target="_blank" href="http://www.mhsj.top">梅花书检</a></li>
                 </ul>--%>
            </div>
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
    
    
    
<%--<div class="wrapper"> 
    <iframe class="iframe"  src="lunbo.aspx" width="100%" height="100%"  frameborder="no"  height:auto border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
    </iframe>
 </div> --%>

</body>


<script type="text/javascript">
    $(function () {
        //$('ANY').checkBo();

        var writers = "<%=Writers %>";
        var queryType = "<%=QueryType %>";
        var froms = "<%=Froms %>";
        var direction = "<%=Direction %>";
        var fr1 = "<%=Fr1 %>";
        var fr2 = "<%=Fr2 %>";
        var fr3 = "<%=Fr3 %>";
        var fr4 = "<%=Fr4 %>";
        var fr5 = "<%=Fr5 %>";
        var fr6 = "<%=Fr6 %>";
        var coun;
        if (fr1 != "") {
            coun=fr1.split(',');
            $.each($("input[name='fr1[]']"), function () {
                for(var i=0;i<coun.length;i++){
                    if(coun[i] == $(this).val()) $(this).attr("checked", "true") ;
                }
            });
        };
        if (fr2 != "") {
            coun = fr2.split(',');
            $.each($("input[name='fr2[]']"), function () {
                for (var i = 0; i < coun.length; i++) {
                    if (coun[i] == $(this).val()) $(this).attr("checked", "true");
                }
            });
        };
        if (fr3 != "") {
            coun = fr3.split(',');
            $.each($("input[name='fr3[]']"), function () {
                for (var i = 0; i < coun.length; i++) {
                    if (coun[i] == $(this).val()) $(this).attr("checked", "true");
                }
            });
        };

        if (fr4 != "") {
            coun = fr4.split(',');
            $.each($("input[name='fr4[]']"), function () {
                for (var i = 0; i < coun.length; i++) {
                    if (coun[i] == $(this).val()) $(this).attr("checked", "true");
                }
            });
        };
        if (fr5 != "") {
            coun = fr5.split(',');
            $.each($("input[name='fr5[]']"), function () {
                for (var i = 0; i < coun.length; i++) {
                    if (coun[i] == $(this).val()) $(this).attr("checked", "true");
                }
            });
        };
        if (fr6 != "") {
            coun = fr6.split(',');
            $.each($("input[name='fr6[]']"), function () {
                for (var i = 0; i < coun.length; i++) {
                    if (coun[i] == $(this).val()) $(this).attr("checked", "true");
                }
            });
        };
        if (direction != "") {
            var directs = direction.split(',');

            var dire1=$("input[name='direction1']");
            for (var i = 0; i < dire1.length; i++) {
                for (var j = 0; j < directs.length; j++) {
                    if (directs[j] == dire1[i].value) {
                        dire1[i].checked = true;
                    }
                }
            }

            var dire2 = $("input[name='direction2']");
            for (var i = 0; i < dire2.length; i++) {
                for (var j = 0; j < directs.length; j++) {
                    if (directs[j] == dire2[i].value) {
                        dire2[i].checked = true;
                    }
                }
            }
        };
        
        if (writers != "") {
            coun = writers.split(',');
            if (coun.length == 1) {
                $('.txtWriter')[0].value = coun[0];
            } else if (coun.length>1) {
                $('.txtWriter')[0].value = coun[0];
                for (var i = 1; i < coun.length; i++) {
                    $('#pcont1').append('<input name="writer" type="text" class="txtWriter" value="' + coun[i] + '" placeholder="请输入作者" width="80px"/>');
                }
            }
        };
        if (froms != "") {
            coun = froms.split(',');
            if (coun.length == 1) {
                $('.txtFrom')[0].value = coun[0];
            } else if (coun.length > 1) {
                $('.txtFrom')[0].value = coun[0];
                for (var i = 1; i < coun.length; i++) {
                    $('#pcont2').append('<input name="from" class="txtFrom" type="text" value="' + coun[i] + '" placeholder="请输入出处" width="80px"/>');
                }
            }
        };

        if (queryType != "") {
            if (queryType == 2) {
                $('.bs').addClass('active');
                $('.dz').removeClass('active'); 
                
            } else {
                $('.dz').addClass('active');
                $('.bs').removeClass('active');
            }
            $('#QueryType').val(queryType);
        }

        //$('#pcont1 input').onfocus(function() {
        //    alert("asd");
        //});
    });

    $('img.lazy').lazyload();
    $('img').lazyload({
        event: 'scrollstop'
    });

    $('.bs').click(function() {
        $('.bs').addClass('active');
        $('.dz').removeClass('active');
        $('#main_key').attr('placeholder', '请输入一个部首（支持繁简）');
        $('#QueryType').val("2");
    });
    $('.dz').click(function () {
        $('.dz').addClass('active');
        $('.bs').removeClass('active');
        $('#main_key').attr('placeholder', '请输入一个汉字（支持繁简）');
        $('#QueryType').val("1");
    });

    $('#main_so').click(function () {
        var key = $.trim($('#main_key').val());
        if (key == "") {
            randomToast("请输入一个关键字");
            return false;
        } else {
            this.submit();
        }
    });
</script>
<script type="text/javascript">
    function collection1(id) {
        //alert('收藏');
        var url = window.location.pathname;
        var type = "collection";
        $.ajax({
            url: "/Post/Collection",
            type: "post",
            //dataType: "json",
            data: { postId: id, type: type },
            success: function (result) {
                if (result.state == 3) {
                    location.href = "/Account/Login?returnUrl=" + url;
                }
                if (result.state == 2) {
                    alert("收藏失败，超过最大收藏数");
                    return;
                }
                if (result.state == 0) {
                    alert("操作失败");
                    return;
                }
                if (result.state == 1) {
                    if (type == "collection") {
                        alert("收藏成功");
                        //$('#collection').addClass("collection");
                        //$('#collection').attr("title", "已收藏");
                        //$('#collection').attr("onclick", "collection(" + id + ",'cancel')");
                    }
                }
            }
        });
    }

</script>

<%--轮播广告位--%>
<script src="common/scripts/slider.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        var bannerSlider = new Slider($('#banner_tabs'), {
            time: 5000,
            delay: 400,
            event: 'hover',
            auto: true,
            mode: 'fade',
            controller: $('#bannerCtrl'),
            activeControllerCls: 'active'
        });
        $('#banner_tabs .flex-prev').click(function () {
            bannerSlider.prev();
        });
        $('#banner_tabs .flex-next').click(function () {
            bannerSlider.next();
        });
    })
</script>



<script type="text/javascript">  
window._bd_share_config={"common":{"bdSnsKey":{},"bdText":"梅花书检-书法字典","bdMini":"2","bdMiniList":false,"bdPic":"","bdStyle":"0","bdSize":"16"},"slide":{"type":"slide","bdImg":"0","bdPos":"right","bdTop":"250"}};with(document)0[(getElementsByTagName('head')[0]||body).appendChild(createElement('script')).src='http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion='+~(-new Date()/36e5)];
</script>
</html>

