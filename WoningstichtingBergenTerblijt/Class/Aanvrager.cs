using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoningstichtingBergenTerblijt.Class
{
    public class Aanvrager
    {
        public string Geslacht { get; set; }
        public string BsnNummer { get; set; }
        public string Voorletters { get; set; }
        public string Achternaam { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Geboortedatum { get; set; }
        public string BurgelijkeStaat { get; set; }
        public string TelefoonNr { get; set; }
        public string Beroep { get; set; }
        public string Werkgever { get; set; }
        public string TelefoonWerkgever { get; set; }
        public string BrutoInkomen { get; set; }
        public string BelastbaarInkomen { get; set; }
        public string EmailAdres { get; set; }
        public string Termijn { get; set; }
        public string Opmerkingen { get; set; }
    }
}