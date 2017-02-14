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
                     <a href="/index.aspx" title="梅花书检">
                         <img class="logo" src="/common/images/logo.png" alt="梅花书检" class="logo" />
                     </a>
                </div>
            </div>
            <div class="row-fluid main-center">
                <div class="span12">
                    <input type="text" class="span2" name="keyword" value="<%=Keyword %>" id="main_key"  style="margin:10px 0;min-width: 220px" placeholder="请输入一个汉字（支持繁简）"/>
                    <button type="submit" id="main_so" title="搜索" class="btn btn-danger" style="margin:10px 0">搜索</button>
                </div>
                
               <%-- <div class="span12">
                   
                    <ul class="dropdown-menu" role="menu" aria-labelledby="dLabel" style="display: block;position:relative">
                        <li class="dropdown-submenu">
                                <label class="sb checkbox inline"><a tabindex="-1" href="#">楷书</a></label>
                                <ul class="dropdown-menu">
                                    <li><label class="qb checkbox inline"><input id="Checkbox1" type="checkbox" name="fr1[]" value ="0"/>全部</label> </li>
    	                            <li><label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="1"/>大楷</label></li>
    	                            <li><label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="2"/>小楷</label></li>
    	                            <li><label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="5"/>行楷</label></li>
    	                            <li><label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="3"/>魏碑</label></li>
    	                            <li><label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="4"/>摩崖</label></li>
                                </ul>
                         </li>    
                         <li class="dropdown-submenu">
                                <label class="sb checkbox inline"><a tabindex="-1" href="#">行书</a></label>
                                <ul class="dropdown-menu">
                                    <li><label class="qb checkbox inline"><input type="checkbox" name="fr2[]" value ="6"/>全部</label> </li>
                                </ul>
                         </li>   
                         <li class="dropdown-submenu">
                                <label class="sb checkbox inline"><a tabindex="-1" href="#">草书</a></label>
                                <ul class="dropdown-menu">
                                    <li><label class="qb checkbox inline"><input  id="checkAllfr3" type="checkbox" name="fr3[]" value ="0"/>全部</label> </li>
                                    <li><label class="checkbox inline"><input type="checkbox" name="fr3[]" value ="7"/>大草</label> </li>
                                    <li><label class="checkbox inline"><input type="checkbox" name="fr3[]" value ="8"/>小草</label> </li>
                                    <li><label class="checkbox inline"><input type="checkbox" name="fr3[]" value ="9"/>章草</label> </li>
                                </ul>
                         </li>                      
                    </ul>

                     <ul class="">
                    <li><label class="sb checkbox inline">楷书：</label>
    	                <label class="qb checkbox inline"><input id="checkAllfr1" type="checkbox" name="fr1[]" value ="0"/>全部</label> 
    	                <label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="1"/>大楷</label> 
    	                <label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="2"/>小楷</label> 
    	                <label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="5"/>行楷</label> 
    	                <label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="3"/>魏碑</label> 
    	                <label class="checkbox inline"><input type="checkbox" name="fr1[]" value ="4"/>摩崖</label> 
	                </li>
                    <li><label class="sb checkbox inline">行书：</label>
                        <label class="qb checkbox inline"><input type="checkbox" name="fr2[]" value ="6"/>全部</label> 
                    </li>
                    <li><label class="sb checkbox inline">草书：</label>
                        <label class="qb checkbox inline"><input  id="checkAllfr3" type="checkbox" name="fr3[]" value ="0"/>全部</label> 
		                <label class="checkbox inline"><input type="checkbox" name="fr3[]" value ="7"/>大草</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr3[]" value ="8"/>小草</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr3[]" value ="9"/>章草</label> 
	                </li>
                    <li><label class="sb checkbox inline">隶书：</label>
                        <label class="qb checkbox inline"><input id="checkAllfr4" type="checkbox" name="fr4[]" value ="0"/>全部</label> 
		                <label class="checkbox inline"><input type="checkbox" name="fr4[]" value ="10"/>汉隶</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr4[]" value ="11"/>简牍</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr4[]" value ="12"/>摩崖</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr4[]" value ="13"/>明清</label> 
	                </li>
                    <li><p class="zhuan">
                        <label class="sb checkbox inline">篆书：</label>
                        <label class="zheng checkbox inline"><input type="radio" name="direction1" value="1" checked="checked"/>正</label>  
                        <label class="fan checkbox inline"><input type="radio" name="direction1" value="2"/>反</label> 
                        <label class="qb checkbox inline"><input id="checkAllfr5" type="checkbox" name="fr5[]" value ="0"/>全部</label> 
		                <label class="checkbox inline"><input type="checkbox" name="fr5[]" value ="14"/>大篆</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr5[]" value ="15"/>小篆</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr5[]" value ="16"/>甲骨</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr5[]" value ="17"/>中山</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr5[]" value ="18"/>汉篆</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr5[]" value ="19"/>端额</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr5[]" value ="20"/>简帛</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr4[]" value ="27"/>钱币</label> 
	                </p></li>
                    <li><p class="zhuan">
                        <label class="sb checkbox inline">篆刻：</label>
                        <label class="zheng checkbox inline"><input type="radio" name="direction2" value="3" checked="checked"/>正</label>  
                        <label class="fan checkbox inline"><input type="radio" name="direction2" value="4"/>反</label> 
                        <label class="qb checkbox inline"><input id="checkAllfr6" type="checkbox" name="fr6[]" value ="0"/>全部</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr6[]" value ="21"/>秦汉</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr6[]" value ="22"/>明清</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr6[]" value ="23"/>鸟虫</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr6[]" value ="24"/>圆朱</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr6[]" value ="25"/>玉篆</label> 
                        <label class="checkbox inline"><input type="checkbox" name="fr6[]" value ="26"/>叠篆</label> 
	                </p></li>
                    </ul>
                </div>--%>
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
    
    <!--作者-->
    <%--<div class="zz">
    	<p id="pcont1">作者：
        <input name="writer" class="txtWriter" type="text" value="" placeholder="请输入作者" />
            <a class="jiaWriter" href="#" title="增加"><img src="common/images/jiabtn.png" alt=""/></a>
            <a class="jianWriter" href="#" title="减少"><img src="common/images/jianbtn.png" /></a>
            <br />
        </p>
        <p id="pcont2">出处：
        <input name="from" type="text" class="txtFrom" value="" placeholder="请输入出处" />
        <a class="jiaFrom" href="#"  title="增加"><img src="common/images/jiabtn.png" /></a>
        <a class="jianFrom" href="#" title="减少"><img src="common/images/jianbtn.png" /></a>
            <br />
        </p>
    </div>
  
    
    
	
    <div class="albig" id="albig">
        <p class="guanbi">
            <img src="common/images/guanb.png" />
        </p>
        <img id="dagImg" src=""  draggable="false"/>
    </div>
    <div class="nimei"></div>--%>
<!--翻页-->
    <%= Pager%>
</div>
<div style="height:20px;"></div>
    
    <div class="bottom">
        <!--友情链接-->
        <div class="link">
            <p>友情链接</p>
            <div class="linkCon">
			     <ul>
			         <li><a target="_blank" href="http://www.mhsj.top">梅花书检</a></li>
                 </ul>
            </div>
        </div>

        <!--底部-->
        <div class="footer">
            <p>
                <a href="/about/contact.aspx" target="_blank">联系我们</a>
                <%--<a href="#" target="_blank">关于我们</a>
                <a href="#" target="_blank">网站地图</a>--%>
                <a href="/#" target="_blank">友情链接</a>
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
    </div>
</body>
<script type="text/javascript">
    $(function () {
        var writers = "<%=Writers %>";
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
            coun = fr1.split(',');
            $.each($("input[name='fr1[]']"), function () {
                for (var i = 0; i < coun.length; i++) {
                    if (coun[i] == $(this).val()) $(this).attr("checked", "true");
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

            var dire1 = $("input[name='direction1']");
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
            } else if (coun.length > 1) {
                $('.txtWriter')[0].value = coun[0];
                for (var i = 1; i < coun.length; i++) {
                    $('#pcont1').append('<p style="margin-bottom:10px;"><input name="writer" type="text" class="txtWriter" value=' + coun[i] + ' placeholder="请输入作者" style="margin-left: 72px;"/></p>');
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
                    $('#pcont2').append('<p style="margin-bottom:10px;"><input name="from" class="txtFrom" type="text" value=' + coun[i] + ' placeholder="请输入出处" style="margin-left: 72px;"/></p>');
                }
            }

        };
    });
</script>

</html>
