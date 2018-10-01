using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using OopFactory.X12.Hipaa.Common;

namespace OopFactory.X12.Hipaa.Eligibility
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class EligibilityBenefitInformation
    {
        public EligibilityBenefitInformation()
        {
            if (Identifications == null) Identifications = new List<Identification>();
            if (RequestValidations == null) RequestValidations = new List<RequestValidation>();
            if (Dates == null) Dates = new List<QualifiedDate>();
            if (DateRanges == null) DateRanges = new List<QualifiedDateRange>();
            if (Messages == null) Messages = new List<string>();
            if (RelatedEntities == null) RelatedEntities = new List<RelatedEntity>();

        }
        [Browsable(false)]
        public string ServiceTypeCount { get; set; }
        [XmlIgnore]
        public decimal? Amount { get; set; }

        #region Serializable Amount properties
        [XmlAttribute(AttributeName = "Amount")]
        [Browsable(false)]
        public decimal SerializableAmount
        {
            get => Amount ?? decimal.Zero;
            set => Amount = value;
        }

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializableAmountSpecified => Amount.HasValue;

        #endregion

        [XmlIgnore]
        public decimal? Percentage { get; set; }

        #region Serializable Percentage properties
        [XmlAttribute(AttributeName = "Percentage")]
        [Browsable(false)]
        public decimal SerializablePercentage
        {
            get => Percentage ?? decimal.Zero;
            set => Percentage = value;
        }

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializablePercentageSpecified => Percentage.HasValue;

        #endregion
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup InfoType { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup CoverageLevel { get; set; }

        [XmlElement(ElementName = "ServiceType")]
        [Appearance("ServiceTypes_Visibility", "ServiceTypes.Exists()")]
        public List<Lookup> ServiceTypes { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup InsuranceType { get; set; }

        public string PlanCoverageDescription { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup TimePeriod { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public QualifiedAmount Quantity { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup InPlanNetwork { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup AuthorizationCertificationRequired { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public MedicalProcedure Procedure { get; set; }

        [XmlElement(ElementName = "Identification")]
        [Appearance("Identifications_Visibility", "NOT Identifications.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<Identification> Identifications { get; set; }

        [XmlElement(ElementName = "RequestValidation")]
        [Appearance("RequestValidations_Visibility", "NOT RequestValidations.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<RequestValidation> RequestValidations { get; set; }

        [XmlElement(ElementName = "Date")]
        [Appearance("Dates_Visibility", "NOT Dates.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<QualifiedDate> Dates { get; set; }

        [XmlElement(ElementName = "DateRange")]
        [Appearance("DateRanges_Visibility", "NOT DateRanges.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<QualifiedDateRange> DateRanges { get; set; }

        [XmlElement(ElementName = "Message")]
        [Appearance("Messages_Visibility", "NOT Messages.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<string> Messages { get; set; }

        [XmlElement(ElementName = "AdditionalInfo")]
        [Appearance("AdditionalInfos_Visibility", "NOT AdditionalInfos.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<EligibilityBenefitAdditionalInformation> AdditionalInfos { get; set; }

        [XmlElement(ElementName = "RelatedEntity")]
        [Appearance("RelatedEntities_Visibility", "NOT RelatedEntities.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<RelatedEntity> RelatedEntities { get; set; }
    }
}
