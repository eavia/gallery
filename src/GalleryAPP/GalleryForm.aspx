<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GalleryForm.aspx.cs" Inherits="GalleryAPP.GalleryForm" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相册信息</title>
    <script type="text/javascript">
        var GB_ROOT_DIR = "./greybox/"; //注意这里的路径！！！
    </script>
    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <script src="artDialog/artDialog.js" type="text/javascript"></script>
    <link href="artDialog/skins/default.css" rel="stylesheet" />
    <script src="artDialog/iframeTools.js" type="text/javascript"></script>
</head>
<body id="formBody" onload="ScrollToSelectNode()">
    <form id="GalleryForm" runat="server" onsubmit="bindData()">
    <div>
        <table style="width: 100%;">
            <tr>
                <td width="99px">
                    相册名称
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="99%"></asp:TextBox>
                </td>
                <td width="50px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                        ErrorMessage="*" Width="99%">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    相册说明
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="99%"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" OnClientClick="reload();" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" OnClientClick="reload();"
                        CausesValidation="False" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="#" title="上传图片" onclick="showUploader();">上传图片</a>
                    <asp:HiddenField ID="galleryid" runat="server" />
                    <input runat="server" id="divScrollValue" type="hidden" value="" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table style="width: 99%">
                        <tr>
                            <td>
                                <div id="main" style="padding: 5px 5px 5px 5px; display: block">
                                    <table width="99%">
                                        <tr>
                                            <td>
                                                <asp:DataList ID="photoList" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                    HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <table width="200px" border="0">
                                                            <tr style="height: 200px">
                                                                <td style="height: 200px; border: 1px solid">
                                                                    <div style="width: 99%; height: 99%; position: static; display: block">
                                                                        <div style="position: absolute; margin: 3px 3px 80px 172px; width: 18px; height: 18px">
                                                                            <asp:ImageButton ID="ibnRemove" ImageUrl="~/uploadify/cancel.png" runat="Server"
                                                                                CommandArgument='<%#Eval("ID") %>' CommandName="remove" OnCommand="ibnRemove_Command" />
                                                                        </div>
                                                                        <a href='<%#"ImageTools/FetchImage.ashx?id="+Eval("ID")+"&thumbnail=false"%>'>
                                                                            <asp:Image ID="imagethumbail" runat="server" src='<%#"ImageTools/FetchImage.ashx?id="+Eval("ID")+"&thumbnail=true"%>' /></a>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="99%">
                                        <tr>
                                            <td>
                                                <webdiyer:AspNetPager ID="pager" runat="server" AlwaysShow="true" PageSize="20" CurrentPageButtonPosition="Center"
                                                    OnPageChanged="pager_PageChanged">
                                                </webdiyer:AspNetPager>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript" language="javascript">
        function reload() {
            parent.parent.location.reload();
            parent.parent.GB_hide();
        }

        function showUploader() {
            var uploaderURL = "uploader.aspx?gid=" + document.getElementById('galleryid').value;
            art.dialog.open(
                uploaderURL,
                {
                    title: '上传图片',
                    lock: true,
                    id: 'Uploader',
                    fixed: true,
                    resize: false,
                    drag: false
                }
                );
        }
        //刷新时滚动条保留位置
        function ScrollToSelectNode() {
            document.getElementById("formBody").scrollTop = "<%=ScrollValue%>";
        }

        function bindData() {
            document.getElementById("divScrollValue").value = document.getElementById("formBody").scrollTop;
        }
    </script>
</body>
</html>
