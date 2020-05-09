<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ClientForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function NumericText() {
            var key = window.event.keyCode;
            if ((key < 48 || key > 57) & key != 8 & key != 190)
                window.event.returnValue = false;
            else document.getElementById("label1").textContent = "";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">


        <div>

            <label>Источник выбросов</label>
            <br />
            <asp:ImageButton ID="Image0" Width="120px" runat="server" OnClick="Img0_Click" CssClass="myimage" ImageUrl="https://image.flaticon.com/icons/svg/2544/2544453.svg" />
            <asp:ImageButton ID="Image1" Width="120px" runat="server" OnClick="Img1_Click" CssClass="myimage" ImageUrl="https://image.flaticon.com/icons/svg/2544/2544426.svg" />

        </div>


        <div>
            <label>Датчик </label>
            <asp:DropDownList ID="DropDownList1" Width="250 px" AutoPostBack="True" OnSelectedIndexChanged="Selection_Change1" runat="server">
                <%--CssClass="mydropdownlist" --%>
            </asp:DropDownList>
        </div>


        <div>
            <label>Параметр </label>
            <asp:RadioButtonList ID="RadioButtonList0" AutoPostBack="True" OnSelectedIndexChanged="Selection_Change2" runat="server" />
        </div>

        <div>
            <label>Значение </label>

            <asp:TextBox ID="Text1" onkeydown="NumericText()" Width="120 px" runat="server" />
            <asp:DropDownList ID="DropDownListState" Width="120 px" runat="server">
                <asp:ListItem Selected="True"> OK </asp:ListItem>
                <asp:ListItem> ERROR </asp:ListItem>
                <asp:ListItem> MAINTENANCE </asp:ListItem>
            </asp:DropDownList>
            <label><%= parameters[RadioButtonList0.SelectedIndex].Unit.ToString() %> </label>
            <asp:Label ID="label1" runat="server" />

        </div>
        <div>
            <asp:Button ID="Add" Text="Сохранить" OnCommand="SaveData" runat="server" />
        </div>

        <asp:Label ID="labelhelp" runat="server" />


    </form>
</body>
</html>
