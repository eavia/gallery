<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploader.aspx.cs" Inherits="GalleryAPP.Uploader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script src="scripts/utils.js" type="text/javascript"></script>
    <script src="scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="scripts/jquery.form.js" type="text/javascript"></script>
    <script src="scripts/jquery.MetaData.js" type="text/javascript"></script>
    <script src="scripts/jquery.MultiFile.js" type="text/javascript"></script>
    <script src="scripts/jquery.uniform.js" type="text/javascript"></script>
    <link href="styles/uniform.default.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="artDialog/jquery.artDialog.js" type="text/javascript"></script>
    <script src="artDialog/iframeTools.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $('#PortugueseFileUpload').MultiFile({
                accept: 'gif|jpg|png|jpeg',
                list: '#fileList',
                STRING: {
                    file: '<em title="Click to remove" onclick="$(this).parent().prev().click()">$file</em>',
                    remove: '<img src="uploadify/cancel.png" height="18" width="18" alt="x"/>',
                    selected: '选择的文件: $file',
                    denied: '不合法的后缀名 $ext!',
                    duplicate: '文件已经选定:\n$file!'
                }
            });
            $('#btnCommit').uniform();
            resetControlStyle();
        });
        function getFocus() {
            document.getElementById('btnCommit').focus();
            resetControlStyle();
        }

        function resetControlStyle() {
            $('input[type="file"]').each(function (arg) {
                $(this).addClass('fileControl');
            })
        }
        function onFileClieck() {
            var linkObj = $('#fileholder input[type="file"]:first');
            linkObj.trigger('click');
        }
        
    </script>
    <style>
		.fileControl{
			opacity: 0;
			filter:alpha(opacity=0);
			cursor: pointer;
			display: block;
			height: 40px;
			position: absolute;
			width: 320px;

			font-size: 30px;
			left: -170px;
			top: -8px;
		}
		@-moz-document url-prefix() { .fileControl{
			left: -355px;
			width: 190px;
		}
		}

		.upload-select-btn{
			background: url(/images/cmd-upload.png) no-repeat;
			width: 73px;
			height: 26px;
			display: block;
			overflow: hidden;
			margin-bottom: 2px 2px 2px 2px;
			cursor: pointer;
			outline: none;

			position: relative;
		}
		.upload-select-btn:hover{
			background-position: 0 -28px;
		}
		.upload-select-btn:active{
			background-position: 0 -56px;
		}
	</style>
</head>
<body>
    <form id="fileUploaderForm" name="fileUploaderForm" method="post" action="" enctype="multipart/form-data" runat="server">
    <input type="hidden" id="userid" name="userid" value='<%=STRUSERID %>' />
    <div id="fileUploader" style="width: 300px; background-color: Menu;">
        <table id="FileButtons" style="width: 100%; background-color: White;">
            <tr style="height: 40px; vertical-align: middle;">
                <td style="width: 30%; text-align: left;">
                    <a id="fileholder" href="javascript:;" class="upload-select-btn">
                        <input id="PortugueseFileUpload" name="PortugueseFileUpload" type="file" onchange="getFocus();" />
                    </a>
                </td>
                <td style="width: 70%; text-align: right;">
                    <input id="btnCommit" type="submit" value="保存" />
                </td>
            </tr>
        </table>

        <div id="fileList" style="background-color: Menu;">
    </div>
    </form>
    <script type="text/javascript">
        var url = "ImgReceiver.ashx?gid=" + getQueryStringByName("gid") + "&uid=" + document.getElementById("userid").value;
        document.fileUploaderForm.attributes["action"].value = url;
    </script>
</body>
</html>
