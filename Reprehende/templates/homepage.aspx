<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Reprehende.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_wrapper">
        <asp:Panel runat="server" ID="TextBnrPnl" Visible="False" CssClass="home_text_banner clearfix">
            <asp:HyperLink runat="server" ID="TextBnrLnk">
                <asp:Label runat="server" ID="TextBnrTitle" CssClass="title"/>
                <asp:Label runat="server" ID="TextBnrDescription" CssClass="description"/>
            </asp:HyperLink></asp:Panel><!--End e-shop -->
        <div class="center_images clearfix">
            <section class="top_images">
                <asp:Repeater runat="server" ID="TopBannersRptr" OnItemDataBound="TopBannersRptr_ItemDataBound">
                    <HeaderTemplate>
                        <ul class="top_images">
                     </HeaderTemplate>
                    <ItemTemplate>
                        <li runat="server" id="TopBannerLI">
                            <article>
                                <figure>
                                    <asp:Image runat="server" id="TopBannerImg"/>
                                </figure>
                                <div class="text_background">
                                    <header>
                                        <h2 runat="server" id="TopBannerTitle" class="title"></h2>
                                        <h3 runat="server" id="TopBannerSubtitle" class="addresses"></h3>
                                    </header>
                                    <div runat="server" ID="TopBannerDesc" class="description"></div>
                                </div>
                            </article>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Panel ID="TopBigImageBanner" runat="server" CssClass="img img3">
                    <article>
                        <figure>
                            <asp:Image runat="server" id="TopBannerBigImg"/>
                        </figure>
                        <div class="text_background">
                            <header>
                                <h2 runat="server" id="TopBannerBigTitle" class="title"></h2>
                                <h3 runat="server" id="TopBannerBigSubtitle" class="addresses"></h3>
                            </header>
                            <div runat="server" id="TopBannerBigDesc" class="description"/>
                        </div>
                    </article>
                </asp:Panel>
            </section>
            <section class="bottom_images clearfix">
                <div id="owl-demo" class="owl-carousel">
                    <asp:Repeater runat="server" ID="BotBigBnrRptr" OnItemDataBound="BotBigBnrRptr_ItemDataBound">
                        <ItemTemplate>
                            <div class="item img img4">
                                <article>
                                    <figure>
                                        <img runat="server" id="BotBigBnrImg"/>
                                    </figure>
                                    <div class="text_background">
                                        <div class="title">
                                            <span runat="server" id="BotBigBnrDay" class="date"></span>
                                            <span runat="server" id="BotBigBnrMonth" class="month"></span>
                                        </div>
                                        <header class="desc">
                                            <p runat="server" id="BotBigBnrTitle"></p>
                                            <p runat="server" id="BotBigBnrSubTitle"></p>
                                        </header>
                                    </div>
                                </article>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Panel runat="server" id="BotSmallBnrPnl" OnLoad="BotSmallBnrPnl_Load" CssClass="item img img5">
                    <article>
                        <figure>
                            <img runat="server" id="BotSmallBnrImg"/>
                        </figure>
                        <div class="text_background">
                            <div class="title">
                                <span runat="server" id="BotSmallBnrDay" class="date"></span>
                                <span runat="server" id="BotSmallBnrMonth" class="month"></span>
                            </div>
                            <header class="desc">
                                <p runat="server" id="BotSmallBnrTitle"></p>
                                <p runat="server" id="BotSmallBnrSubTitle"></p>
                            </header>
                        </div>
                    </article>
                </asp:Panel>
            </section> <!--End bottom_images -->
        </div> <!--End center_images -->
    </div> <!-- End content_wrapper -->
</asp:Content>
