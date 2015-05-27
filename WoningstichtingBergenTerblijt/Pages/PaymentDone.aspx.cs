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
using Mollie.Api;

namespace WoningstichtingBergenTerblijt
{
    public partial class PaymentDone : System.Web.UI.Page
    {
        MollieClient mollieClient = new MollieClient();
        PaymentStatus status = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Als de betalign voltooid is mogen de gegevens opgestuurd worden
            Validate();
#if DEBUG
            MailGegevensLokaal();
#else
            MailGegevens();
#endif
        }

        private void Validate()
        {
            string transactionid = Request.QueryString["transaction_id"];
            string paymentid = Session["PaymentId"] != null ? Session["PaymentId"].ToString() : string.Empty;

            if (!string.IsNullOrEmpty(paymentid))
                status = mollieClient.GetStatus(paymentid); 
            else
            {
                Session["Error"] = "De iDEAL betaling is mislukt. Er is een onbekende fout opgetreden.";
                Server.Transfer("PaymentFailed.aspx");
            }

            if (status.status == Status.paid)
            {
                Session["Betaling"] = "iDEAL betaling voltooid. TransactieId: " + status.id + ". Bedrag is " + status.amount + " euro.";
            }
            else
            {
                Session["Error"] = "De iDEAL betaling is mislukt met transactieid " + status.id + ". Status van de betaling is: " + status.status;
                Server.Transfer("PaymentFailed.aspx");
            }
            
            //IdealCheck idealCheck = new IdealCheck("1046991", this.Request["transaction_id"]);

            //if (idealCheck.Error)
            //{
            //    Session["Error"] = "De iDEAL betaling is mislukt. TransactionId: " + idealCheck.TransactionId + ". Foutmelding: " + idealCheck.ErrorMessage;
            //    Server.Transfer("PaymentFailed.aspx");
            //    //throw new Exception(idealCheck.ErrorMessage);
            //}

            //if (idealCheck.Payed)
            //{
            //    /*************
            //     * Payment succeeded, handle appropriately
            //     ************/
            //    Session["Betaling"] = "iDEAL betaling voltooid. TransactieId: " + idealCheck.TransactionId + ". Bedrag is " + idealCheck.Amount + " euro.";
            //    Server.Transfer("PaymentDone.aspx");
            //}
            //else
            //{
            //    // error opvangen
            //    Session["Error"] = "De iDEAL betaling is mislukt. TransactionId: " + idealCheck.TransactionId + ". Foutmelding: " + idealCheck.Message;
            //    // TODO nog vervangen
            //    //Server.Transfer("http://localhost:64011/Pages/PaymentFailed.aspx", true);
            //    Server.Transfer("PaymentFailed.aspx");
            //}
        }

        private void MailGegevens()
        {
            MailMessage NetMail = new MailMessage();
            SmtpClient MailClient = new SmtpClient();
            string ThisHost = "smtp.vevida.com";
            int ThisPort = 25;
            string EmailSender = "WoningstichtingBergenTerblijt <info@woningstichtingbergenterblijt.nl>";
            string EmailRecipient = Session["EmailRecipient"] != null ? (string)Session["EmailRecipient"] : "geenemailadres@jorg.eu";

            NetMail.From = new MailAddress(EmailSender);
            NetMail.To.Add(new MailAddress(EmailRecipient));
            NetMail.Bcc.Add(new MailAddress("jorg.hamelers@gmail.com"));
            NetMail.IsBodyHtml = false;
            NameValueCollection NVCSrvElements = Request.ServerVariables;
            string[] InstanceID = NVCSrvElements.GetValues("INSTANCE_ID");
            NetMail.Headers.Add("X-Instance-ID", Convert.ToString(InstanceID[0]));

            string geslacht = Session["GeslachtAanvrager"] != null ? (string)Session["GeslachtAanvrager"] : "";

            if (geslacht == "M")
                geslacht = "dhr ";
            else if (geslacht == "V")
                geslacht = "mevr ";

            NetMail.Subject = "Inschrijving als woningzoekende: " + geslacht + Session["NaamAanvrager"];
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