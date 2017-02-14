<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="wordlist.aspx.cs" Inherits="MHSJ.Web.admin.wordlist" ClientIDMode="Static"%>
<%@ Register TagPrefix="loachs" Namespace="MHSJ.Core.Controls" Assembly="MHSJ.Core" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../common/scripts/jquery.js"></script>
     
 <script type="text/javascript">
     $(document).ready(function() {
        
     });

     function swBlur() {
         //简体转换为繁体
         var sw = $("#txtSimplifiedWord").val().trim();
         var tw = $("#txtTraditionalWord").val().trim();
         var py = $("#txtPinyin").val().trim();
         if (sw.length <= 0) return;
         $.ajax({
             url: "/CodeCommon/ChineseStringConverter.ashx",
             data: { name: sw },
             dataType: "json",
             success: function(data) {
                 if (data == null) {
                     alert("没查询到改字的繁体");
                 } else {
                     var fan = data["fan"];
                     var pinyin = data["pinyin"];
                     //if (tw.length <= 0) {
                         $("#txtTraditionalWord").val(fan);
                     //}
                     //if (py.length <= 0) {
                         //$("#txtPinyin").val(pinyin);
                     //}
                 }
             }
         });
     }
 </script>
 <h2>文字管理</h2>
 <%=ResponseMessage %>
<div class="right">
    <h4>添加文字</h4>
    <p>
        <label class="label" for="<%=txtSimplifiedWord.ClientID %>">关联字体:
        <asp:TextBox maxlength="6" ID="txtSimplifiedWord"  runat="server" CssClass="text"  onblur="swBlur()"></asp:TextBox>    
        </label>       
    </p>
     <p>
        <label class="label" for="<%=txtTraditionalWord.ClientID %>">对应字形:<span style="color: #ccc">(不能重复)</span>
        <asp:TextBox maxlength="6" ID="txtTraditionalWord"  runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>
      <%--<p>
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
    </p>--%>
     <p>
        <label class="label" for="<%=txtBushou.ClientID %>"><span style="font-weight: bold">部首:</span>
        <asp:TextBox maxlength="6" ID="txtBushou" runat="server" CssClass="text"></asp:TextBox>   
        </label>        
    </p>
    <%--<p>
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
        <label class="label" >状态:
         <asp:CheckBox ID="State" runat="server" Width="30px"/>
        </label>     
        <span style="color: #ccc">打钩时说明该图片所有的编辑均已完成。</span>
        <%--未打钩时则说明跟图片的部首拆解尚未完成，或者其他暂时不知如何拆解等待处理的项目</span>   --%>
    </p>
     <p>
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="添加"  CssClass="button"/>
     </p>
    <br/>
     
    <h4>搜索</h4>
    <p>
        <label class="label" for="<%=querySimplifiedWord.ClientID %>">关联字体:</label>
        <asp:TextBox ID="querySimplifiedWord" runat="server" CssClass="text"></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=queryTraditionalWord.ClientID %>">对应字形:</label>
        <asp:TextBox ID="queryTraditionalWord" runat="server" CssClass="text"></asp:TextBox>
    </p>
     <p>
        <label class="label" for="<%=queryBushou.ClientID %>">部首:</label>
        <asp:TextBox ID="queryBushou" runat="server" CssClass="text"></asp:TextBox>
    </p>
    
     <p>
         状态:
        <label class="label">选中:
        <asp:CheckBox ID="CheckBox1" runat="server" Width="30px"/>
        </label>
        <label class="label">待修:
        <asp:CheckBox ID="State1" runat="server" Width="30px"/>
        </label>
    </p>
    
    <p><asp:Button ID="btnSearch" runat="server"  Text="搜索"  OnClick="btnSearch_Click"  CssClass="button" /></p>
    

</div>
<div class="left" >
    <table width="100%">
        <tr class="category">
            
            <td>关联字体</td>
            <td>对应字形</td>
           <%-- <td>拼音</td>--%>
            <td>部首</td>
            <td>状态</td>
            <td>创建日期</td>
            <td>操作</td>
        </tr>
        <asp:Repeater ID="rptWord" runat="server">
            <ItemTemplate>
                <tr class="row">
                    
                    <td><%# DataBinder.Eval(Container.DataItem, "SimplifiedWord")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "TraditionalWord")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "Pinyin")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Bushou")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "State").ToString() == "1" ? "<img src=\"../common/images/admin/yes.gif\" title=\"完成\"/>" : "<img src=\"../common/images/admin/no.gif\" title=\"未完\"/>"%></td>
                    <td><%# Convert.ToDateTime( DataBinder.Eval(Container.DataItem, "CreateDate")).ToString("yyyy-MM-dd")%></td>
                    <td>
                       <%#GetEditLink(DataBinder.Eval(Container.DataItem, "wordid"), DataBinder.Eval(Container.DataItem, "wordid"))%>
                       <%#GetDeleteLink(DataBinder.Eval(Container.DataItem, "wordid"), DataBinder.Eval(Container.DataItem, "wordid"))%>
                       
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <loachs:Pager id="Pager1" runat="server" PageSize="22"  CssClass="pager"></loachs:Pager>
</div>
</asp:Content>