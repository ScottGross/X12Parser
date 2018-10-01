using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace OopFactory.X12.Hipaa.Common
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class RequestValidation
    {
        [XmlAttribute]
        public bool ValidRequest { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup RejectReason { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup FollupAction { get; set; }
    }
}
