<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="postedit.aspx.cs" Inherits="MHSJ.Web.admin.admin_postedit" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../common/css/thickbox.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../common/scripts/jquery.js"></script>
    <script type="text/javascript" src="../common/scripts/jquery.tagto.js"></script>
    <script type="text/javascript" src="../common/scripts/thickbox.js"></script>
    <script type="text/javascript" src="../common/editor/ckeditor.js"></script>
    
    <script language="javascript" type="text/javascript" src="../common/scripts/jquery-ui-1.8.20.custom.js"></script>
    <link rel="stylesheet" href="../common/css/jquery.ui.autocomplete.css" type="text/css" media="screen"/>
    <style type="text/css">
        #postleft input{ width: 50%;}
    </style>
    <h2><%=headerTitle%></h2>
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            var radioList = $("#RadioBtnList :radio");
            radioList.attr('name', 'RadioButtonList');
            var fileUrl = $('#HidImageUrl').val();
            $('#txtImageUrl').attr("src", fileUrl);

            for (var i = 0; i < radioList.length; i++) {
                var radioId = $('#HidRadioList').val();
                if (radioList[i].value == radioId) {
                    radioList[i].checked=true;
                }
            }

            var radioWordDirectionList = $('#RadioWordDirection input');
            for (var j = 0; j < radioWordDirectionList.length; j++) {
                var wordDirectionId = $('#HidRadioWordDirection').val();
                if (radioWordDirectionList[j].value == wordDirectionId) {
                    radioWordDirectionList[j].checked = true;
                }
            }

            //本地数据源
            //var availableTags = [
            //    "C#",
            //    "Ruby"
            //];

            $("#txtTWord").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/CodeCommon/QueryWord.ashx",
                        data: { name: $("#txtTWord").val() },
                        dataType: "json",
                        success: function (data) {
                            response($.map(data.words, function (item) {
                                return {
                                    value: item.tword,
                                    tword: item.tword,
                                    word: item.word,
                                    bsword: item.bsword,
                                    id: item.id
                                }
                            }));
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    $("#HidWordId").val(ui.item.id);
                    $("#txtWord").val(ui.item.word);
                    $("#txtTWord").val(ui.item.tword);
                    $("#txtBushou").val(ui.item.bsword);
                }
            });

            $("#txtWriter").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/CodeCommon/QueryWriter.ashx",
                        data: { name: $("#txtWriter").val() },
                        dataType: "json",
                        success: function (data) {
                            response($.map(data.writer, function (item) {
                                return {
                                    value: item.name,
                                    id: item.id
                                }
                            }));
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    $("#HidWriterId").val(ui.item.id);
                    $("#txtWriter").val(ui.item.value);
                }
            });

            $("#txtFrom").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/CodeCommon/QueryFrom.ashx",
                        data: { name: $("#txtFrom").val() },
                        dataType: "json",
                        success: function (data) {
                            response($.map(data.from, function (item) {
                                return {
                                    value: item.name,
                                    id: item.id
                                }
                            }));
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    $("#HidFromId").val(ui.item.id);
                    $("#txtFrom").val(ui.item.value);
                }
            });

            $('[name="RadioButtonList"]').change(function () {
                var input = $("#RadioWordDirection").find("input:radio");
                input.attr("disabled", false);
                if ($(this).val() >= 14 && $(this).val() <= 26) {
                    input.each(function() {
                        if ($(this).val() == 0) {
                            $(this).attr("disabled", "disabled");
                        }
                        if ($(this).val() == 1) {
                            $(this).attr("checked", true);
                        }
                    });

                } else {
                    input.each(function () {
                        if ($(this).val() == 0) {
                            $(this).attr("checked", true);
                        }
                        if ($(this).val() == 1 || $(this).val() == 2) {
                            $(this).attr("disabled", "disabled");
                        }
                        
                    });
                }
            });

//            var input = $("#RadioWordDirection").find("input:radio");
//            input.attr("disabled", "disabled");
//            input.each(function () {
//                if ($(this).val() == 0) {
//                    $(this).attr("checked", true);
//                }
//            });
        });

        var tword=$("#txtTWord").val().trim();
        function twBlur() {
            var tw=$("#txtTWord").val().trim();
            if (tw == "") {
                $("#txtWord").val("");
                $("#HidWordId").val("");
            }
            else if (tw != tword && tword != undefined && tword!="") {
                $("#HidWordId").val("0");
                $("#txtWord").val("");
            }
        }
    </script>   
    <%=ResponseMessage %>
    
    <div style="float: left;width: 400px" runat="server" id="divisIndex">
         <p>
            <label class="label">作品选择:
            <a href="upfilebyeditor.aspx?keepThis=true&getfile=1&TB_iframe=true&height=480&width=780" title="选择作品" class="thickbox" target="_blank">选择作品</a>
            </label>    
             <img style="width: 200px; height: 200px; border: 1px #ccc solid" id="txtImageUrl" alt="图片" src=""/>
             <asp:HiddenField ID="HidImageUrl" runat="server" /> 
         </p>
         <asp:HiddenField ID="HidRadioList" runat="server" /> 
          <div id="RadioBtnList">
              <p>
                  楷书: 
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="大楷" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="小楷"></asp:ListItem>
                    <asp:ListItem Value="5" Text="行楷"></asp:ListItem>
                    <asp:ListItem Value="3" Text="魏碑"></asp:ListItem>
                    <asp:ListItem Value="4" Text="摩崖"></asp:ListItem>
                </asp:RadioButtonList>
            </p>
             <p>
                  行书: 
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="6" Text="行书"></asp:ListItem>
                </asp:RadioButtonList>
            </p>
            <p>
                  草书: 
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="7" Text="大草"></asp:ListItem>
                    <asp:ListItem Value="8" Text="小草"></asp:ListItem>
                    <asp:ListItem Value="9" Text="章草"></asp:ListItem>
                </asp:RadioButtonList>
            </p>
            <p>
                  隶书: 
                <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="10" Text="汉隶"></asp:ListItem>
                    <asp:ListItem Value="11" Text="简牍"></asp:ListItem>
                    <asp:ListItem Value="12" Text="摩崖"></asp:ListItem>
                    <asp:ListItem Value="13" Text="明清"></asp:ListItem>
                </asp:RadioButtonList>
            </p>
            <p>
                  篆书: 
                <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="14" Text="大篆"></asp:ListItem>
                    <asp:ListItem Value="15" Text="小篆"></asp:ListItem>
                    <asp:ListItem Value="16" Text="甲骨"></asp:ListItem>
                    <asp:ListItem Value="17" Text="中山"></asp:ListItem>
                    <%--<asp:ListItem Value="18" Text="汗篆"></asp:ListItem>--%>
                    <asp:ListItem Value="19" Text="端额"></asp:ListItem>
                    <asp:ListItem Value="20" Text="简帛"></asp:ListItem>
                    <asp:ListItem Value="27" Text="钱币"></asp:ListItem>
                </asp:RadioButtonList>
            </p>
            <p>
                  篆刻: 
                <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="21" Text="秦汉"></asp:ListItem>
                    <asp:ListItem Value="22" Text="明清"></asp:ListItem>
                    <asp:ListItem Value="23" Text="鸟虫"></asp:ListItem>
                    <asp:ListItem Value="24" Text="园朱"></asp:ListItem>
                    <asp:ListItem Value="25" Text="玉篆"></asp:ListItem>
                    <asp:ListItem Value="26" Text="叠篆"></asp:ListItem>
                </asp:RadioButtonList>
            </p>
        </div>
        <p>
            方向:
            <span style="border: 1px #ccc solid;padding: 5px">
                <asp:RadioButtonList ID="RadioWordDirection" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Text="无" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="正" ></asp:ListItem>
                    <asp:ListItem Value="2" Text="反"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:HiddenField ID="HidRadioWordDirection" runat="server" /> 
            </span>
        </p>
        
        
    </div>
    <div style="float: left;width: 30%;margin:0 0 0 50px" id="postleft" >
    <%--<p>
        <label class="label" for="<%=txtSimplifiedWord.ClientID %>">简体:
        <asp:TextBox maxlength="6" ID="txtSimplifiedWord"  runat="server" CssClass="text" onblur="doblur()"></asp:TextBox>    
        </label>       
    </p>
     <p>
        <label class="label" for="<%=txtTraditionalWord.ClientID %>">繁体:
        <asp:TextBox maxlength="6" ID="txtTraditionalWord"  runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>
     <p>
        <label class="label" for="<%=txtPinyin.ClientID %>">拼音:
        <asp:TextBox maxlength="25" ID="txtPinyin" runat="server" CssClass="text"></asp:TextBox>    
        </label>       
    </p>
     <p>
        <label class="label" for="<%=txtWubi.ClientID %>">五笔:
        <asp:TextBox maxlength="6" ID="txtWubi" runat="server" CssClass="text"></asp:TextBox>     
        </label>      
    </p>
     <p>
        <label class="label" for="<%=txtChangjei.ClientID %>">仓颉:
        <asp:TextBox maxlength="6" ID="txtChangjei" runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>
     <p>
        <label class="label" for="<%=txtZhengma.ClientID %>">郑码:
        <asp:TextBox maxlength="6" ID="txtZhengma" runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>
    
    <p>
        <label class="label" for="<%=txtTongjia.ClientID %>">通假:
        <asp:TextBox maxlength="6" ID="txtTongjia" runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>
    <p>
        <label class="label" for="<%=txtYiti.ClientID %>">异体:
        <asp:TextBox maxlength="6" ID="txtYiti" runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>--%>
     <p>
            <label class="label" for="<%=txtTWord.ClientID %>">对应字形:
            <asp:TextBox maxlength="6" ID="txtTWord"   Width="50%" runat="server" CssClass="text" onblur="twBlur()"></asp:TextBox> 
            <asp:HiddenField ID="HidTWord" runat="server" />  
            <span style="color:red">*</span>
            <span style="color: #ccc">（与图片对应）</span>
            </label>   
        </p>
     <p>
            <label class="label" for="<%=txtWord.ClientID %>">关联字体:
            <asp:TextBox maxlength="6" ID="txtWord" Width="50%" runat="server" CssClass="text"></asp:TextBox> 
            <asp:HiddenField ID="HidWordId" runat="server" />  
            <span style="color:red">*</span>
            </label>   
        </p>
        
         <p>
        <label class="label" for="<%=txtBushou.ClientID %>"><span style="font-weight: bold">对应部首:</span>
        <asp:TextBox maxlength="6" ID="txtBushou" runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>
        <p>
            <label class="label" for="<%=txtWriter.ClientID %>">作&nbsp;&nbsp;家:
            <asp:TextBox maxlength="6" ID="txtWriter"   Width="50%" runat="server" CssClass="text"></asp:TextBox> 
            <asp:HiddenField ID="HidWriterId" runat="server" />  
            </label>   
        </p>
        <p>
            <label class="label" for="<%=txtFrom.ClientID %>">出&nbsp;&nbsp;处:
            <asp:TextBox maxlength="6" ID="txtFrom"   Width="50%" runat="server" CssClass="text"></asp:TextBox>   
            <asp:HiddenField ID="HidFromId" runat="server" />   
            </label>   
        </p>
        
     <p>
        <label class="label" >状&nbsp;&nbsp;态:
         <asp:CheckBox ID="State" runat="server" Width="30px"/>
        </label>     
        <span style="color: #ccc">打钩时说明该图片所有的编辑均已完成。</span>
        <%--未打钩时则说明跟图片的部首拆解尚未完成，或者其他暂时不知如何拆解等待处理的项目</span> --%>
    </p>
    <p> <asp:Button ID="btnEdit" runat="server" Text="添加" onclick="btnEdit_Click"  CssClass="button" Width="50px"/></p>
    </div>
    <script type="text/javascript">
        function addFileToEditor(fileUrl, fileExtension) {
            if (fileExtension == '.gif' || fileExtension == '.jpg' || fileExtension == '.jpeg' || fileExtension == '.png') {
                //var imageTag = "<img src=\"" + fileUrl + "\"/>";
                $('#HidImageUrl').val(fileUrl);
                $('#txtImageUrl').attr("src", fileUrl);
            }
        }
    </script>
</asp:Content>

