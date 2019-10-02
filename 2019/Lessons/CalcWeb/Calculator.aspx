<%@ Page Title="Калькулятор" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="CalcWeb.Calculator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="Indicator" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button7" runat="server" Text="7" Font-Size="XX-Large" OnClick="Button_Click" />
    <asp:Button ID="Button8" runat="server" Text="8" Font-Size="XX-Large" OnClick="Button_Click" />
    <asp:Button ID="Button9" runat="server" Text="9" Font-Size="XX-Large" OnClick="Button_Click" />
    <br />
    <asp:Button ID="Button4" runat="server" Text="4" Font-Size="XX-Large" OnClick="Button_Click" />
    <asp:Button ID="Button5" runat="server" Text="5" Font-Size="XX-Large" OnClick="Button_Click" />
    <asp:Button ID="Button6" runat="server" Text="6" Font-Size="XX-Large" OnClick="Button_Click" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="1" Font-Size="XX-Large" OnClick="Button_Click" />
    <asp:Button ID="Button2" runat="server" Text="2" Font-Size="XX-Large" OnClick="Button_Click" />
    <asp:Button ID="Button3" runat="server" Text="3" Font-Size="XX-Large" OnClick="Button_Click" />
    <br />
    <asp:Button ID="Button0" runat="server" Text="0" Font-Size="XX-Large" OnClick="Button_Click" />
    <br />
    <asp:Button ID="ButtonPlus" runat="server" Text="+" Font-Size="XX-Large"  />
    <asp:Button ID="ButtonResult" runat="server" Text="=" Font-Size="XX-Large" />


</asp:Content>
