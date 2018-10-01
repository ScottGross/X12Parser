using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using OopFactory.X12.Hipaa.Common;

namespace OopFactory.X12.Hipaa.Eligibility
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class RelatedEntity : Entity
    {
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public ProviderInformation ProviderInfo { get; set; }
    }
}
