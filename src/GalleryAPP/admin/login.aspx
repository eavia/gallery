<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GalleryAPP.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>用户登录</title>
    <link href="resources/css/reset.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="resources/css/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="resources/css/invalid.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="resources/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="resources/scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="resources/scripts/simpla.jquery.configuration.js"></script>
    <script type="text/javascript" src="resources/scripts/facebox.js"></script>
    <script type="text/javascript" src="resources/scripts/jquery.wysiwyg.js"></script>
    <script type="text/javascript" src="resources/scripts/safe.js"></script>
    <script type="text/javascript" src="resources/scripts/vanadium-min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.uniform.js"></script>
    <script type="text/javascript">
        function checkLoginForm() {
            $("#notification").css("display", "block");
        }

        function dopostback() {
            var md5pwd = MD5($("#password").val());
            if (md5pwd != undefined) {
                $("#password").val(md5pwd);
                $("#tigger").val("login");
                return true;
            }
            return false;
        }
    </script>
</head>
<body id="login">
    <div id="login-wrapper" class="png_bg">
        <div id="login-top">
            <h1>
                请登录：</h1>
            <a href="#">
                <img id="logo" src="resources/images/logo.png" alt="Simpla Admin logo" /></a>
        </div>
        <div id="login-content">
            <form id="loginForm" runat="server">
            <div class="notification information png_bg" id="notification" style="display: none">
                <div id="nameempty" style="display: none">
                    用户名不能为空.
                </div>
                <div id="passnotempty" style="display: none">
                    密码不能为空.
                </div>
            </div>
            <p>
                <label>
                    用户名</label>
                <input id="username" class="text-input :required;;nameempty" type="text" runat="server" />
            </p>
            <div class="clear">
            </div>
            <p>
                <label>
                    密 码</label>
                <input id="password" class="text-input :required;;passnotempty" type="password" runat="server" />
            </p>
            <div class="clear">
            </div>
            <p id="remember-password">
                <input id="rember" type="checkbox" />记住我的密码</p>
            <div class="clear">
            </div>
            <p>
                <input class="button" type="submit" onclick="return dopostback();" value="登 录" />
                <asp:Label ID="lblMessage" runat="server"  ForeColor="#FF5050"></asp:Label>
            </p>
            <asp:HiddenField ID="tigger" runat="Server" />
            <asp:HiddenField ID="redirect" runat="Server" />
            </form>
        </div>
    </div>
    <script type="text/javascript"  language="javascript">
        $(function () {
            $('input:text').uniform();
        });
    </script>
</body>
</html>
