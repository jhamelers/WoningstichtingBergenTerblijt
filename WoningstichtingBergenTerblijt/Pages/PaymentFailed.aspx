<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="PaymentFailed.aspx.cs" Inherits="WoningstichtingBergenTerblijt.PaymentFailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholdercontent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Er is een fout opgetreden met de Ideal-betaling. Het is goed mogelijk dat er een storing bij uw bank is. Probeer het a.u.b. opnieuw. Klik "></asp:Label><a href="../Pages/Ideal.aspx">hier</a>
    </div>
</asp:Content>
