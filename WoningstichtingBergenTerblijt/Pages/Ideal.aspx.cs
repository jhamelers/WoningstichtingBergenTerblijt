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
using System.Web.UI.WebControls;
using Mollie.iDEAL;
using Mollie.Api;
using System.Configuration;

namespace WoningstichtingBergenTerblijt
{
    public partial class Ideal : System.Web.UI.Page
    {
        MollieClient mollieClient = new MollieClient();
        PaymentStatus status = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            mollieClient.setApiKey(ConfigurationManager.AppSettings["mollie_api_key"]);
           
            //Populate the dropdown with de banks that support iDEAL.
            if (!IsPostBack)
                this.GetBanks();
            else
            {
                //#endif

                try
                {
                    //Parse the amount and start a payment on PostBack.
                    decimal amount = decimal.Parse(tbAmount.Text);

                    if (amount < (decimal)1.19)
                        throw new FormatException("Het bedrag moet groter zijn € 1,19");

#if DEBUG
                    Payment payment = new Payment
                    {
                        amount = amount,
                        description = "Ideal betaling Woningstichting Berg en Terblijt",
                        method = Method.ideal,
                        redirectUrl = "http://localhost:64011/Pages/PaymentDone.aspx",
                    };
#else
                     Payment payment = new Payment
                    {
                        amount = amount,
                        description = "Ideal betaling Woningstichting Berg en Terblijt",
                        method = Method.ideal,
                        redirectUrl = "http://www.woningstichtingbergenterblijt.nl/Pages/PaymentDone.aspx",
                    };
#endif
                    status = mollieClient.StartPayment(payment);

                    Session["PaymentId"] = status.id;
                }

                    //this.StartPayment(amount);

                catch (FormatException)
                {
                    //amount should be of the form 00,00
                    tbAmount.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        
        private void GetBanks()
        {
            //Retrieve the banks that support iDEAL (in testmode)
            Issuers issuers = mollieClient.GetIssuers();

            //Populate the dropdownlist.
            //foreach (var issuer in issuers.data)
            //{
            //    DropDownList1.Items.Add(new ListItem(issuer.name, issuer.id));
            //}
        }
               
        protected void btnStart_Click(object sender, EventArgs e)
        {
            Response.Redirect(status.links.paymentUrl);
        }
    }
}
