<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GalleryAPP.Index" %>

<%@ Import Namespace="Ext.Net.Utilities" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Desktop</title>
       <script type="text/javascript">

           var treeCliked = function (treePanel) {
               var nodeClicked = treePanel.getSelectedNodes();
               if (nodeClicked==undefined) {
                   return false;
               }
           }

           var addTab = function (tabPanel,id, url) {
               var tab = tabPanel.getComponent(id);
               if (!tab) {
                   tab = tabPanel.add({
                       id: id,
                       title: url,
                       closable: true,
                       autoLoad: {
                           showMask: true,
                           url: url,
                           mode: "iframe",
                           maskMsg: "Loading " + url + "..."
                       }
                   });

                   tab.on("activate", function () {

                   }, this);
               }

               tabPanel.setActiveTab(tab);
           }

    </script>
</head>
<body>
    <form id="MainFrm" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Region="North" Split="false" Height="150" BodyPadding="6"
                    StyleSpec="text-align:center" BodyStyle="background:url(images/background.png) 0 0 repeat;"
                    Html='<img src="images/header.jpg" alt="hd" />'>
                    <BottomBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" EnableOverflow="true">
                            <Items>
                                <ext:Label ID="lblTitle" runat="server" Text="Welcome, " />
                                <ext:Label ID="lblUserName" runat="server" Text="Guest!" />
                                <ext:Button ID="btnLoginStart" runat="server" Text="Login" Icon="Lock">
                                    <Listeners>
                                        <Click Handler="LoginWin.show()" />
                                    </Listeners>
                                </ext:Button>
                                <ext:SplitButton ID="sbnMainMenu" runat="server" Text="I want..." Icon="House" Hidden="true">
                                    <Menu>
                                        <ext:Menu ID="Menu1" runat="server">
                                            <Items>
                                                <ext:MenuItem ID="MenuItem1" runat="server" Text="Menu Item 1" />
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:SplitButton>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                </ext:Panel>
                <ext:Panel ID="Panel2" runat="server" Region="West" Layout="AccordionLayout" Width="228"
                    MinWidth="228" MaxWidth="228" Split="true" Collapsible="false">
                    <Items>
                        <ext:TreePanel ID="TreePanel1" runat="server" EnableDD="true" DDGroup="grid2tree"
                            Width="300" AutoScroll="true" Collapsible="true" Title="Navigation" Border="false"
                            BodyPadding="6" Icon="FolderGo">
                            <Loader>
                                <ext:PageTreeLoader OnNodeLoad="NodeLoad">
                                    <BaseParams>
                                        <ext:Parameter Name="prefix" Value="(#{TreePanel1}).getSelectedNodes().nodeID" Mode="Raw" />
                                    </BaseParams>
                                </ext:PageTreeLoader>
                            </Loader>
                            <Root>
                                <ext:AsyncTreeNode NodeID="0" Text="Root" />
                            </Root>
                            <Listeners>
                                  <Click Handler="treeCliked(#{TreePanel1})" />
                            </Listeners>
                        </ext:TreePanel>
                        <ext:Panel ID="Panel4" runat="server" Title="Settings" Border="false" BodyPadding="6"
                            Icon="FolderWrench" Html="Some settings in here" />
                    </Items>
                </ext:Panel>
                <ext:TabPanel ID="TabPanel1" runat="server" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel5" runat="server" Title="Center" Border="false" BodyPadding="6"
                            Html="<h1>Viewport with BorderLayout</h1>" />
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </div>
    <ext:Window ID="LoginWin" runat="Server" Closable="false" Resizable="false" Height="150"
        Icon="Lock" Title="Login" Draggable="false" Width="350" Modal="true" Padding="5"
        Layout="Form">
        <Items>
            <ext:TextField ID="txtUsername" runat="server" FieldLabel="Username" AllowBlank="false"
                BlankText="Your username is required." Text="Demo" AnchorHorizontal="100%" />
            <ext:TextField ID="txtPassword" runat="server" InputType="Password" FieldLabel="Password"
                AllowBlank="false" BlankText="Your password is required." Text="Demo" AnchorHorizontal="100%" />
        </Items>
        <Buttons>
            <ext:Button ID="btnLogin" runat="server" Text="Login" Icon="Accept">
                <DirectEvents>
                    <Click OnEvent="btnLogin_Click">
                        <EventMask ShowMask="true" Msg="Verifying..." MinDelay="500" />
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="btnCancel" runat="server" Text="Cancel" Icon="Decline">
                <Listeners>
                    <Click Handler="#{LoginWin}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
