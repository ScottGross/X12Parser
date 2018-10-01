using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace OopFactory.X12.Hipaa.Common
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class HealthCarePricing
    {
        public Lookup PricingMethodology { get; set; }
        public decimal AllowedAmount { get; set; }
        public decimal? SavingsAmount { get; set; }
        public string RepricingOrgId { get; set; }
        public decimal? PricingRate { get; set; }
        public string ApprovedDrgCode { get; set; }
        public decimal? ApprovedDrgAmount { get; set; }
        public string ApprovedRevenueCode { get; set; }
        public string ProductOrServiceIdQualifier { get; set; }
        public string ApprovedProcedureCode { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup UnitOfMeasure { get; set; }
        public decimal? Quantity { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup RejectReason { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup PolicyComplaince { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup Exception { get; set; }
    }
}
