<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="GalleryAPP.admin.register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>用户注册</title>
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
    <script type="text/javascript">
        $(function () {
           // $("input[class*=:required]").after("<span> *</span>")
        });

        function dopostback() {
            var md5pwd = MD5($("#pwd").val());
            if (md5pwd != undefined) {
                $("#pwd").val(md5pwd);
                $("#cfmpwd").val(md5pwd);
                $("#tigger").val("sigup");
                return true;
            }
            return false;
        }
    </script>
</head>
<body id="register">
    <div id="register-wrapper" class="png_bg">
        <div id="register-top">
            <h1>
                注册新用户</h1>
        </div>
        <div id="register-content">
            <form id="registerForm" runat="server">
            <asp:HiddenField ID="tigger" runat="server" />
            <div class="notification information png_bg">
                <div>
                    请仔细填写以下项目并提交注册.
                </div>
                <div id="nameempty" style="display: none">
                    用户名不能为空.
                </div>
                <div id="passnotempty" style="display: none">
                    密码不能为空.
                </div>
                 <div id="passnotcofm" style="display: none">
                    两次密码不一致.
                </div>
                <div id="emailempty" style="display: none">
                    请填写电子邮件地址.
                </div>
                <div id="emailvialed" style="display: none">
                    电子邮件地址错误.
                </div>
                <div id="iusag" style="display: none">
                    您必须接受用户协议才能享受我们的服务.
                </div>
            </div>
            <p>
                <label>
                    用户名</label>
                    <input id="username" class="text-input :ajax;checkuser.aspx;;nameempty :required;;nameempty :wait;2000" type="text" runat="server" />
            </p>
            <div class="clear">
            </div>
            <table width="100%">
                <tr>
                    <td>
                        <p>
                            <label>
                                密码</label>
                            <input id="pwd" class="text-input :required;;passnotempty :wait;1000" type="password" runat="server" />
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>
                            <label>
                                密码重复</label>
                            <input name="cfmpwd" id="cfmpwd" class="text-input :required;;passnotempty :same_as;pwd;passnotcofm :wait;1000" type="password" />
                        </p>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
            <p>
                <label>
                    电子邮箱</label>
                <input name="email" id="email" class="text-input :ajax;checkuser.aspx;;emailempty :required;;emailempty :email;;emailvialed :wait;1000" type="text" runat="server" />
            </p>
            <div class="clear">
            </div>
            <p id="remember-password">
                <input type="checkbox" id="agree" class=":accept;;iusag :only_on_submit" />
                已阅读并《接受使用协议》
            </p>
            <div class="clear">
            </div>
            <p>
                <input class="button" type="submit" value="注册!" onclick="dopostback();" />
            </p>
            </form>
        </div>
    </div>
</body>
</html>
