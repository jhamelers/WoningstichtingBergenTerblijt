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
	public partial class IdealCheckHandler : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Mollie gives us the transaction Id.
			string transactionId = this.Request["transaction_id"];

			this.Handle(transactionId);
		}

		private void Handle(string transactionId)
		{
			//Check the payment (in testmode)
			IdealCheck idealCheck = new IdealCheck("12345", true, transactionId);

			if (idealCheck.Error)
				throw new Exception(idealCheck.ErrorMessage);

			if (idealCheck.Payed)
			{
				/*************
				 * Payment succeeded, handle appropriately
				 ************/
			}
		}
	}
}
