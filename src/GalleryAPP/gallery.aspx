<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true"
    CodeBehind="gallery.aspx.cs" Inherits="GalleryAPP.gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- GreyBox引用开始 -->
    <script type="text/javascript">
        var GB_ROOT_DIR = "./greybox/"; //注意这里的路径！！！
    </script>
    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <!-- GreyBox引用结束 -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pelGralleyList" runat="server" Visible="true">
        <table style="width: 100%;">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataList ID="gralleryList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                        HorizontalAlign="Center">
                        <ItemTemplate>
                            <table width="200px" border="0">
                                <tr>
                                    <td>
                                        <a href='GalleryForm.aspx?gid=<%#Eval("ID") %>' onclick="return GB_showPage('<%#Eval("Name") %>', this.href)">
                                            <%#Eval("Name") %></a>
                                    </td>
                                </tr>
                                <tr style="height: 200px">
                                    <td style="height: 200px; border: 1px solid">
                                        <div style="width: 99%; height: 99%; position: static; display: block">
                                            <asp:Image ID="imagethumbail" runat="server" src='<%#"ImageTools/FetchImage.ashx?id="+Eval("Cover")+"&thumbnail=true"%>' />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <textarea id="txtDesc" readonly="readonly" rows="2" cols="1" style="width: 99%"><%#Eval("Description") %></textarea>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
