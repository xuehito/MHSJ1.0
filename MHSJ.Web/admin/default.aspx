<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MHSJ.Web.admin.admin_default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>管理中心</h2>
<%=ResponseMessage%>
<div  class="right">
   
</div>
<div class="left" >
    <table width="100%">
        
        <tr class="category">
            <td>网站信息</td>
            <td style="width:70%;"></td>
        </tr>
        
         <tr class="row">
            <td>访问量:</td>
            <%--<td><%=StatisticsManager.GetStatistics().VisitCount %> 次</td>--%>
            <td></td>
        </tr>
        
        <tr class="row">
            <td>数据库:</td>
            <td><%=DbPath %> (<%=DbSize%>)</td>
        </tr>
         <tr class="row">
            <td>附件:</td>
            <td><%=UpfilePath %> (共<%=UpfileCount%> 个, <%=UpfileSize%>)</td>
        </tr>
         <tr class="row">
            <td>程序目录:</td>
            <td><%= Request.PhysicalApplicationPath%></td>
        </tr>
        <tr class="category">
            <td>服务器信息</td>
            <td ></td>
        </tr>       
         <tr class="row">
            <td>CPU:</td>
            <td><%=CPUInfo %></td>
        </tr>
         <tr class="row">
            <td>操作系统:</td>
            <td><%=OSVersion%></td>
        </tr>
         <tr class="row">
            <td>.NET 版本:</td>
            <td><%=NETVersion%></td>
        </tr>
         <tr class="row">
            <td>IIS 版本:</td>
            <td><%=IISVersion%></td>
        </tr>
         <tr class="row">
            <td>内存占用:</td>
            <td><%=MemoryInfo%></td>
        </tr>
        <tr class="rowend">
            <td>服务器IP:</td>
            <td><%=Request.ServerVariables["LOCAl_ADDR"]%></td>
        </tr>
       
    </table>
</div>
</asp:Content>
