<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="document.aspx.cs" Inherits="Reprehende.document" %>
<%@ Register TagPrefix="uc" TagName="Breadcrumb" Src="/controls/breadcrumb.ascx" %>
<%@ Register TagPrefix="uc" TagName="LeftMenu" Src="/controls/leftMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_wrapper">
        <uc:Breadcrumb id="BreadcrumbControl" runat="server"/>
        <div class="main_content_wrapper clearfix">
            <uc:LeftMenu id="LeftMenuControl" runat="server"/>
            <div class="inner_content_wrapper">
                <div id="BannerContainer" runat="server" Visible="false" class="banner_wrapper clearfix">
                    <div class="banner_background">
                    </div>
                    <div class="banner_img">
                        <asp:Image ID="BannerImage" runat="server" width="290" height="180"/>
                    </div>
                </div>
                <div class="main_text_wrapper">
                    <h1 id="DocumentTitle" visible="false" runat="server" class="main_text_title"/>
                    <div class="main_text">
                        <asp:Literal id="DocumentText" runat="server"/>
                    </div>
                </div>
            </div>
        </div>
    </div><!-- End content_wrapper -->
</asp:Content>
