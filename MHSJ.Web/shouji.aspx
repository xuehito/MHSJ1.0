<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shouji.aspx.cs" Inherits="MHSJ.Web.shouji" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="common/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="common/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .mystats { float: right; line-height: 20px; color: #555555; padding: 10px 5px; }
        #btn-navbar { display: none; }
        
        
        .main { background-color: #BBD8E9; }
        .aside { background-color: #DCEAF4; }
        
        
        @media (min-width: 590px) and (max-width: 838px) {
            .navbar .nav { float: none; }
        
        }
        
        @media (min-width: 1px) and (max-width: 590px) {
            #btn-navbar { display: block; float: none; width: 100%; margin: 0; }
            .navbar-inner { padding: 0; min-height: 0; }
             .mystats { display: none; }
            .navbar-inner .nav { float: none; margin: 0; display: none; }
            .open .nav { display: block; }
            .navbar .nav > li { float: none; }
        }
    </style>
</head>
<body>
    <div class="header">
        <div class="navbar">
            <div class="navbar-inner">
                <button data-target=".nav-collapse" data-toggle="collapse" class="btn btn-navbar collapsed"
                    id="btn-navbar" type="button">
                    <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar">
                    </span>
                </button>
                <ul class="nav " id="nav">
                    <li><a href="#">博客园</a> </li>
                    <li class="active"><a href="#">首页</a></li>
                    <li><a href="#">博问</a></li>
                    <li><a href="#">闪存</a></li>
                    <li><a href="#">新随笔</a></li>
                    <li><a href="#">联系</a></li>
                    <li><a href="#">订阅</a></li>
                    <li><a href="#">管理</a></li>
                </ul>
                <div class="mystats">
                    <!--done-->
                    随笔-64&nbsp; 评论-844&nbsp; 文章-0&nbsp; trackbacks-0
                </div>
            </div>

            ddfdfdffd
        </div>
    </div>
    <script src="common/scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="common/scripts/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var btnNavbar = $('#btn-navbar');
            btnNavbar.click(function () {
                var el = $(this);
                var p = el.parent();

                var nav = $('#nav');
                if (p.hasClass('open')) {
                    p.removeClass('open');

                } else {
                    p.addClass('open');
                }
            });
        });
    
    </script>
</body>
</html>
