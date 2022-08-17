<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Devolucion.aspx.cs" Inherits="webBiblioteca.Devolucion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="DEVOLUCION"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Id Libro:"></asp:Label>
            <asp:TextBox ID="txIdLibro" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Clave Unica:"></asp:Label>
            <asp:TextBox ID="txClaveU" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Fecha Actual:"></asp:Label>
            <asp:TextBox ID="txFechaActual" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbStatus" runat="server" Text="Status"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Devolver libro" OnClick="Button1_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="&lt;-- Regresar" />
        </div>
    </form>
</body>
</html>
