<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="MHSJ.Web.admin.admin_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
.navs{line-height:22px; border:0px solid #ccc;color:#666; padding:3px  ;}
.navs a { padding-right:8px; font-size:14px;}
</style>
<h2>网站设置</h2>
<%=ResponseMessage %>
<h4 id="bases">基本设置</h4>
<table width="100%">
    <tr class="row">
        <td  style="width:20%;"><label  for="<%=txtSiteName.ClientID %>">网站标题:</label></td>
        <td><asp:TextBox ID="txtSiteName"   Width="70%"  runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr class="row">
        <td><label  for="<%=txtSiteDescription.ClientID %>">网站描述:</label></td>
        <td><asp:TextBox ID="txtSiteDescription" Width="70%"   runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr class="row">
        <td ><label  for="<%=txtMetaKeywords.ClientID %>">Meta Keywords:</label></td>
        <td><asp:TextBox ID="txtMetaKeywords"   Width="70%"  runat="server" CssClass="text"></asp:TextBox> <span class="m_desc" >首页关键字,用逗号","隔开</span></td>
    </tr>
    <tr class="row">
        <td><label  for="<%=txtMetaDescription.ClientID %>">Meta Description:</label></td>
        <td><asp:TextBox ID="txtMetaDescription" Width="70%"   runat="server" CssClass="text"></asp:TextBox> <span class="m_desc" >首页描述</span></td>
    </tr>
</table>
<h4 id="footers">页脚设置<span class="small gray normal">(支持Html,网站统计,备案号等可放于此)</span></h4>
<table width="100%">
        <tr class="row">
            <td  style="width:20%;"><label class="" for="<%=txtFooterHtml.ClientID %>">页脚内容:</label></td>
            <td><asp:TextBox ID="txtFooterHtml" Width="80%" Height="100px" TextMode="multiLine"    runat="server"></asp:TextBox></td>
        </tr>
        <tr class="rowend">
            <td>&nbsp;</td>
            <td><asp:Button ID="btnEdit" CssClass="button" runat="server" OnClick="btnEdit_Click" Text="保存"  /></td>
        </tr>
    </table>
</asp:Content>
