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
    public class BenefitMember : Member
    {
        public BenefitMember()
        {
            if (Diagnoses == null) Diagnoses = new List<Lookup>();
            if (RequestValidations == null) RequestValidations = new List<RequestValidation>();
            if (Dates == null) Dates = new List<QualifiedDate>();
            if (DateRanges == null) DateRanges = new List<QualifiedDateRange>();
        }

        [XmlAttribute]
        public string BirthSequenceNumber { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        [Appearance("ProviderInfo_Visibility", "NOT ProviderInfo.Exists()", Visibility = ViewItemVisibility.Hide)]
        public ProviderInformation ProviderInfo { get; set; }

        [XmlElement(ElementName = "Diagnosis")]
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        [Appearance("Diagnoses_Visibility", "NOT Diagnoses.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<Lookup> Diagnoses { get; set; }

        [XmlElement(ElementName = "RequestValidation")]
        [Appearance("RequestValidations_Visibility", "NOT RequestValidations.Exists()", Visibility = ViewItemVisibility.Hide)]
        public new List<RequestValidation> RequestValidations { get; set; }

        [XmlElement(ElementName = "Date")]
        [Appearance("Dates_Visibility", "NOT Dates.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<QualifiedDate> Dates { get; set; }

        [XmlElement(ElementName = "DateRange")]
        [Appearance("DateRanges_Visibility", "NOT DateRanges.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<QualifiedDateRange> DateRanges { get; set; }

        #region PlanDate properties
        public DateTime? PlanDate
        {
            get
            {
                var date = Dates.FirstOrDefault(d => d.Qualifier == "291");
                return date?.Date;
            }
        }

        [XmlAttribute(AttributeName = "PlanDate", DataType = "date")]
        [Browsable(false)]
        public DateTime SerializablePlanDate => PlanDate ?? DateTime.MinValue;

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializablePlanDateSpecified => PlanDate.HasValue;

        #endregion

        #region PlanBeginDate properties
        public DateTime? PlanBeginDate
        {
            get
            {
                var date = Dates.FirstOrDefault(d => d.Qualifier == "346");
                return date?.Date;
            }
        }

        [XmlAttribute(AttributeName = "PlanBeginDate", DataType = "date")]
        [Browsable(false)]
        public DateTime SerializablePlanBeginDate => PlanBeginDate ?? DateTime.MinValue;

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializablePlanBeginDateSpecified => PlanBeginDate.HasValue;

        #endregion

        #region PlanEndDate properties
        public DateTime? PlanEndDate
        {
            get
            {
                var date = Dates.FirstOrDefault(d => d.Qualifier == "347");
                return date?.Date;
            }
        }

        [XmlAttribute(AttributeName = "PlanEndDate", DataType = "date")]
        [Browsable(false)]
        public DateTime SerializablePlanEndDate => PlanEndDate ?? DateTime.MinValue;

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializablePlanEndDateSpecified => PlanEndDate.HasValue;

        #endregion

        #region EligibilityDate properties
        public DateTime? EligibilityDate
        {
            get
            {
                var date = Dates.FirstOrDefault(d => d.Qualifier == "307");
                return date?.Date;
            }
        }

        [XmlAttribute(AttributeName = "EligibilityDate", DataType = "date")]
        [Browsable(false)]
        public DateTime SerializableEligibilityDate => EligibilityDate ?? DateTime.MinValue;

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializableEligibilityDateSpecified => EligibilityDate.HasValue;

        #endregion

        #region EligibilityBeginDate properties
        public DateTime? EligibilityBeginDate
        {
            get
            {
                var date = Dates.FirstOrDefault(d => d.Qualifier == "356");
                return date?.Date;
            }
        }
        [Browsable(false)]
        [XmlAttribute(AttributeName = "EligibilityBeginDate", DataType = "date")]
        public DateTime SerializableEligibilityBeginDate => EligibilityBeginDate ?? DateTime.MinValue;

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializableEligibilityBeginDateSpecified => EligibilityBeginDate.HasValue;

        #endregion

        #region EligibilityEndDate properties
        public DateTime? EligibilityEndDate
        {
            get
            {
                var date = Dates.FirstOrDefault(d => d.Qualifier == "357");
                return date?.Date;
            }
        }

        [XmlAttribute(AttributeName = "EligibilityEndDate", DataType = "date")]
        [Browsable(false)]
        public DateTime SerializableEligibilityEndDate => EligibilityEndDate ?? DateTime.MinValue;

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializableEligibilityEndDateSpecified => EligibilityEndDate.HasValue;

        #endregion
    }
}
