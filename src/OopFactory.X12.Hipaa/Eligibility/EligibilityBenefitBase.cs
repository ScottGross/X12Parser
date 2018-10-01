using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using OopFactory.X12.Hipaa.Common;

namespace OopFactory.X12.Hipaa.Eligibility
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    [EditorAlias(EditorAliases.ObjectPropertyEditor)]
    public abstract class EligibilityBenefitBase
    {
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Entity Source { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Provider Receiver { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public BenefitMember Subscriber { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public BenefitMember Dependent { get; set; }
    }
}
