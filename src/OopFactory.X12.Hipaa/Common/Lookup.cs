using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DevExpress.ExpressApp.DC;

namespace OopFactory.X12.Hipaa.Common
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    [XafDefaultProperty("Description")]
    public class Lookup
    {
        [XmlAttribute]
        public string Code { get; set; }

        [XmlText]
        public string Description { get; set; }
    }
}
