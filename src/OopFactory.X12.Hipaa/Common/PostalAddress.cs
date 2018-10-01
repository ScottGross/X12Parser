using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OopFactory.X12.Hipaa.Common
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class PostalAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [XmlAttribute]
        public string City { get; set; }
        [XmlAttribute]
        public string StateCode { get; set; }
        [XmlAttribute]
        public string PostalCode { get; set; }
        [XmlAttribute]
        public string CountryCode { get; set; }
        [XmlAttribute]
        public string CountrySubdivisionCode { get; set; }

        public string Locale => $"{City}, {StateCode} {PostalCode}";

        public override string ToString()
        {
            var line2 = string.IsNullOrEmpty(Line2) ? string.Empty : $" {Line2},";
            return $"{Line1},{line2} {City}, {StateCode} {PostalCode}";
        }
    }
}
