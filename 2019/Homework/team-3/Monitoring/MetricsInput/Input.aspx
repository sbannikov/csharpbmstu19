<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Input.aspx.cs" Inherits="Input" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            Добавление значений
        </h2>
        <div><asp:Label ID="Label1" runat="server" Text="Источник выбросов"></asp:Label></div>
        <div><asp:DropDownList ID="cbxSource" runat="server" OnSelectedIndexChanged="cbxSource_SelectedIndexChanged"></asp:DropDownList></div>
        <div><asp:Label ID="Label2" runat="server" Text="Датчик"></asp:Label></div>
        <div><asp:DropDownList ID="cbxSensor" runat="server" OnSelectedIndexChanged="cbxSensor_SelectedIndexChanged"></asp:DropDownList></div>
        <div><asp:Label ID="Label3" runat="server" Text="Параметр"></asp:Label></div>
        <div><asp:DropDownList ID="cbxMetrics" runat="server" OnSelectedIndexChanged="cbxMetrics_SelectedIndexChanged"></asp:DropDownList></div>
        <div><asp:Label ID="Label4" runat="server" Text="Параметр"></asp:Label></div>
        <div><asp:TextBox ID="tbxMark" runat="server"></asp:TextBox></div>
        <asp:Button runat="server" Text="Сохранить" OnClick="OnClick"/>
    </form>
</body>
</html>
