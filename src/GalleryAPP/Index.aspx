<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GalleryAPP.Index" %>

<%@ Import Namespace="Ext.Net.Utilities" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Desktop</title>
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
                                <ext:SplitButton ID="SplitButton1" runat="server" Text="Menu Button" IconCls="add16">
                                    <Menu>
                                        <ext:Menu ID="Menu1" runat="server">
                                            <Items>
                                                <ext:MenuItem ID="MenuItem1" runat="server" Text="Menu Item 1" />
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:SplitButton>
                                <ext:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/clock_48.png" OverImageUrl="images/clock_48.png"
                                    DisabledImageUrl="images/clock_48.png" PressedImageUrl="images/clock_48.png" Width="15px" Height="15px">
                                    <DirectEvents>
                                        <Click OnEvent="Button_Click" />
                                    </DirectEvents>
                                </ext:ImageButton>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                </ext:Panel>
                <ext:Panel ID="Panel2" runat="server" Title="West" Region="West" Layout="AccordionLayout"
                    Width="228" MinWidth="228" MaxWidth="228" Split="true" Collapsible="false">
                    <Items>
                        <ext:Panel ID="Panel3" runat="server" Title="Navigation" Border="false" BodyPadding="6"
                            Icon="FolderGo" Html="West" />
                        <ext:Panel ID="Panel4" runat="server" Title="Settings" Border="false" BodyPadding="6"
                            Icon="FolderWrench" Html="Some settings in here" />
                    </Items>
                </ext:Panel>
                <ext:TabPanel ID="TabPanel1" runat="server" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel5" runat="server" Title="Center" Border="false" BodyPadding="6"
                            Html="<h1>Viewport with BorderLayout</h1>" />
                        <ext:Panel ID="Panel6" runat="server" Title="Close Me" Closable="true" Border="false"
                            BodyPadding="6" Html="Closeable Tab" />
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
