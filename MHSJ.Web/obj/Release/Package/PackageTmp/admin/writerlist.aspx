<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="writerlist.aspx.cs" Inherits="MHSJ.Web.admin.admin_writer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>作家管理</h2>
 <%=ResponseMessage %>
<div class="right">
    <h4>添加作家</h4>
    <p>
        <label class="label" for="<%=txtWriterName.ClientID %>">作家名:<span class="small gray"></span></label>
        <asp:TextBox ID="txtWriterName"    MaxLength="50"  runat="server" Width="96%"  CssClass="text" ></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtWriterAliases.ClientID %>">作家别名:</label>
        <asp:TextBox ID="txtWriterAliases"   MaxLength="50"  runat="server" Width="96%" CssClass="text" ></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtDynasty.ClientID %>">朝代:<span class="small gray"></span></label>
        <asp:TextBox ID="txtDynasty"    runat="server" Width="96%" CssClass="text" 
            MaxLength="5" ></asp:TextBox>
    </p>
    <p>
        <label class="label" for="<%=txtDescription.ClientID %>">作家描述:<span class="small gray"></span></label>
        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" 
            Width="96%" CssClass="text" ></asp:TextBox>
    </p>
    <p><label class="label" for="<%=txtDisplayOrder.ClientID %>">排序:</label><asp:TextBox ID="txtDisplayOrder" runat="server" Width="50" CssClass="text"></asp:TextBox>
        <span class="m_desc">越小越靠前</span>
    </p>
    <p>
        <asp:CheckBox ID="chkStatus" runat="server" Text="使用" Checked="true" />
     </p>
     <p>
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="添加"  CssClass="button"/>
     </p>
</div>
<div class="left" >
    <table width="100%">
        <tr class="category">
            <td>排序</td>
            <td>作家名</td>
            <td>别名</td>
            <td>朝代</td>
            <td>状态</td>
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
                        <%# DataBinder.Eval(Container.DataItem, "WriterName")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "WriterAliases")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Dynasty")%>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status").ToString() == "1" ? "<img src=\"../common/images/admin/yes.gif\" title=\"使用\"/>" : "<img src=\"../common/images/admin/no.gif\" title=\"停用\"/>"%></td>
                    <td><%# Convert.ToDateTime( DataBinder.Eval(Container.DataItem, "CreateDate")).ToString("yyyy-MM-dd")%></td>
                    <td><a href="writerlist.aspx?operate=update&Id=<%# DataBinder.Eval(Container.DataItem, "Id")%>">编辑</a> <a href="writerlist.aspx?operate=delete&Id=<%# DataBinder.Eval(Container.DataItem, "Id")%>" onclick="return confirm('确定要删除吗?');">删除</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
</asp:Content>
