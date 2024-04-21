<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaUsuario.aspx.cs" Inherits="Proyecto_Rest_Minor.CSU.ConsultaUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgUsuario" runat="server" />
            <br />
        </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Titulo"></asp:Label>
            <asp:TextBox ID="TxtTitulo" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label>
        <asp:TextBox ID="TxtNombres" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
        <asp:TextBox ID="TxtApellidos" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="TxtUsuario" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Contraseña"></asp:Label>
        <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="BtnConsultar" runat="server" OnClick="BtnConsultar_Click" Text="Consultar" />
        </p>
    </form>
</body>
</html>
