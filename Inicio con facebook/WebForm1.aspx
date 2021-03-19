<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Inicio_con_facebook.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="index.css" rel="stylesheet" type="text/css" />
    <title>Inicio de sesion</title>
</head>
<body>
    <div class="login">
	    <h1>Login</h1>
        <form method="post">
    	    <input type="text" name="u" placeholder="Username" required="required" />
            <input type="password" name="p" placeholder="Password" required="required" />
            <button onclick="alertar('You Shall not pass');" type="submit" class="btn btn-primary btn-block btn-large" >Let me in.</button>
        </form>
        <br />
        <form id="form1" runat="server">
            <div>
                <asp:Button type="submit" class="btn btn-primary btn-block btn-large" ID="Button1" runat="server" OnClick="Button1_Click" Text="Iniciar Sesion - Facebook" />
            </div>
        </form>
    </div>
</body>
<script type="text/javascript">
    function alertar(texto) {
       alert(texto);
    }
</script>
</html>
