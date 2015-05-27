/**************************************************************************************
 * This sample was written by Eric Goldstein for www.lotendelen.nl, on Sep 16th, 2008.
 * 
 * You can copy this code for any purpose, as long as you don't change this comment.
 * 
 * E. Goldstein
 * www.lotendelen.nl - Samen spelen, samen delen!
 * 
 **************************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mollie.iDEAL;
using System.Net;

namespace WoningstichtingBergenTerblijt
{
    public partial class PaymentFailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MailGegevens();
        }

        private void MailGegevens()
        {
            MailMessage NetMail = new MailMessage();
            SmtpClient MailClient = new SmtpClient();
            string ThisHost = "smtp.vevida.com";
            int ThisPort = 25;
            string EmailSender = "WoningstichtingBergenTerblijt <info@woningstichtingbergenterblijt.nl>";
            string EmailRecipient = Session["EmailRecipient"] != null ? (string)Session["EmailRecipient"] : "geenemailadres@jorg.eu";
            string EmailWebmaster = "jorg.hamelers@gmail.com";
                
            NetMail.From = new MailAddress(EmailSender);
            //NetMail.To.Add(new MailAddress(EmailRecipient));
            NetMail.To.Add(new MailAddress(EmailWebmaster));
            NetMail.IsBodyHtml = false;
            NameValueCollection NVCSrvElements = Request.ServerVariables;
            string[] InstanceID = NVCSrvElements.GetValues("INSTANCE_ID");
            NetMail.Headers.Add("X-Instance-ID", Convert.ToString(InstanceID[0]));

            string geslacht = Session["GeslachtAanvrager"] != null ? (string)Session["GeslachtAanvrager"] : "onbekend";

            if (geslacht == "M")
                geslacht = "dhr ";
            else if (geslacht == "V")
                geslacht = "mevr ";
            
            NetMail.Subject = "Betaling is mislukt! Inschrijving als woningzoekende " + geslacht + Session["NaamAanvrager"] + ".";
            NetMail.IsBodyHtml = true;
            string extra = Session["Error"] != null ? Session["Error"].ToString() : "Er is geen foutmelding bekend.";
            NetMail.Body = "<br/><br/> De volgende gegevens zijn ingevuld: <br/><br/>" + Session["aanvrager"] + Session["partner"] + Session["Medebewoner"] + Session["Woonwens"] + "<br/><br/><b><u>Betalingsgegevens:</u></b><br/><br/><b>DE BETALING IS MISLUKT</b><br/><br/>" + extra;

            MailClient.Credentials = new NetworkCredential("info@woningstichtingbergenterblijt.nl", "wsbent6325");
            MailClient.EnableSsl = true;
            MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailClient.Host = ThisHost;
            MailClient.Port = ThisPort;
            MailClient.Send(NetMail);

            NetMail.Dispose();
            NetMail = null;
            MailClient = null;
        }
    }
}