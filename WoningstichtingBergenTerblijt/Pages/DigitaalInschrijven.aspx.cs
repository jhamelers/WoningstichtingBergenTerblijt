using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using WoningstichtingBergenTerblijt.Class;

namespace WoningstichtingBergenTerblijt
{
    public partial class DigitaalInschrijven : System.Web.UI.Page
    {
        private ContentPlaceHolder mpContentPlaceHolder;
        private Control htmlform;

        protected void Page_Load(object sender, EventArgs e)
        {
            mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("contentplaceholdercontent");
            htmlform = (Control)mpContentPlaceHolder.FindControl("form1");
            
#if DEBUG
            tbBsnNr_A.Text = "123456789";
            tbAchternaam_A.Text = "Hamelers";
            tbBelastbaarInkomen_A.Text = "40000";
            tbBeroep_A.Text = "Consultant";
            tbBrutoInkomen_A.Text = "3200";
            tbGeboortedatum_A.Text = "16-09-1980";
            tbHuisNr_Ac.Text = "32";
            tbPostcode_Ac.Text = "6325ct";
            tbStraat_Ac.Text = "Blokbrekersstraat";
            tbTelefoonnr_A.Text = "0641487563";
            tbVoorletters_A.Text = "JAH";
            tbWerkgever_A.Text = "CGI";
            tbWoonplaats_Ac.Text = "Berg&Terblijt";
            rblAanvrager.SelectedIndex = 0;
            ddlBurgStaat_A.SelectedIndex = 2;
            rblAdresKopieren.SelectedIndex = 0;
            rblPartner.SelectedIndex = 2;
            rblTermijn.SelectedIndex = 1;

            tbAchternaam_P.Text = "Lindelauf";
            tbBeroep_P.Text = "Huisvrouw";
            tbGeboortedatum_P.Text = "23-09-1982";
            tbTelefoonnr_P.Text = "0631313313";
            tbVoorletters_P.Text = "TMP";
            tbWoonplaats_P.Text = "Berg&Terblijt";
            tbHuisNr_P.Text = "32";
            tbPostcode_P.Text = "6325ct";
            tbStraat_P.Text = "Blokbrekersstraat";
            ddlBurgStaat_P.SelectedIndex = 2;

            tbEmailadres_A.Text = "inschrijving@nieuw.nl";
            tbMedeBewoner1_M.Text = "Jorg";
            tbMedeBewoner2_M.Text = "Tessa";
            tbGeboorteMede1_M.Text = "16-09-1980";
            tbGeboorteMede2_M.Text = "23-09-1982";
            tbBeroepMede1_M.Text = "Timmerman";
            tbBeroepMede2_M.Text = "Metselaar";
            ddlGeslachtMede1.SelectedIndex = 2;
            ddlGeslachtMede2.SelectedIndex = 3;
            ddlGeslachtMede3.SelectedIndex = 1;
            ddlGeslachtMede4.SelectedIndex = 1;

            tbOpmerkingen.Text = "Test";
#endif

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        protected void rblPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Indien er geen partner is, hoeven de gegevens ook niet gevuld te worden
            bool isEnabled = rblPartner.SelectedIndex != 0;

            rblAdresKopieren.SelectedIndex = -1;

            foreach (TextBox tb in htmlform.Controls.OfType<TextBox>())
            {
                if (tb.ID.EndsWith("_P"))
                {
                    foreach (RequiredFieldValidator rfv in htmlform.Controls.OfType<RequiredFieldValidator>())
                    {
                        if (tb.ID.EndsWith(rfv.ID.Substring(3, rfv.ID.Length - 3)))
                            rfv.EnableClientScript = isEnabled;
                    }
                    cvBurgelijkeStaat_P.EnableClientScript = isEnabled;
                    tb.Enabled = isEnabled;
                    if (!isEnabled)
                    {
                        tb.Text = "";
                        ddlBurgStaat_P.SelectedIndex = 0;
                    }
                }
            }

            ddlBurgStaat_P.Enabled = isEnabled;
        }

        protected void ButtonInschrijven_Click(object sender, EventArgs e)
        {
            SetData();
            Server.Transfer("Ideal.aspx");

        }

        private void SetData()
        {
            var aanvrager = new Aanvrager();
            aanvrager.BsnNummer = tbBsnNr_A.Text;
            aanvrager.Geslacht = rblAanvrager.SelectedValue;
            Session["GeslachtAanvrager"] = rblAanvrager.SelectedValue;
            aanvrager.Voorletters = tbVoorletters_A.Text;
            aanvrager.Achternaam = tbAchternaam_A.Text;
            Session["NaamAanvrager"] = tbAchternaam_A.Text;
            aanvrager.Straat = tbStraat_Ac.Text;
            aanvrager.Huisnummer = tbHuisNr_Ac.Text;
            aanvrager.Postcode = tbPostcode_Ac.Text;
            aanvrager.Woonplaats = tbWoonplaats_Ac.Text;
            aanvrager.Geboortedatum = tbGeboortedatum_A.Text;
            aanvrager.BurgelijkeStaat = ddlBurgStaat_A.SelectedValue;
            aanvrager.TelefoonNr = tbTelefoonnr_A.Text;
            aanvrager.Beroep = tbBeroep_A.Text;
            aanvrager.Werkgever = tbWerkgever_A.Text;
            aanvrager.TelefoonWerkgever = tbTelWerkgever_A.Text;
            aanvrager.BrutoInkomen = tbBrutoInkomen_A.Text;
            aanvrager.BelastbaarInkomen = tbBelastbaarInkomen_A.Text;
            aanvrager.Termijn = rblTermijn.SelectedItem.Text;
            aanvrager.EmailAdres = tbEmailadres_A.Text;
            Session["EmailRecipient"] = tbEmailadres_A.Text;
            aanvrager.Opmerkingen = tbOpmerkingen.Text;

            var partner = new Partner();
            partner.Geslacht = rblPartner.SelectedValue;
            partner.Voorletters = tbVoorletters_P.Text;
            partner.Achternaam = tbAchternaam_P.Text;
            partner.Straat = tbStraat_P.Text;
            partner.Huisnummer = tbHuisNr_P.Text;
            partner.Postcode = tbPostcode_P.Text;
            partner.Woonplaats = tbWoonplaats_P.Text;
            partner.Geboortedatum = tbGeboortedatum_P.Text;
            partner.BurgelijkeStaat = ddlBurgStaat_P.SelectedValue;
            partner.TelefoonNr = tbTelefoonnr_P.Text;
            partner.Beroep = tbBeroep_P.Text;

            Session["aanvrager"] = MarkUpInschrijven(aanvrager).InnerWriter;
            if (rblPartner.SelectedIndex != 0)
                Session["partner"] = MarkUpInschrijven(partner).InnerWriter;

             VulGegevensMedebewoners();

            //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://localhost:64011/Pages/DigitaalInschrijven.aspx");
            //myRequest.Method = "GET";
            //WebResponse myResponse = myRequest.GetResponse();
            //StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            //string result = sr.ReadToEnd();
            //sr.Close();
            //myResponse.Close();


            //var listName = new List<String>();
            //var listValue = new List<String>();

            //HtmlWeb hw = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument htmlDoc = hw.Load(@"http://localhost:64011/Pages/DigitaalInschrijven.aspx");
            //if (htmlDoc.DocumentNode != null)
            //{
            //    foreach (HtmlNode text in htmlDoc.DocumentNode.SelectNodes("//div[@class='div_subleft']"))
            //    {
            //        string name = text.InnerText.Replace("\r\n", "");
            //        name = name.Replace("*", "");
            //        string value = text.NextSibling.InnerText.Replace("\r\n", "");

            //        listName.Add(name.Replace(" ", "") + value.Replace(" ", ""));
            //        //if (!String.IsNullOrEmpty(text.InnerText) && text.InnerText != "/r/n")
            //        //    listName.Add(text.InnerText);
            //    }

            //    foreach (HtmlNode text in htmlDoc.DocumentNode.SelectNodes("//div[@class='div_subright'/value()]"))
            //    {
            //        string result = text.InnerHtml.Replace("\r\n", "");
            //        result = result.Replace("*", "");
            //        listValue.Add(result.Replace(" ", ""));
            //        //if (!String.IsNullOrEmpty(text.InnerHtml) && text.InnerHtml != "/r/n")
            //        //    listValue.Add(text.InnerHtml);
            //    }


            //}
        }

        private void VulGegevensMedebewoners()
        {
            var controlsUpdatepanel = htmlform.FindControl("UpdatePanel1");
            StringBuilder sb = new StringBuilder();

            foreach (DropDownList ddl in controlsUpdatepanel.Controls[0].Controls.OfType<DropDownList>())
            {
                if (ddl.ID.Remove(ddl.ID.Length - 1).EndsWith("Mede"))
                {
                    int welkeMedebewoner = Int32.Parse(ddl.ID.Remove(0, ddl.ID.Length - 1));
                    var medebewoner = new MedeBewoner();

                    switch (welkeMedebewoner)
                    {
                        case 1:
                            medebewoner.Naam = tbMedeBewoner1_M.Text;
                            medebewoner.Geslacht = ddlGeslachtMede1.SelectedValue;
                            medebewoner.Geboortedatum = tbGeboorteMede1_M.Text;
                            medebewoner.Beroep = tbBeroepMede1_M.Text;
                            break;
                        case 2:
                            medebewoner.Naam = tbMedeBewoner2_M.Text;
                            medebewoner.Geslacht = ddlGeslachtMede2.SelectedValue;
                            medebewoner.Geboortedatum = tbGeboorteMede2_M.Text;
                            medebewoner.Beroep = tbBeroepMede2_M.Text;
                            break;
                        case 3:
                            medebewoner.Naam = tbMedeBewoner3_M.Text;
                            medebewoner.Geslacht = ddlGeslachtMede3.SelectedValue;
                            medebewoner.Geboortedatum = tbGeboorteMede3_M.Text;
                            medebewoner.Beroep = tbBeroepMede3_M.Text;
                            break;
                        case 4:
                            medebewoner.Naam = tbMedeBewoner4_M.Text;
                            medebewoner.Geslacht = ddlGeslachtMede4.SelectedValue;
                            medebewoner.Geboortedatum = tbGeboorteMede4_M.Text;
                            medebewoner.Beroep = tbBeroepMede4_M.Text;
                            break;
                    }
                    sb.Append(MarkUpInschrijven(medebewoner).InnerWriter);
                }
            }

            Session["Medebewoner"] = sb.ToString();
        }

        private HtmlTextWriter MarkUpInschrijven<T>(T inschrijven)
        {
            StringWriter writer = new StringWriter();
            HtmlTextWriter html = new HtmlTextWriter(writer);
            Type t = inschrijven.GetType();

            html.RenderBeginTag(HtmlTextWriterTag.B);
            html.RenderBeginTag(HtmlTextWriterTag.U);
            html.WriteEncodedText("Gegevens van " + t.Name.ToLower() + ":");
            html.RenderEndTag();
            html.RenderEndTag();
            html.WriteBreak();
            html.WriteBreak();

            foreach (PropertyInfo info in inschrijven.GetType().GetProperties())
            {
                if (info.CanRead)
                {
                    object o = info.GetValue(inschrijven, null);
                    // wanneer het geslacht van medebewoner NVT is, dan zijn de gegevens niet nodig
                    if (info.Name == "BurgelijkeStaat" && t.Name == "Aanvrager")
                    {
                        html.WriteLine("* " + info.Name + " : " + ddlBurgStaat_A.SelectedItem.Text + "<br/>");
                    }
                    else if (info.Name == "BurgelijkeStaat" && t.Name == "Partner")
                    {
                        html.WriteLine("* " + info.Name + " : " + ddlBurgStaat_P.SelectedItem.Text + "<br/>");
                    }
                    else
                    {
                        html.WriteLine("* " + info.Name + " : " + o.ToString() + "<br/>");
                    }
                }
            }

            html.WriteBreak();
            
            return html;
        }
        
        protected void rblAdresKopieren_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblAdresKopieren.SelectedIndex == 1 && rblPartner.SelectedIndex != 0)
            {
                foreach (TextBox tb in htmlform.Controls.OfType<TextBox>())
                {
                    if (tb.ID.EndsWith("_Ac"))
                    {
                        CopyText(tb);
                    }
                }
            }
            else
            {
                ClearText();
            }
        }

        private void ClearText()
        {
            foreach (TextBox tb in htmlform.Controls.OfType<TextBox>())
            {
                if (tb.ID.EndsWith("_P"))
                {
                    tb.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Copy the text of the textbox from Aanvrager to Partner
        /// </summary>
        /// <param name="tb"></param>
        private void CopyText(TextBox tb)
        {
            foreach (TextBox tbPartner in htmlform.Controls.OfType<TextBox>())
            {
                if (tb.ID.StartsWith(tbPartner.ID.Substring(0, tbPartner.ID.Length - 2)))
                {
                    tbPartner.Text = tb.Text;
                }
            }
        }

        protected void ButtonWoonwens_Click(object sender, EventArgs e)
        {
            SetData();
            Server.Transfer("DigitaalWoonwens.aspx");
        }

        protected void ddlGeslachtMede1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateKindMedebewoner(ddlGeslachtMede1, 1);
        }

        private void ValidateKindMedebewoner(DropDownList ddl, int welkeMedebewoner)
        {
            var controlsUpdatepanel = htmlform.FindControl("UpdatePanel1");
            
            bool isEnabled = ddl.SelectedIndex != 0;
            bool needsValidation = ddl.SelectedValue != "N";

            foreach (TextBox tb in controlsUpdatepanel.Controls[0].Controls.OfType<TextBox>())
            {
                if (tb.ID.EndsWith("_M") && ExtractNumber(tb.ID) == welkeMedebewoner)
                {
                    foreach (RequiredFieldValidator rfv in controlsUpdatepanel.Controls[0].Controls.OfType<RequiredFieldValidator>())
                    {
                        if (tb.ID.EndsWith(rfv.ID.Substring(3, rfv.ID.Length - 3)))
                            rfv.EnableClientScript = needsValidation;
                    }

                    tb.Enabled = isEnabled;
                    if (!isEnabled)
                    {
                        tb.Text = "";
                    }
                }
            }
        }

        private int ExtractNumber(string medebewoner)
        {
            medebewoner = medebewoner.Remove(medebewoner.Length - 2, 2);
            medebewoner = medebewoner.Remove(0, medebewoner.Length - 1);

            return Convert.ToInt32(medebewoner);
        }

        protected void ddlGeslachtMede2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateKindMedebewoner(ddlGeslachtMede2, 2);
        }

        protected void ddlGeslachtMede3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateKindMedebewoner(ddlGeslachtMede3, 3);
        }

        protected void ddlGeslachtMede4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateKindMedebewoner(ddlGeslachtMede4, 4);
        }

        protected void rblTermijn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}