<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Betalen.aspx.cs" Inherits="WoningstichtingBergenTerblijt.Betalen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholdercontent" runat="server">
    <form id="form1" runat="server">
        <div>
           Na betaling van het inschrijfgeld is de registratie voltooid en wordt het inschrijvingsformulier opgestuurd naar de woningstichting.
        <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Te betalen bedrag:"></asp:Label><br />
            € <asp:TextBox ID="tbAmount" ReadOnly="True" runat="server" Width="16px">45</asp:TextBox><br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Kies uw bank:"></asp:Label><br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList><br/><br/>
            <hr />
            <br/>
            <asp:Button ID="btnStart" runat="server" Text="Start betaling" OnClick="btnStart_Click" />
        </div>
    </form>
</asp:Content>
