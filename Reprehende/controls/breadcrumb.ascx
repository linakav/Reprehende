<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="breadcrumb.ascx.cs" Inherits="Reprehende.breadcrumbControl" %>
<asp:Repeater ID="BreadcrumbRepeater" runat="server" OnItemDataBound="BreadcrumbRepeater_ItemDataBound">
    <HeaderTemplate>
        <aside>
            <nav>
                <ul class="breadcrumb_wrapper">
    </HeaderTemplate>
    <ItemTemplate>
        <li id="BreadcrumbLi" runat="server" class="breadcrumb_item">
            <asp:HyperLink id="BreadcrumbLink" runat="server" Visible="false" />
        </li>
    </ItemTemplate>
    <FooterTemplate>
                </ul>
            </nav>
        </aside>
    </FooterTemplate>
</asp:Repeater>
