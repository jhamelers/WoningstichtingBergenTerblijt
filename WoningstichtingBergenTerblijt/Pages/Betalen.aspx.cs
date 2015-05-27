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

namespace WoningstichtingBergenTerblijt
{
    public partial class Betalen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    //Parse the amount and start a payment on PostBack.
                    decimal amount = decimal.Parse(tbAmount.Text);

                    if (amount < (decimal)1.19)
                        throw new FormatException("Het bedrag moet groter zijn € 1,19");

                    this.StartPayment(amount);
                }
                catch (FormatException)
                {
                    //amount should be of the form 00,00
                    tbAmount.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
#if DEBUG
                this.GetTestModeBanks();
#else
                //Populate the dropdown with de banks that support iDEAL.
                this.GetBanks();
#endif

            }
        }

        private void StartPayment(decimal amount)
        {
            /*******************************
             * The url's and partner id given here should be replaced by your personal values.
             * In this example, the Mollie calls are done in testmode.
             *******************************/
#if DEBUG
            IdealFetch idealFetch = new IdealFetch
                       (
                           "1046991" //replace this by your Mollie partnerid
                           , true //testmode
                           , "Inschrijving woningzoekende"
                           , "http://www.woningstichtingbergenterblijt.nl/Pages/IdealCheckHandler.aspx"
                           , "http://localhost:64011/Pages/PaymentDone.aspx"
                           , DropDownList1.SelectedValue
                           , amount
                       );
#else 
            IdealFetch idealFetch = new IdealFetch
                           (
                               "1046991"
                               , false //testmode
                               , "Inschrijving woningzoekende"
                               , "http://www.woningstichtingbergenterblijt.nl/Pages/IdealCheckHandler.aspx"
                               , "http://www.woningstichtingbergenterblijt.nl/Pages/PaymentDone.aspx"
                               , DropDownList1.SelectedValue
                               , amount
                           );
#endif

            //Redirect to the customer's bank
            if (idealFetch.Error == false)
                this.Response.Redirect(idealFetch.Url, true);
        }

        private void GetBanks()
        {
            //Retrieve the banks that support iDEAL (in testmode)
            IdealBanks idealBanks = new IdealBanks("1046991", false);

            //Populate the dropdownlist.
            foreach (Bank bank in idealBanks.Banks)
            {
                DropDownList1.Items.Add(new ListItem(bank.Name, bank.Id));
            }
        }

        private void GetTestModeBanks()
        {
            //Retrieve the banks that support iDEAL (in testmode)
            IdealBanks idealBanks = new IdealBanks("1046991", true);

            //Populate the dropdownlist.
            foreach (Bank bank in idealBanks.Banks)
            {
                DropDownList1.Items.Add(new ListItem(bank.Name, bank.Id));
            }
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}