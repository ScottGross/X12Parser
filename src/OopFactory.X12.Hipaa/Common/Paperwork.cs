using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace OopFactory.X12.Hipaa.Common
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class Paperwork
    {
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup ReportType { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup ReportTransmission { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Identification Identification { get; set; }
    }
}
