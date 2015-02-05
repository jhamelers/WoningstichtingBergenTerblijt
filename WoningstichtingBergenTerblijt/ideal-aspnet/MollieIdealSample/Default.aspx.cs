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
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Mollie.iDEAL;

namespace MollieIdealSample
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsPostBack)
			{
				try
				{
					//Parse the amount and start a payment on PostBack.
					decimal amount = decimal.Parse(this.tbAmount.Text);

					if (amount < (decimal)1.19)
						throw new FormatException("bedrag moet groter zijn € 1,19");

					this.StartPayment(amount);
				}
				catch (FormatException)
				{
					//amount should be of the form 00,00
					this.tbAmount.ForeColor = System.Drawing.Color.Red;
				}
			}
			else
			{
				//Populate the dropdown with de banks that support iDEAL.
				this.GetBanks();
			}
		}

		private void StartPayment(decimal amount)
		{
			/*******************************
			 * The url's and partner id given here should be replaced by your personal values.
			 * In this example, the Mollie calls are done in testmode.
			 *******************************/
			IdealFetch idealFetch = new IdealFetch
				(
					"12345" //replace this by your Mollie partnerid
					, true //testmode
					, "This is a test payment"
					, "http://www.mysite.nl/IdealCheckHandler.aspx"
					, "http://www.mysite.nl/PaymentDone.aspx"
					, this.DropDownList1.SelectedValue
					, amount
				);


			//Redirect to the customer's bank
			if (idealFetch.Error == false)
				this.Response.Redirect(idealFetch.Url, true);

		}

		private void GetBanks()
		{
			//Retrieve the banks that support iDEAL (in testmode)
			IdealBanks idealBanks = new IdealBanks("123456", true);

			//Populate the dropdownlist.
			foreach (Bank bank in idealBanks.Banks)
			{
				this.DropDownList1.Items.Add(new ListItem(bank.Name, bank.Id));
			}
		}
	}
}
