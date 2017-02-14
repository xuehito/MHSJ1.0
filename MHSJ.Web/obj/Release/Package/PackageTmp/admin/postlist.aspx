<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="postlist.aspx.cs" Inherits="MHSJ.Web.admin.admin_postlist" ClientIDMode="Static" %>
<%@ Register TagPrefix="loachs" Namespace="MHSJ.Core.Controls" Assembly="MHSJ.Core" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>作品管理</h2>
    <script type="text/javascript" src="../common/scripts/jquery.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            var radioWordDirectionList = $('#RadioWordDirection input');
            for (var j = 0; j < radioWordDirectionList.length; j++) {
                var wordDirectionId = $('#HidRadioWordDirection').val();
                if (radioWordDirectionList[j].value == wordDirectionId) {
                    radioWordDirectionList[j].checked = true;
                }
            }
        });
     </script>
<%=ResponseMessage%>
<div  class="right">
    <h4>搜索</h4>
    <p>
        <label class="label" for="<%=txtSimplifiedWord.ClientID %>">关联字体:</label>
        <asp:TextBox ID="txtSimplifiedWord" runat="server" CssClass="text"></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtTraditionalWord.ClientID %>">对应字形:</label>
        <asp:TextBox ID="txtTraditionalWord" runat="server" CssClass="text"></asp:TextBox>
    </p>
     <p>
        <label class="label" for="<%=txtBushou.ClientID %>">部首:</label>
        <asp:TextBox ID="txtBushou" runat="server" CssClass="text"></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtWriterName.ClientID %>">作者:</label>
        <asp:TextBox ID="txtWriterName" runat="server" CssClass="text"></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtFromName.ClientID %>">出处:</label>
        <asp:TextBox ID="txtFromName" runat="server" CssClass="text"></asp:TextBox>
    </p>
     <p>
        <label class="label" for="<%=txtFromName.ClientID %>">类型:</label>
        <asp:TextBox ID="txtWordTypeName" runat="server" CssClass="text"></asp:TextBox>
    </p>
     <p>
         状态:
        <label class="label">选中:
        <asp:CheckBox ID="State" runat="server" Width="30px"/>
        </label>
        <label class="label">待修:
        <asp:CheckBox ID="State1" runat="server" Width="30px"/>
        </label>
    </p>
    <p>
            <label class="label">方向:
                <asp:RadioButtonList ID="RadioWordDirection" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Text="无" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="正" ></asp:ListItem>
                    <asp:ListItem Value="2" Text="反"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:HiddenField ID="HidRadioWordDirection" runat="server" /> 
            </label>
        </p>
    <p><asp:Button ID="btnSearch" runat="server"  Text="搜索"  OnClick="btnSearch_Click"  CssClass="button" /></p>
    
</div>
<div class="left" >
    <table width="100%">
        <tr class="category">
            <td>缩略图</td>
            <td>关联字体</td>
            <td>对应字形</td>
            <td>类型</td>
            <%--<td>拼音</td>--%>
            <td>部首</td>
            <td>作者</td>
            <td>出自</td>
            <%--<td>类型</td>--%>
            <td>状态</td>
            <td>创建日期</td>
            <td>操作</td>
        </tr>
        <asp:Repeater ID="rptPost" runat="server">
            <ItemTemplate>
                <tr class="row">
                    <td><%# GetImage(DataBinder.Eval(Container.DataItem, "ImageUrl"), DataBinder.Eval(Container.DataItem, "WriterName"))%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "SimplifiedWord")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "TWord")%></td>
                    <td><%# WordTypeTransForm(DataBinder.Eval(Container.DataItem, "WordType").ToString())%></td>
                   <%-- <td><%# DataBinder.Eval(Container.DataItem, "Pinyin")%></td>--%>
                   <td><%# DataBinder.Eval(Container.DataItem, "Bushou")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "WriterName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "FromName")%></td>
                    <td><%# Eval("State").ToString() == "1" ? "<img src=\"../common/images/admin/yes.gif\" title=\"完成\"/>" : "<img src=\"../common/images/admin/no.gif\" title=\"未完\"/>"%></td>
                    <td><%# Convert.ToDateTime( DataBinder.Eval(Container.DataItem, "CreateDate")).ToString("yyyy-MM-dd")%></td>
                    <td>
                       <%#GetEditLink(DataBinder.Eval(Container.DataItem, "postid"), DataBinder.Eval(Container.DataItem, "postid"))%>
                       <%#GetDeleteLink(DataBinder.Eval(Container.DataItem, "postid"), DataBinder.Eval(Container.DataItem, "postid"))%>
                       
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <loachs:Pager id="Pager1" runat="server" PageSize="15"  CssClass="pager"></loachs:Pager>
</div>
</asp:Content>
