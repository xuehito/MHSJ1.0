<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="fromlist.aspx.cs" Inherits="MHSJ.Web.admin.admin_fromlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>出处管理</h2>
 <%=ResponseMessage %>
<div class="right">
    <h4>添加出处</h4>
    <p>
        <label class="label" for="<%=txtFromName.ClientID %>">名称:<span class="small gray"></span></label>
        <asp:TextBox ID="txtFromName"    MaxLength="50"  runat="server" Width="96%"  CssClass="text" ></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtFromAliases.ClientID %>">别名:</label>
        <asp:TextBox ID="txtFromAliases"   MaxLength="50"  runat="server" Width="96%" CssClass="text" ></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtDescription.ClientID %>">描述:<span class="small gray"></span></label>
        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" 
            Width="96%" CssClass="text" ></asp:TextBox>
    </p>
    <p><label class="label" for="<%=txtDisplayOrder.ClientID %>">排序:</label><asp:TextBox ID="txtDisplayOrder" runat="server" Width="50" CssClass="text"></asp:TextBox>
        <span class="m_desc">越小越靠前</span>
    </p>
     <p>
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="添加"  CssClass="button"/>
     </p>
</div>
<div class="left" >
    <table width="100%">
        <tr class="category">
            <td>排序</td>
            <td>名称</td>
            <td>别名</td>
            <td>创建日期</td>
            <td>操作</td>
        </tr>
        <asp:Repeater ID="rptUser" runat="server">
            <ItemTemplate>
                <tr class="row">                 
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Displayorder")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "FromName")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "FromAliases")%>
                    </td>
                    
                    <td><%# Convert.ToDateTime( DataBinder.Eval(Container.DataItem, "CreateDate")).ToString("yyyy-MM-dd")%></td>
                    <td><a href="fromlist.aspx?operate=update&FromId=<%# DataBinder.Eval(Container.DataItem, "FromId")%>">编辑</a> <a href="fromlist.aspx?operate=delete&FromId=<%# DataBinder.Eval(Container.DataItem, "FromId")%>" onclick="return confirm('确定要删除吗?');">删除</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
</asp:Content>
