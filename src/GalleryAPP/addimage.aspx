<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="addimage.aspx.cs" Inherits="GalleryAPP.filemanager.AddImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript" language="javascript"></script>
    <script src="uploadify/jquery.uploadify.v2.1.4.min.js" type="text/javascript" language="javascript"></script>
    <script src="uploadify/swfobject.js" type="text/javascript" language="javascript"></script>
    <script type="text/javascript">
// <![CDATA[
        $(document).ready(function () {
            var pathPerfx = '';
            $('#file_upload').uploadify({
                'uploader': pathPerfx+'uploadify/uploadify.swf',
                'script': pathPerfx + 'ImageTools/push.ashx',
                'scriptData': { 'uid': '<%=this.CurrentAccount.Id%>' }, 
                'cancelImg': pathPerfx + 'uploadify/cancel.png',
                'folder': '/uploads',
                'fileExt': '*.jpg;*.png;*.bmp',
                'fileDesc': '选择 *.jpg,*.png,*.bmp;',
                'multi': true,
                'auto': true

            });
        });
// ]]>
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width:99%; height:450px; overflow:hidden; margin:1 1 1 1; padding:5 5 5 5">
    <input id="file_upload" type="file" name="file_upload" />
    </div>
</asp:Content>
