using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using WoningstichtingBergenTerblijt.Class;

namespace WoningstichtingBergenTerblijt
{
    public partial class DigitaalWoonwens : System.Web.UI.Page
    {
        private ContentPlaceHolder mpContentPlaceHolder;
        private Control htmlform;
        private StringWriter writer = new StringWriter();
        private HtmlTextWriter html; 

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        private void MakeUpWoonwens()
        {
            html = new HtmlTextWriter(writer);
            
            html.WriteBreak();
            html.RenderBeginTag(HtmlTextWriterTag.B);
            html.RenderBeginTag(HtmlTextWriterTag.U);
            html.WriteEncodedText("Voorkeur woonwens: ");
            html.RenderEndTag();
            html.RenderEndTag();
            html.WriteBreak();
            html.WriteBreak();
            
            if (cbListWijk1EG.SelectedIndex != -1)
            {
                WriteWijk("Wijk1", "Eensgezinwoningen", cbListWijk1EG);
            }

            if (cbListWijk1S.SelectedIndex != -1)
            {
                WriteWijk("Wijk1", "Senioren", cbListWijk1S);
            }

            if (cbListWijk1A.SelectedIndex != -1)
            {
                WriteWijk("Wijk1", "Appartementen/Hat/Duplex", cbListWijk1A);
            }

            if (cbListWijk2EG.SelectedIndex != -1)
            {
                WriteWijk("Wijk2", "Eensgezinwoningen", cbListWijk2EG);
            }

            if (cbListWijk3EG.SelectedIndex != -1)
            {
                WriteWijk("Wijk3", "Eensgezinwoningen", cbListWijk3EG);
            }

            if (cbListWijk3S.SelectedIndex != -1)
            {
                WriteWijk("Wijk3", "Senioren", cbListWijk3S);
            }

            if (cbListWijk3Al.SelectedIndex != -1)
            {
                WriteWijk("Wijk3", "Aanleunwoningen", cbListWijk3Al);
            }

            if (cbListWijk3A.SelectedIndex != -1)
            {
                WriteWijk("Wijk3", "Appartementen/Hat/Duplex", cbListWijk3A);
            }

            if (cbListWijk4EG.SelectedIndex != -1)
            {
                WriteWijk("Wijk4", "Eensgezinwoningen", cbListWijk4EG);
            }

            if (cbListWijk4S.SelectedIndex != -1)
            {
                WriteWijk("Wijk4", "Senioren", cbListWijk4S);
            }

            if (cbListWijk4A.SelectedIndex != -1)
            {
                WriteWijk("Wijk4", "Appartementen/Hat/Duplex", cbListWijk4A);
            }
            
            Session["Woonwens"] = writer.ToString();

            html.Flush();
        }

        private void WriteWijk(string wijk, string type, CheckBoxList cbList)
        {
            html.RenderBeginTag(HtmlTextWriterTag.U);
            html.WriteEncodedText(wijk + " - " + type);
            html.RenderEndTag();
            html.WriteBreak();
            html.WriteBreak();

            var items = from item in cbList.Items.Cast<ListItem>()
                        where item.Selected
                        select item;

            foreach (var item in items)
            {
                html.Write("-x- " + item.Text);
                html.WriteBreak();
            }

            html.WriteBreak();
        }

        protected void ButtonWoonwens_Click1(object sender, EventArgs e)
        {
            MakeUpWoonwens();
            Server.Transfer("Ideal.aspx");
        }

        protected void btnInschrijven_Click(object sender, EventArgs e)
        {
            MakeUpWoonwens();
            Server.Transfer("DigitaalInschrijven.aspx");
        }
    }
}