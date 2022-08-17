<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="webBiblioteca.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
&nbsp;<asp:TextBox ID="txUsuario" runat="server"></asp:TextBox>
&nbsp;<div>
            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
&nbsp;<asp:TextBox ID="txContra" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Fecha Actual"></asp:Label>
&nbsp;<asp:TextBox ID="txFecha" runat="server">mm/dd/aaaa</asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Siguiente" />
            <br />
            <br />
            <br />
            <asp:Label ID="lbStatusConexion" runat="server" Text="Status Conexion"></asp:Label>
        </div>
    </form>
</body>
</html>
