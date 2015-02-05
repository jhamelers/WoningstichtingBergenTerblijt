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

namespace WoningstichtingBergenTerblijt
{
    public partial class PaymentDone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Als de betalign voltooid is mogen de gegevens opgestuurd worden
            MailGegevens();
           //MailGegevensLokaal();
        }

        private void MailGegevens()
        {
            MailMessage NetMail = new MailMessage();
            SmtpClient MailClient = new SmtpClient();
            string ThisHost = "smtp.vevida.com";
            int ThisPort = 25;
            string EmailSender = "WoningstichtingBergenTerblijt <info@woningstichtingbergenterblijt.nl>";
            string EmailRecipient = Session["EmailRecipient"] != null ? (string)Session["EmailRecipient"] : "";

            NetMail.From = new MailAddress(EmailSender);
            NetMail.To.Add(new MailAddress(EmailRecipient));
            NetMail.Bcc.Add(new MailAddress(EmailSender));
            NetMail.IsBodyHtml = false;
            NameValueCollection NVCSrvElements = Request.ServerVariables;
            string[] InstanceID = NVCSrvElements.GetValues("INSTANCE_ID");
            NetMail.Headers.Add("X-Instance-ID", Convert.ToString(InstanceID[0]));
            NetMail.Subject = "Inschrijving als woningzoekende: " + (string)Session["GeslachtAanvrager"] == "M" ? "dhr " : "mevr " + Session["NaamAanvrager"];
            NetMail.IsBodyHtml = true;
            NetMail.Body = "De volgende gegevens zijn ingevuld: <br/><br/>" + Session["aanvrager"] + Session["partner"] + Session["Medebewoner"] + Session["Woonwens"] + "<br/><br/><b><u>Betalingsgegevens:</u></b><br/><br/>" + Session["Betaling"];

            MailClient.EnableSsl = true;
            MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailClient.Host = ThisHost;
            MailClient.Port = ThisPort;
            MailClient.Send(NetMail);

            NetMail.Dispose();
            NetMail = null;
            MailClient = null;
        }

        private void MailGegevensLokaal()
        {
            MailMessage LocalMail = new MailMessage();
            SmtpClient MailClient = new SmtpClient();

            string EmailSender = "jorg.eu <jorg@jorg.eu>";
            string EmailRecipient = "jorg.hamelers@gmail.com";

            LocalMail.From = new MailAddress(EmailSender);
            LocalMail.To.Add(new MailAddress(EmailRecipient));

            LocalMail.Subject = "Inschrijving als woningzoekende";
            LocalMail.IsBodyHtml = true;
            LocalMail.Body = "De volgende gegevens zijn ingevuld:<br/><br/>" + Session["aanvrager"] + Session["partner"] + Session["Medebewoner"] + Session["Woonwens"] + "<br/><br/><b><u>Betalingsgegevens:</u></b><br/><br/>" + Session["Betaling"];

            MailClient.Send(LocalMail);

            LocalMail.Dispose();
            LocalMail = null;
            MailClient = null;
        }
    }
}