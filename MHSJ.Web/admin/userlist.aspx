
<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="userlist.aspx.cs" Inherits="MHSJ.Web.admin.userlist" ClientIDMode="Static"%>
<%@ Register TagPrefix="loachs" Namespace="MHSJ.Core.Controls" Assembly="MHSJ.Core" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../common/scripts/jquery.js"></script>
     <h2>用户管理</h2>
 <%=ResponseMessage %>
<div class="left" >
    <table width="100%">
        <tr class="category">
            
            <td>用户名称</td>
            <td>邮箱</td>
            <td>手机</td>
            <td>创建日期</td>
            <%--<td>操作</td>--%>
        </tr>
        <asp:Repeater ID="rptUserList" runat="server">
            <ItemTemplate>
                <tr class="row">
                    
                    <td><%# DataBinder.Eval(Container.DataItem, "Name")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Email")%></td>
                    
                    <td><%# DataBinder.Eval(Container.DataItem, "Phone")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "State").ToString() == "1" ? "<img src=\"../common/images/admin/yes.gif\" title=\"完成\"/>" : "<img src=\"../common/images/admin/no.gif\" title=\"未完\"/>"%></td>--%>
                    <td><%# Convert.ToDateTime( DataBinder.Eval(Container.DataItem, "CreateDate")).ToString("yyyy-MM-dd")%></td>
                    
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <loachs:Pager id="Pager1" runat="server" PageSize="22"  CssClass="pager"></loachs:Pager>
</div>
</asp:Content>
