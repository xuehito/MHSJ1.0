//屏蔽右键菜单
document.oncontextmenu = function (event) {
	if (window.event) {
		event = window.event;
	} try {
		var the = event.srcElement;
		if (!((the.tagName == "INPUT" && the.type.toLowerCase() == "text") || the.tagName == "TEXTAREA")) {
			return false;
		}
		return true;
	} catch (e) {
		return false;
	}
};

//全选
$(function() {
    //one
    $("#checkAllfr1").click(function () {
        $('input[name="fr1[]"]').attr("checked", this.checked);
    });
    //three
    $("#checkAllfr3").click(function() {
        $('input[name="fr3[]"]').attr("checked", this.checked);
    });
    //four
    $("#checkAllfr4").click(function() {
        $('input[name="fr4[]"]').attr("checked", this.checked);
    });
    //five
    $("#checkAllfr5").click(function() {
        $('input[name="fr5[]"]').attr("checked", this.checked);
    });
    //six
    $("#checkAllfr6").click(function() {
        $('input[name="fr6[]"]').attr("checked", this.checked);
    });

    var key = $('#main_key').attr('placeholder');
    $("#main_key").focus(function () {
        $('#main_key').attr('placeholder', '');
    });
//    $("#main_key").blur(function () {
//        if ($.trim($("#main_key").val()) == "") {
//            $('#main_key').attr('placeholder', key);
//        }
//    });

    autocomplete();
});

function autocomplete() {
    //自动提示作者
    $(".txtWriter").autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "/CodeCommon/QueryWriter.ashx",
                data: { name: request.term },
                dataType: "json",
                success: function(data) {
                    response($.map(data.writer, function(item) {
                        return {
                            value: item.name,
                            id: item.id
                        }
                    }));
                }
            });
        },
        minLength: 1,
        select: function(event, ui) {
            //$(".txtWriter").val(ui.item.value);
            this.value = ui.item.value;
            this.title = ui.item.value;
        }
         
    });

    //自动提示出处
    $(".txtFrom").autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "/CodeCommon/QueryFrom.ashx",
                data: { name: request.term },
                dataType: "json",
                success: function(data) {
                    response($.map(data.from, function(item) {
                        return {
                            value: item.name,
                            id: item.id
                        }
                    }));
                }
            });
        },
        minLength: 1,
        select: function(event, ui) {
            this.value = ui.item.value;
            this.title = ui.item.value;
        }
    });

    var x = $('#pcont1 input');
    x.title = x.text;


}


// 加入收藏 
function shoucang(sTitle,sURL)
{       
       try
        {
            window.external.addFavorite(sURL, sTitle);
        }
        catch (e)
        {
            try
            {
                window.sidebar.addPanel(sTitle, sURL, "");
            }
            catch (e)
            {
                alert("加入收藏失败，请使用Ctrl+D进行添加");
            }
        }
}

$(function() {
    //点击增加一个作者
    $('.jiaWriter').click(function() {
        if ($('.txtWriter').length < 3) {
            //$('#pcont1').append('<p style="margin-bottom:10px;"><input name="writer" type="text" class="txtWriter" value="" placeholder="请输入作者" style="margin-left: 72px;"/></p>');
            $('#pcont1').append('<input name="writer" type="text" class="txtWriter" width="80px" value="" placeholder="请输入作者"/>');
        } else {
            randomToast("作者自定义不能超过3个");
        }

        autocomplete();
    });
    //减少作者
    $('.jianWriter').click(function () {
        if ($('.txtWriter').length == 1) {
            $('#pcont1 input:last').val("");
        }
        if ($('.txtWriter').length > 1) {
            $('#pcont1 input:last').remove();
        }
    });
    //点击增加一个出处
    $('.jiaFrom').click(function() {
        if ($('.txtFrom').length < 3) {
            //$('#pcont2').append('<p style="margin-bottom:10px;"><input name="from" class="txtFrom" type="text" value="" placeholder="请输入出处" style="margin-left: 72px;"/></p>');
            $('#pcont2').append('<input name="from" class="txtFrom" type="text" value="" width="80px" placeholder="请输入出处" />');
        } else {
            randomToast("出处自定义不能超过3个");
        }

        autocomplete();
    });
    //减少出处
    $('.jianFrom').click(function () {
        if ($('.txtFrom').length == 1) {
            $('#pcont2 input:last').val("");
        }
        if ($('.txtFrom').length > 1) {
            $('#pcont2 input:last').remove();
        }
    });

    // 查询
//    $('#main_so').click(function() {
//        var key = $('#main_key').val();
//        alert(key);
//    });

    //

});//jiuxu

//提示
/*priority：success，info，warning，danger*/
function randomToast(message) {
    var priority = 'danger';
    var title = '提示';
    $.toaster({ priority: priority, title: title, message: message });
}

//点击弹出大图
$(function () {
    $(".wtu li").click(function () {
        var mysrc = $(this).find("img").attr("src");
        $("#dagImg").attr("src", mysrc);
        var w = -($(".albig").width() / 2);
        var h = -($(".albig").height() / 2);
        $(".albig").css("margin-top", h).css("margin-left", w);
        $(".albig").css("display", "block");
        $(".nimei").css("display", "block");
    });
    $(".guanbi").click(function() {
        $(".albig").css("display", "none");
        $(".nimei").css("display", "none");
    });

    $(".nimei").click(function () {
        $(".albig").css("display", "none");
        $(".nimei").css("display", "none");
    });
});

