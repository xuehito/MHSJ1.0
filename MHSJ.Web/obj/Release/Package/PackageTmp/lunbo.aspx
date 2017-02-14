<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lunbo.aspx.cs" Inherits="MHSJ.Web.lunbo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<script language="javascript" type="text/javascript" src="/common/scripts/jquery-1.7.2.min.js"></script>
<head runat="server">
    <title></title>
<style type="text/css">
    body, p, h1, h2, h3, h4, h5, h6, ul, li, ol, dl, dt, dd, form{margin:0px;padding:0px;}
    li, dt, dd{list-style:none;}
    /* top-main */
   #top-main{position:relative;overflow:hidden;height:110px;}
    #top-main .mid{width:1004px;position:relative;margin:0 auto;}
    #top-main .left-banner{overflow:hidden;}
    #top-main .controller{position:absolute;height:20px;top:95px;right: 5px;}
    #top-main .controller li{cursor:pointer;background:#abc;float:left;width:22px;height:20px;background:url('common/images/lunbo/dot.png') 4px 0 no-repeat;_background:url('common/images/lunbo/dot_8.png') 4px 0 no-repeat;}
    #top-main .controller li.current{background-position:5px -20px;}
    #top-main .controller li:hover{position:relative;top:1px;}
</style>
</head>


<body>
    <div id="top-main">
	<div class="mid">
		<ul class="left-banner">
			<li><a href="http://www.baidu.com"  target="_blank" >
			        <img src="common/images/lunbo/a.jpg" border="0" width="1004" height="90" style="position: absolute;" alt=""/>
			    </a></li>
			<li style="left:-1920px"><a href="http://www.baidu.com"  target="_blank">
			        <img src="common/images/lunbo/b.jpg" border="0" width="1004" height="90"  style="position:absolute;" alt=""/>
			    </a></li>
			<%--<li style="left:-1920px"><img src="common/images/lunbo/003.png" /></li>
			<li style="left:-1920px"><img src="common/images/lunbo/002.png" /></li>--%>
		</ul>
		<ul class="controller">
			<li data-ca="main-slide1" class="current"></li>
			<li data-ca="main-slide2"></li>
			<li data-ca="main-slide3"></li>
			<li data-ca="main-slide4"></li>
		</ul>
	</div>
</div>
    
    <script type="text/javascript">
        //首页轮播动画
        ; (function ($) {
            $.fn.fadeAnimate = function (options) {
                options = $.extend({
                    liDomList: $(this).find('li'),
                    liDomListLen: $(this).find('li').length,
                    disableAutoEle: $('#account-box'),
                    curIndex: 0,
                    nextIndex: 1,
                    curDom: undefined,
                    nextDom: undefined,
                    curLeft: 0,
                    minLeft: -1470,
                    fadeLock: false,
                    fadeTime: 5000,
                    imgWidth: 1470,
                    controller: $('#top-main .controller'),
                    controllerList: $('#top-main .controller li'),
                    timer: undefined,
                    accSpeed: 4,
                    Cx: 0.02, //阻力系数
                    minRes: 1, //最小阻力
                    curSpeed: 0
                }, options);

                //移动到
                function changeTo(index) {
                    if (true == options.fadeLock) { return; }
                    window.clearTimeout(options.timer);
                    options.nextIndex = index;
                    options.fadeLock = true;

                    //初始化
                    options.curDom = options.liDomList.eq(options.curIndex);
                    options.nextDom = options.liDomList.eq(options.nextIndex);
                    options.nextDom.css('opacity', 0);
                    options.curLeft = 0;
                    options.curSpeed = 0;
                    options.nextDom.css('left', options.curLeft + options.imgWidth);
                    controlChange(options.nextIndex);

                    move();
                }

                //动画
                function move() {
                    var nextLeft = getNextLeft();
                    var opacity = Math.abs(nextLeft / options.imgWidth);
                    var opacityPer = parseInt(opacity * 100);
                    options.curDom.css({ 'left': nextLeft, 'opacity': 1 - opacity, 'filter': 'alpha(opacity=' + (100 - opacityPer) + ')' });

                    options.nextDom.css({ 'left': nextLeft + options.imgWidth, 'opacity': opacity, 'filter': 'alpha(opacity=' + opacityPer + ')' });
                    if (nextLeft <= options.minLeft) {
                        options.curIndex = options.nextIndex;
                        options.fadeLock = false;
                        autoFade();
                    } else {
                        window.setTimeout(move, 20);
                    }
                }

                //获取下次速度
                function getNextSpeed() {
                    var incSpeed = options.accSpeed - options.minRes - options.curSpeed * options.Cx;
                    return options.curSpeed += incSpeed;
                }

                //获取下次便宜left
                function getNextLeft() {
                    var nextSpeed = getNextSpeed();
                    options.curLeft = options.curLeft - nextSpeed < options.minLeft ? options.minLeft : options.curLeft - nextSpeed;
                    return options.curLeft;
                }

                //获取下个索引
                function changeNext() {
                    var nextIndex = options.curIndex + 1 >= options.liDomListLen ? 0 : options.curIndex + 1;
                    changeTo(nextIndex);
                }

                //轮播图按钮点击效果
                options.controller.delegate('li', 'click', function (e) {
                    var index = $(e.currentTarget).index();
                    changeTo(index);
                });


                //手动控制
                function controlChange(index) {
                    options.controllerList.eq(index).addClass('current').siblings('.current').removeClass('current');
                }

                //自动轮播
                function autoFade() {
                    window.clearTimeout(options.timer);
                    options.timer = window.setTimeout(changeNext, options.fadeTime);
                }

                autoFade();

                /*
                options.disableAutoEle.focusin(function(){
                window.clearTimeout(options.timer);	
                }).focusout(function(){
                autoFade();
                })
                */

                $(this).mouseenter(function () {
                    window.clearTimeout(options.timer);
                }).mouseleave(function () {
                    autoFade();
                });

                return $(this);
            }
        })(jQuery);

        $('#top-main .left-banner').fadeAnimate({});

</script>
</body>
</html>
