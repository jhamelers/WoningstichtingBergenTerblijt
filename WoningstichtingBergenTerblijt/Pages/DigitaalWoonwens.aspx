<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="DigitaalWoonwens.aspx.cs" Inherits="WoningstichtingBergenTerblijt.DigitaalWoonwens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholdercontent" runat="server">
    <form id="form1" runat="server">
        <br />
        <div class="cushycms" id="markupform">
            <div>
                <div>
                    <i><b>Woonwens kenbaar maken</b></i>
                </div>
                <div>
                    Gewenste straat/straten selecteren
                </div>
                <br />
                <div class="div_left1">
                    <b>Wijk 1: Berg oude kern</b>
                </div>
                <div class="div_left1">
                    <b>Wijk 2: Grote straat</b>
                </div>
                <div class="div_left1">
                    <b>Wijk 3: Omgeving sporthal</b>
                </div>
                <div class="div_left1">
                    <b>Wijk 4: Vilt</b>
                </div>
                <br />
                <br />
                <div class="div_left1">
                    <u>Eengezinswoningen</u>
                </div>
                <div class="div_left1">
                    <u>Eengezinswoningen</u>
                </div>
                <div class="div_left1">
                    <u>Eengezinswoningen</u>
                </div>
                <div class="div_left1">
                    <u>Eengezinswoningen</u>
                </div>
                <div class="div_left1">
                    <asp:CheckBoxList ID="cbListWijk1EG" runat="server">
                        <asp:ListItem> Dr. Goossensstraat</asp:ListItem>
                        <asp:ListItem> Lange Akker</asp:ListItem>
                        <asp:ListItem> Pastoor Pendersstraat</asp:ListItem>
                        <asp:ListItem> Valkenburgerstraat</asp:ListItem>
                        <asp:ListItem> Geulhemmerweg</asp:ListItem>
                        <asp:ListItem> Klein straat</asp:ListItem>
                        <asp:ListItem> Archivaris Habetsstraat</asp:ListItem>
                        <asp:ListItem> Pastoor Brouwersstraat</asp:ListItem>
                        <asp:ListItem> Pastoor Scheepersstraat</asp:ListItem>
                        <asp:ListItem> Burg. Muytersstraat</asp:ListItem>
                        <asp:ListItem> Blokbrekersstraat</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                    <u>Seniorenwoningen</u>
                    <asp:CheckBoxList ID="cbListWijk1S" runat="server">
                        <asp:ListItem> Rothkransplantsoen</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                    <u>Appartementen/HAT-woningen/Duplex</u>
                    <br />
                    <asp:CheckBoxList ID="cbListWijk1A" runat="server">
                        <asp:ListItem> Langen Akker</asp:ListItem>
                        <asp:ListItem> Geulhemmerweg</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <div class="div_left2">
                    <asp:CheckBoxList ID="cbListWijk2EG" runat="server">
                        <asp:ListItem> Pastoor Halmansstraat</asp:ListItem>
                        <asp:ListItem> Grote Straat</asp:ListItem>
                        <asp:ListItem> Achter de Hoven</asp:ListItem>
                        <asp:ListItem> Proosthof</asp:ListItem>
                        <asp:ListItem> Servaashof</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <div class="div_right1">
                    <asp:CheckBoxList ID="cbListWijk3EG" runat="server">
                        <asp:ListItem> Laathofstraat</asp:ListItem>
                        <asp:ListItem> Op de Dries</asp:ListItem>
                        <asp:ListItem> Koolhof</asp:ListItem>
                        <asp:ListItem> Valkenburgerstraat</asp:ListItem>
                        <asp:ListItem> Fonterstraat</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                    <u>Seniorenwoningen</u>
                    <asp:CheckBoxList ID="cbListWijk3S" runat="server">
                        <asp:ListItem> Laathofstraat</asp:ListItem>
                        <asp:ListItem> Op de Dries</asp:ListItem>
                        <asp:ListItem> Koolhof</asp:ListItem>
                        <asp:ListItem> Valkenburgerstraat</asp:ListItem>
                        <asp:ListItem> Fonterstraat</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                    <u>Aanleunwoningen</u>
                    <asp:CheckBoxList ID="cbListWijk3Al" runat="server">
                        <asp:ListItem> Fonterstraat</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                    <u>Appartementen/HAT-woningen/Duplex</u>
                    <br />
                    <asp:CheckBoxList ID="cbListWijk3A" runat="server">
                        <asp:ListItem> Op de Dries</asp:ListItem>
                        <asp:ListItem> Koolhof</asp:ListItem>
                        <asp:ListItem> Fonterstraat</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <div class="div_right2">
                    <asp:CheckBoxList ID="cbListWijk4EG" runat="server">
                        <asp:ListItem> Vinkenweg</asp:ListItem>
                        <asp:ListItem> Nachtegaalstraat</asp:ListItem>
                        <asp:ListItem> Leeuwerikstraat</asp:ListItem>
                        <asp:ListItem> Herendries</asp:ListItem>
                        <asp:ListItem> Heiweg</asp:ListItem>
                        <asp:ListItem> Wethouder Meertensstraat</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                    <u>Seniorenwoningen</u>
                    <asp:CheckBoxList ID="cbListWijk4S" runat="server">
                        <asp:ListItem> Herendries</asp:ListItem>
                        <asp:ListItem> Wethouder Meertensstraat</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                    <u>Appartementen/HAT-woningen/Duplex</u>
                    <br />
                    <asp:CheckBoxList ID="cbListWijk4A" runat="server">
                        <asp:ListItem> Fonterstraat</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
         <br style="clear: left" /><br/>
        <div>
            <asp:Button ID="ButtonWoonwens" Font-Bold="true" runat="server"
                Text="Opslaan en betalen" OnClick="ButtonWoonwens_Click1" />
            <asp:Button ID="btnInschrijven" runat="server" OnClick="btnInschrijven_Click" Text="Terug naar inschrijven" />
        </div>
    </form>
</asp:Content>
