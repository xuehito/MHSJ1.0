<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="linklist.aspx.cs" Inherits="MHSJ.Web.admin.linklist" ClientIDMode="Static"%>
<%@ Register TagPrefix="loachs" Namespace="MHSJ.Core.Controls" Assembly="MHSJ.Core" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../common/scripts/jquery.js"></script>
     <h2>友链管理</h2>
 <%=ResponseMessage %>
    <div class="right">
    <h4>添加友链</h4>
    <p>
        <label class="label" for="<%=txtName.ClientID %>">名称:<span class="small gray"></span></label>
        <asp:TextBox ID="txtName"    MaxLength="50"  runat="server" Width="96%"  CssClass="text" ></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtUrl.ClientID %>">Url:</label>
        <asp:TextBox ID="txtUrl"   MaxLength="50"  runat="server" Width="96%" CssClass="text" ></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtTypeName.ClientID %>">类型:<span class="small gray"></span></label>
        <asp:TextBox ID="txtTypeName" MaxLength="50"  runat="server" 
            Width="96%" CssClass="text"  ></asp:TextBox>
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
            <td>Url</td>
            <td>类型</td>
            <td>创建日期</td>
            <td>操作</td>
        </tr>
        <asp:Repeater ID="rptLinks" runat="server">
            <ItemTemplate>
                <tr class="row">
                    
                    <td><%# DataBinder.Eval(Container.DataItem, "DisplayOrder")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Name")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Url")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "TypeName")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "State").ToString() == "1" ? "<img src=\"../common/images/admin/yes.gif\" title=\"完成\"/>" : "<img src=\"../common/images/admin/no.gif\" title=\"未完\"/>"%></td>--%>
                    <td><%# Convert.ToDateTime( DataBinder.Eval(Container.DataItem, "CreateDate")).ToString("yyyy-MM-dd")%></td>
                    <td><a href="linklist.aspx?operate=update&Id=<%# DataBinder.Eval(Container.DataItem, "Id")%>">编辑</a> 
                        <%--<a href="linklist.aspx?operate=delete&Id=<%# DataBinder.Eval(Container.DataItem, "Id")%>" onclick="return confirm('确定要删除吗?');">删除</a></td>--%>
                    
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <loachs:Pager id="Pager1" runat="server" PageSize="15"  CssClass="pager"></loachs:Pager>
</div>
</asp:Content>
