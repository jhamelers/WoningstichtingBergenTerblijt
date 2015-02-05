<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="DigitaalInschrijven.aspx.cs" Inherits="WoningstichtingBergenTerblijt.DigitaalInschrijven" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholdercontent" runat="server">
    <form id="form1" runat="server">
        <br />
        <div class="cushycms" id="markupform">
            <div class="div_left">
                <%--<i><b>Gegevens aanvrager</b></i>--%>
                <div class="div_subleft">
                    <b>Aanvrager</b>
                    <asp:RequiredFieldValidator ID="rfvGeslacht_A" ControlToValidate="rblAanvrager" ErrorMessage="Geslacht aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:RadioButtonList RepeatDirection="Horizontal" runat="server"
                        ID="rblAanvrager" Height="16px" Width="125px" ViewStateMode="Enabled">
                        <asp:ListItem Text="Man" Value="M" />
                        <asp:ListItem Text="Vrouw" Value="V" />
                    </asp:RadioButtonList>
                </div>
                <br />
                <div class="div_subleft">
                    <b>BSN nummer:</b>
                    <asp:RequiredFieldValidator ID="rfvBsnNummer" ControlToValidate="tbBsnNr_A" ErrorMessage="BSN nummer (sofinummer)" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbBsnNr_A" MaxLength="12" Width="100px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Voorletters:</b>
                    <asp:RequiredFieldValidator ID="rfvVoorletters_A" ControlToValidate="tbVoorletters_A" ErrorMessage="Voorletters van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbVoorletters_A" MaxLength="5" Width="52px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Achternaam:</b>
                    <asp:RequiredFieldValidator ID="rfvAchternaam_A" ControlToValidate="tbAchternaam_A" ErrorMessage="Achternaam van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbAchternaam_A" MaxLength="75" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Straat:</b>
                    <asp:RequiredFieldValidator ID="rfvStraat_A" ControlToValidate="tbStraat_Ac" ErrorMessage="Straat van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbStraat_Ac" MaxLength="100" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Huisnummer:</b>
                    <asp:RequiredFieldValidator ID="rfvHuisnummer_A" ControlToValidate="tbHuisNr_Ac" ErrorMessage="Huisnummer van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbHuisNr_Ac" MaxLength="6" Width="40px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Postcode:</b>
                    <asp:RequiredFieldValidator ID="rfvPostcode_A" ControlToValidate="tbPostcode_Ac" ErrorMessage="Postcode van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbPostcode_Ac" MaxLength="6" Width="50px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Woonplaats:</b>
                    <asp:RequiredFieldValidator ID="rfvWoonplaats_A" ControlToValidate="tbWoonplaats_Ac" ErrorMessage="Woonplaats van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbWoonplaats_Ac" MaxLength="60" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Geboortedatum:</b>
                    <asp:RequiredFieldValidator ID="rfvGeboortedatum_A" ControlToValidate="tbGeboortedatum_A" ErrorMessage="Geboortedatum van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbGeboortedatum_A" MaxLength="12" Width="80px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Burgelijke staat:</b>
                    <asp:CompareValidator ID="cvBurgelijkeStaat" runat="server" ErrorMessage="Burgelijke staat van aanvrager"
                        ControlToValidate="ddlBurgStaat_A" ValueToCompare="0" Operator="NotEqual" Type="String" Display="None"></asp:CompareValidator>
                </div>
                <div class="div_subright">
                    <asp:DropDownList runat="server" ID="ddlBurgStaat_A" Width="180px" ViewStateMode="Enabled">
                        <asp:ListItem Text="Maak uw keuze" Value="0" Selected="True" />
                        <asp:ListItem Text="Ongehuwd" Value="1" />
                        <asp:ListItem Text="Gehuwd" Value="2" />
                        <asp:ListItem Text="Weduwe/Weduwnaar" Value="3" />
                        <asp:ListItem Text="Gescheiden" Value="4" />
                        <asp:ListItem Text="Geregistreerd partnerschap" Value="5" />
                    </asp:DropDownList>
                </div>
                <div class="div_subleft">
                    <b>Telefoonnummer:</b>
                    <asp:RequiredFieldValidator ID="rfvTelefoonnr_A" ControlToValidate="tbTelefoonnr_A" ErrorMessage="Telefoonnr van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbTelefoonnr_A" MaxLength="15" Width="80px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Beroep:</b>
                    <asp:RequiredFieldValidator ID="rfvBeroep_A" ControlToValidate="tbBeroep_A" ErrorMessage="Beroep van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbBeroep_A" MaxLength="60" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Werkgever:</b>
                    <asp:RequiredFieldValidator ID="rfvWerkgever_A" ControlToValidate="tbWerkgever_A" ErrorMessage="Werkgever van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbWerkgever_A" MaxLength="50" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Telefoon werkgever:</b>
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbTelWerkgever_A" MaxLength="15" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleftAlter">
                    <b>Bruto inkomen per maand in €:</b>
                    <asp:RequiredFieldValidator ID="rfvBrutoInkomen_A" ControlToValidate="tbBrutoInkomen_A" ErrorMessage="Inkomen per maand van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subrightAlter">
                    <asp:TextBox runat="server" ID="tbBrutoInkomen_A" MaxLength="8" Width="50px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleftAlter">
                    <b>Belastbaar inkomen per jaar in €:</b>
                    <asp:RequiredFieldValidator ID="rfvBelastbaarInkomen_A" ControlToValidate="tbBelastbaarInkomen_A" ErrorMessage="Inkomen per jaar van aanvrager" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subrightAlter">
                    <asp:TextBox runat="server" ID="tbBelastbaarInkomen_A" MaxLength="8" Width="50px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Email adres:</b>
                    <asp:RequiredFieldValidator ID="rfvEmail_A" ControlToValidate="tbEmailadres_A" ErrorMessage="Email adres van aanvrager" Text="*" ForeColor="Red" runat="server" />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmailadres_A" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ErrorMessage="Geen geldig email adres"></asp:RegularExpressionValidator>
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbEmailadres_A" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Adres kopieren voor partner?</b>
                </div>
                <div class="div_subright">
                    <asp:RadioButtonList RepeatDirection="Horizontal" runat="server"
                        ID="rblAdresKopieren" AutoPostBack="True" Height="16px" Width="100px" OnSelectedIndexChanged="rblAdresKopieren_SelectedIndexChanged">
                        <asp:ListItem Text="Nee" Value="0" />
                        <asp:ListItem Text="Ja" Value="1" />
                    </asp:RadioButtonList>
                </div>
                <div>
                     <b>Op welke termijn wenst een woning</b>
                </div>
                <div>
                    <asp:RadioButtonList RepeatDirection="Horizontal" runat="server"
                        ID="rblTermijn" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="rblTermijn_SelectedIndexChanged">
                        <asp:ListItem Text="Binnen 1 jaar" Value="0" />
                        <asp:ListItem Text="1-2 jaar" Value="1" />
                        <asp:ListItem Text="Langere termijn" Value="2" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="div_right">
                <div class="div_subleft">
                    <b>Partner</b>
                    <asp:RequiredFieldValidator ID="rfvGeslachtP" ControlToValidate="rblPartner" ErrorMessage="Geslacht partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:RadioButtonList RepeatDirection="Horizontal" runat="server"
                        ID="rblPartner" OnSelectedIndexChanged="rblPartner_SelectedIndexChanged"
                        Width="183px" AutoPostBack="True" ViewStateMode="Enabled">
                        <asp:ListItem Text="NVT" Value="N" />
                        <asp:ListItem Text="Man" Value="M" />
                        <asp:ListItem Text="Vrouw" Value="V" />
                    </asp:RadioButtonList>
                </div>
                <br />
                <div class="div_subleft">
                    <b>Voorletters:</b>
                    <asp:RequiredFieldValidator ID="rfvVoorletters_P" ControlToValidate="tbVoorletters_P" ErrorMessage="Voorletters van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbVoorletters_P" MaxLength="5" Width="52px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Achternaam:</b>
                    <asp:RequiredFieldValidator ID="rfvAchternaam_P" ControlToValidate="tbAchternaam_P" ErrorMessage="Achternaam van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbAchternaam_P" MaxLength="75" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Straat:</b>
                    <asp:RequiredFieldValidator ID="rfvStraat_P" ControlToValidate="tbStraat_P" ErrorMessage="Straat van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbStraat_P" MaxLength="100" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Huisnummer:</b>
                    <asp:RequiredFieldValidator ID="rfvHuisNr_P" ControlToValidate="tbHuisNr_P" ErrorMessage="Huisnummer van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbHuisNr_P" MaxLength="6" Width="40px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Postcode:</b>
                    <asp:RequiredFieldValidator ID="rfvPostcode_P" ControlToValidate="tbPostcode_P" ErrorMessage="Postcode van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbPostcode_P" MaxLength="6" Width="50px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Woonplaats:</b>
                    <asp:RequiredFieldValidator ID="rfvWoonplaats_P" ControlToValidate="tbWoonplaats_P" ErrorMessage="Woonplaats van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbWoonplaats_P" MaxLength="50" Width="180px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Geboortedatum:</b>
                    <asp:RequiredFieldValidator ID="rfvGeboortedatum_P" ControlToValidate="tbGeboortedatum_P" ErrorMessage="Geboortedatum van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbGeboortedatum_P" MaxLength="50" Width="80px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Burgelijke staat:</b>
                    <asp:CompareValidator ID="cvBurgelijkeStaat_P" runat="server" ErrorMessage="Burgelijke staat van partner"
                        ControlToValidate="ddlBurgStaat_P" ValueToCompare="0" Operator="NotEqual" Type="String" Display="None"></asp:CompareValidator>
                </div>
                <div class="div_subright">
                    <asp:DropDownList runat="server" ID="ddlBurgStaat_P" Width="180px" ViewStateMode="Enabled">
                        <asp:ListItem Text="Maak uw keuze" Value="0" Selected="True" />
                        <asp:ListItem Text="Ongehuwd" Value="1" />
                        <asp:ListItem Text="Gehuwd" Value="2" />
                        <asp:ListItem Text="Weduwe/Weduwnaar" Value="3" />
                        <asp:ListItem Text="Gescheiden" Value="4" />
                        <asp:ListItem Text="Geregistreerd partnerschap" Value="5" />
                    </asp:DropDownList>
                </div>
                <div class="div_subleft">
                    <b>Telefoonnummer:</b>
                    <asp:RequiredFieldValidator ID="rfvTelefoonnr_P" ControlToValidate="tbTelefoonnr_P" ErrorMessage="Telefoonnr van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbTelefoonnr_P" MaxLength="15" Width="80px" ViewStateMode="Enabled"></asp:TextBox>
                </div>
                <div class="div_subleft">
                    <b>Beroep:</b>
                    <asp:RequiredFieldValidator ID="rfvBeroep_P" ControlToValidate="tbBeroep_P" ErrorMessage="Beroep van partner" Text="*" ForeColor="Red" runat="server" />
                </div>
                <div class="div_subright">
                    <asp:TextBox runat="server" ID="tbBeroep_P" MaxLength="80" Width="180px"></asp:TextBox>
                </div>
                <div>
                    <asp:ValidationSummary ID="ValidationSummary" HeaderText="De volgende gegevens zijn verplicht of onjuist:"
                        DisplayMode="BulletList" ForeColor="Red" EnableClientScript="true" runat="server" CssClass="errors" />
                </div>
            </div>
        </div>
        <br style="clear: left" />
        <br />
        <br />
        <div><b><u>Gegevens van inwonende kinderen en/of medebewoners:</u></b></div>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="div_left1px">
                    <b>Naam en voorletters</b>
                </div>
                <div class="div_left2px">
                    <b>Geslacht</b>
                </div>
                <div class="div_right1px">
                    <b>Geboortedatum</b>
                </div>
                <div class="div_right2px">
                    <b>Beroep</b>
                </div>
                <br style="clear: left" />
                <div class="div_left1px">
                    <asp:TextBox runat="server" ID="tbMedeBewoner1_M" AutoPostBack="True" Width="185px" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbMedeBewoner1_M" ControlToValidate="tbMedeBewoner1_M" ErrorMessage="Naam inwonend kind of medebewoner 1" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_left2px">
                    <asp:DropDownList runat="server" ID="ddlGeslachtMede1" AutoPostBack="True" OnSelectedIndexChanged="ddlGeslachtMede1_SelectedIndexChanged" ViewStateMode="Enabled">
                        <asp:ListItem Text="Maak uw keuze" Value="0" Selected="True" />
                        <asp:ListItem Text="Man" Value="M" />
                        <asp:ListItem Text="Vrouw" Value="V" />
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="rfvddlGeslachtMede1" ControlToValidate="ddlGeslachtMede1" ErrorMessage="Geslacht inwonend kind of medebewoner 1" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right1px">
                    <asp:TextBox runat="server" ID="tbGeboorteMede1_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbGeboorteMede1_M" ControlToValidate="tbGeboorteMede1_M" ErrorMessage="Geboortedatum inwonend kind of medebewoner 1" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right2px">
                    <asp:TextBox runat="server" ID="tbBeroepMede1_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbBeroepMede1_M" ControlToValidate="tbBeroepMede1_M" ErrorMessage="Beroep inwonend kind of medebewoner 1" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <br style="clear: left" />
                <div class="div_left1px">
                    <asp:TextBox runat="server" ID="tbMedeBewoner2_M" Width="185px" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbMedeBewoner2_M" ControlToValidate="tbMedeBewoner2_M" ErrorMessage="Naam inwonend kind of medebewoner 2" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_left2px">
                    <asp:DropDownList runat="server" ID="ddlGeslachtMede2" AutoPostBack="True" OnSelectedIndexChanged="ddlGeslachtMede2_SelectedIndexChanged" ViewStateMode="Enabled">
                        <asp:ListItem Text="Maak uw keuze" Value="0" Selected="True" />
                        <asp:ListItem Text="NVT" Value="N" />
                        <asp:ListItem Text="Man" Value="M" />
                        <asp:ListItem Text="Vrouw" Value="V" />
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="rfvddlGeslachtMede2" ControlToValidate="ddlGeslachtMede2" ErrorMessage="Geslacht inwonend kind of medebewoner 2" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right1px">
                    <asp:TextBox runat="server" ID="tbGeboorteMede2_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbGeboorteMede2_M" ControlToValidate="tbGeboorteMede2_M" ErrorMessage="Geboortedatum inwonend kind of medebewoner 2" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right2px">
                    <asp:TextBox runat="server" ID="tbBeroepMede2_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbBeroepMede2_M" ControlToValidate="tbBeroepMede2_M" ErrorMessage="Beroep inwonend kind of medebewoner 2" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <br style="clear: left" />
                <div class="div_left1px">
                    <asp:TextBox runat="server" ID="tbMedeBewoner3_M" Width="185px" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbMedeBewoner3_M" ControlToValidate="tbMedeBewoner3_M" ErrorMessage="Naam inwonend kind of medebewoner 3" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_left2px">
                    <asp:DropDownList runat="server" ID="ddlGeslachtMede3" AutoPostBack="True" OnSelectedIndexChanged="ddlGeslachtMede3_SelectedIndexChanged" ViewStateMode="Enabled">
                        <asp:ListItem Text="Maak uw keuze" Value="0" Selected="True" />
                        <asp:ListItem Text="NVT" Value="N" />
                        <asp:ListItem Text="Man" Value="M" />
                        <asp:ListItem Text="Vrouw" Value="V" />
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="rfvddlGeslachtMede3" ControlToValidate="ddlGeslachtMede3" ErrorMessage="Geslacht inwonend kind of medebewoner 3" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right1px">
                    <asp:TextBox runat="server" ID="tbGeboorteMede3_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbGeboorteMede3_M" ControlToValidate="tbGeboorteMede3_M" ErrorMessage="Geboortedatum inwonend kind of medebewoner 3" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right2px">
                    <asp:TextBox runat="server" ID="tbBeroepMede3_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbBeroepMede3_M" ControlToValidate="tbBeroepMede3_M" ErrorMessage="Beroep inwonend kind of medebewoner 3" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <br style="clear: left" />
                <div class="div_left1px">
                    <asp:TextBox runat="server" ID="tbMedeBewoner4_M" Width="185px" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbMedeBewoner4_M" ControlToValidate="tbMedeBewoner4_M" ErrorMessage="Naam inwonend kind of medebewoner 4" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_left2px">
                    <asp:DropDownList runat="server" ID="ddlGeslachtMede4" AutoPostBack="True" OnSelectedIndexChanged="ddlGeslachtMede4_SelectedIndexChanged" ViewStateMode="Enabled">
                        <asp:ListItem Text="Maak uw keuze" Value="0" Selected="True" />
                        <asp:ListItem Text="NVT" Value="N" />
                        <asp:ListItem Text="Man" Value="M" />
                        <asp:ListItem Text="Vrouw" Value="V" />
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="rfvddlGeslachtMede4" ControlToValidate="ddlGeslachtMede4" ErrorMessage="Geslacht inwonend kind of medebewoner 4" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right1px">
                    <asp:TextBox runat="server" ID="tbGeboorteMede4_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbGeboorteMede4_M" ControlToValidate="tbGeboorteMede4_M" ErrorMessage="Geboortedatum inwonend kind of medebewoner 4" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
                <div class="div_right2px">
                    <asp:TextBox runat="server" ID="tbBeroepMede4_M" MaxLength="12" ViewStateMode="Enabled"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvtbBeroepMede4_M" ControlToValidate="tbBeroepMede4_M" ErrorMessage="Beroep inwonend kind of medebewoner 4" Text="*" ForeColor="Red" runat="server" />--%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br style="clear: left" />
        <br />
        <div>
            <b>Overige aan- of opmerkingen:</b>
        </div>
        <div>
            <asp:TextBox runat="server" ID="tbOpmerkingen" CssClass="NoResize" TextMode="MultiLine" MaxLength="500" Width="95%" ViewStateMode="Enabled"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="ButtonWoonwens" Font-Bold="true" runat="server"
            Text="Woonwens aangeven" OnClick="ButtonWoonwens_Click" />
        <asp:Button ID="ButtonInschrijven" Font-Bold="true" runat="server"
            Text="Inschrijven en betalen" OnClick="ButtonInschrijven_Click" />
    </form>
</asp:Content>
