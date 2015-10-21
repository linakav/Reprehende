<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="leftMenu.ascx.cs" Inherits="Reprehende.leftMenuControl" %>
<aside class="left_menu_wrapper">
    <nav>
        <ul>
            <li>
                <asp:HyperLink ID="LeftMenuTitleLink" runat="server" CssClass="left_menu_title"/>
                <asp:Repeater ID="LeftMenuRepeater" runat="server" OnItemDataBound="LeftMenuRepeater_ItemDataBound">
                    <HeaderTemplate>
                        <ul class="left_menu_categories">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li id="LeftMenuLi" runat="server" class="left_menu_item">
                            <asp:HyperLink ID="LeftMenuLink" runat="server">
                                <asp:Literal  ID="LeftMenuLinkText" runat="server" />
                                <asp:Label ID="LeftMenuOpenSpan" runat="server" Visible="false" CssClass="open_close">+</asp:Label>
                            </asp:HyperLink>
                            <asp:Repeater ID="SecondLevelRepeater" runat="server" Visible="false" OnItemDataBound="SecondLevelRepeater_ItemDataBound">
                                <HeaderTemplate>
                                    <ul class="left_menu_categories">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li id="LeftMenuLi" runat="server" class="left_menu_item">
                                        <asp:HyperLink ID="LeftMenuLink" runat="server"/>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </li>
        </ul>
    </nav>
</aside>