<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestamo.aspx.cs" Inherits="webBiblioteca.Prestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label5" runat="server" Text="PRESTAMO"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="idLibro:"></asp:Label>
            <asp:TextBox ID="txIdLibro" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Clave Unica:"></asp:Label>
            <asp:TextBox ID="txClaveUnica" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Fecha Prestamo:"></asp:Label>
            <asp:TextBox ID="txFechaP" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Pedir prestado" OnClick="Button1_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="&lt;-- Regresar" />
            &nbsp;&nbsp;
            <asp:Button ID="btPrestamos" runat="server" OnClick="btPrestamos_Click" Text="Mis Prestamos" />
            <br />
            <br />
            <asp:GridView ID="gvPrestamos" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="lbStatus" runat="server" Text="Status"></asp:Label>
            <br />
            <asp:Label ID="lbFechaE" runat="server" Text="La fecha de entrega es:"></asp:Label>
        </div>
    </form>
</body>
</html>
