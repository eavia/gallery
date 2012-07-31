<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="GalleryAPP.Gallery" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>相册列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" style="padding: 5px 5px 5px 5px; display: block">
        <asp:DataList ID="photoList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
            HorizontalAlign="Center">
            <ItemTemplate>
                <table width="200px" border="0">
                    <tr style="height:200px">
                        <td style="height: 200px; border:1px solid">
                            <div style="width: 99%; height: 99%; position:static; display:block">
                                <div style="position: absolute; margin: 3px 3px 80px 172px; width: 18px; height: 18px">
                                    <asp:ImageButton ID="imbRemove" ImageUrl="~/uploadify/cancel.png" runat="Server"
                                        CommandArgument='<%#Eval("ID") %>' OnCommand="imbRemove_Command" CommandName="remove" />
                                </div>
                                <asp:Image ID="imagethumbail" runat="server"  src='<%#"ImageTools/FetchImage.ashx?id="+Eval("ID")+"&thumbnail=true"%>' />
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <table width="99%">
        <tr>
        <td> 
            <webdiyer:AspNetPager ID="pager" runat="server" AlwaysShow="true" 
                PageSize="36" CurrentPageButtonPosition="Center" 
                onpagechanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </td>
        </tr>
        </table>
    </div>
</asp:Content>
