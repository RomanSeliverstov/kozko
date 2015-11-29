<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBoxLink" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:CheckBox ID="CheckBoxAddFriends" runat="server" Text="Учитывать записи друзей"/>
        <asp:Button ID="Button" runat="server" Text="Запросить" OnClick="Button_Click" />
        <br />
        <br />
        <asp:RadioButton ID="Topweek" Text="Top week" runat="server" Checked="True" GroupName="Group"/>
        <asp:RadioButton ID="Topday" Text="Top day" runat="server" GroupName="Group"/>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Запросить" />
        <br />
        <br />
        Топ записей по городу<br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:Button ID="ButtonCity" runat="server" Text="Запросить" OnClick="ButtonCity_Click" />
        <br />
        <br />
        <asp:TextBox ID="DateStart" runat="server" Om="DateStart_TextChanged">YYYY-MM-DD</asp:TextBox>
        <asp:ImageButton ID="imgPopup" ImageUrl="calendar_icon.png" runat ="server" OnClick="imgPopup_Click" />
        <asp:TextBox ID="DateStop" runat="server">YYYY-MM-DD</asp:TextBox>
    <asp:ImageButton ID="imgPopup2" ImageUrl="calendar_icon.png" runat ="server" OnClick="imgPopup2_Click" />
        <asp:Button ID="DateButton" runat="server" Text="Запросить" OnClick="DateButton_Click" />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false"></asp:Calendar>
        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="false"></asp:Calendar>
        <br />
        <br />
        <asp:GridView ID="GridView" runat="server"></asp:GridView>

        
    </form>
</body>
</html>
