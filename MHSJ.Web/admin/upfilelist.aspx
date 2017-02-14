<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="upfilelist.aspx.cs" Inherits="MHSJ.Web.admin.admin_upfilelist" %>
<%@ Register src="UserControls/upfilemanager.ascx" tagname="upfilemanager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../common/scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../common/scripts/lanrenjiazai.js" type="text/javascript"></script>
    <script src="../common/scripts/jquery.scrollstop.js" type="text/javascript"></script>
    <uc1:upfilemanager ID="upfilemanager1" runat="server" />
</asp:Content>
