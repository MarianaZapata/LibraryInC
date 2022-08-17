<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="webBiblioteca.Catalogo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="CATALOGO"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Nombre Libro:"></asp:Label>
&nbsp;<asp:TextBox ID="txNombreLibro" runat="server"></asp:TextBox>
            <asp:Button ID="btBuscarNombre" runat="server" Text="Buscar" OnClick="btBuscarNombre_Click" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Categoria:"></asp:Label>
            <asp:DropDownList ID="ddCategoria" runat="server" Height="16px" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="btBuscarCat" runat="server" Text="Buscar" OnClick="btBuscarCat_Click" />
            <br />
            <br />
            <asp:GridView ID="gvLibros" runat="server">
            </asp:GridView>
            <br />
            Si no aparece nada despues de darle click a &#39;Buscar&#39; no esta ese ejemplar en especifico en la base de datos.<br />
            Si en disponible la caja esta seleccionada ese ejemplar esta prestado.<br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="&lt;-- Regresar" />
        </div>
    </form>
</body>
</html>
