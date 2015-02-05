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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mollie.iDEAL;

namespace WoningstichtingBergenTerblijt
{
    public partial class IdealCheckHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Mollie gives us the transaction Id.
            string transactionId = this.Request["transaction_id"];

            this.Handle(transactionId);
        }

        private void Handle(string idealChecktransactionId)
        {
            //Check the payment (in testmode)
            IdealCheck idealCheck = new IdealCheck("1046991", idealChecktransactionId);

            if (idealCheck.Error)
            {
                Session["Error"] = "De iDEAL betaling is mislukt. TransactionId: " + idealCheck.TransactionId + ". Foutmelding: " + idealCheck.ErrorMessage;
                Server.Transfer("PaymentFailed.aspx");
                //throw new Exception(idealCheck.ErrorMessage);
            }

            if (idealCheck.Payed)
            {
                /*************
                 * Payment succeeded, handle appropriately
                 ************/
                Session["Betaling"] = "iDEAL betaling voltooid. TransactieId: " + idealCheck.TransactionId + ". Bedrag is " + idealCheck.Amount + " euro.";
                Server.Transfer("PaymentDone.aspx");
            }
            else
            {
                // error opvangen
                Session["Error"] = "De iDEAL betaling is mislukt. TransactionId: " + idealCheck.TransactionId + ". Foutmelding: " + idealCheck.ErrorMessage;
                // TODO nog vervangen
                //Server.Transfer("http://localhost:64011/Pages/PaymentFailed.aspx", true);
                Server.Transfer("PaymentFailed.aspx");
            }
        }    
    }
}