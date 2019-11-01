<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Altas.aspx.cs" Inherits="Prueba_ex.Altas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Cursos disponibles:<br />
            <asp:DropDownList ID="DDLCursos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCursos_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Horas del curso:<br />
            <asp:Label ID="LbHoras" runat="server" Text="label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Darse de alta" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Reporte" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Lb" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
