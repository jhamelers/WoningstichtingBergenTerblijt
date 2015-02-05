<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MollieIdealSample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test iDEAL</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Te betalen bedrag:"></asp:Label><br />
        <asp:TextBox ID="tbAmount" runat="server">10,00</asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Kies uw bank:"></asp:Label><br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <hr />
        <asp:Button ID="btnStart" runat="server" Text="Start betaling" />
    </div>
    </form>
</body>
</html>
