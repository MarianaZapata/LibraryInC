<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="webBiblioteca.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label13" runat="server" Text="MENU"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbInfo" runat="server" Text="La informacion del alumnx es:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Clave Unica:"></asp:Label>
&nbsp;<asp:TextBox ID="txCU" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nombre: "></asp:Label>
&nbsp;<asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Apellido Paterno:"></asp:Label>
&nbsp;<asp:TextBox ID="txApellidoP" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Apellido Materno:"></asp:Label>
&nbsp;<asp:TextBox ID="txApellidoM" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Correo:"></asp:Label>
&nbsp;<asp:TextBox ID="txCorreo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Semestre:"></asp:Label>
&nbsp;<asp:TextBox ID="txSemestre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Programa:"></asp:Label>
&nbsp;<asp:TextBox ID="txPrograma" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Cantidad de prestamos actuales:"></asp:Label>
&nbsp;<asp:TextBox ID="txPrestamosActuales" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Historial de prestamos:"></asp:Label>
&nbsp;<asp:TextBox ID="txHistorialPrestamos" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Multa:"></asp:Label>
&nbsp;<asp:TextBox ID="txMulta" runat="server"></asp:TextBox>
            <br />
&nbsp;<br />
            <br />
            <br />
            <asp:Button ID="btConectar" runat="server" Text="Consultar" OnClick="btConectar_Click" />
&nbsp;&nbsp;
            <asp:Button ID="btPrestamo" runat="server" Text="Prestamo" OnClick="btPrestamo_Click" />
&nbsp;&nbsp;
            <asp:Button ID="btDevolucion" runat="server" Text="Devolucion" OnClick="btDevolucion_Click" />
            <br />
            <br />
            <asp:Button ID="btSalir" runat="server" Text="Salir" Width="283px" OnClick="btSalir_Click" />
        </div>
    </form>
</body>
</html>
