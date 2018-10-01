using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace OopFactory.X12.Hipaa.Common
{
    public enum GenderEnum
    {
        Unknown,
        Male,
        Female
    }
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class Member : Entity
    {
        [XmlAttribute]        
        public GenderEnum Gender { get; set; }

        [XmlIgnore]
        public DateTime? DateOfBirth { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Lookup Relationship { get; set; }
        
        #region Serializable DateOfBirth Properties
        [Browsable(false)]
        [XmlAttribute(AttributeName="DateOfBirth", DataType="date")]
        public DateTime SerializableDateOfBirth 
        {
            get { return DateOfBirth ?? DateTime.MinValue; }
            set { DateOfBirth = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public bool SerializableDateOfBirthSpecified 
        {
            get { return DateOfBirth.HasValue; }
            set {}
        }
        #endregion



        [XmlAttribute]
        public string MemberId
        {
            get
            {
                if (Name != null && Name.Identification != null && Name.Identification.Qualifier == "MI")
                    return Name.Identification.Id;
                else
                    return GetReferenceId("1W");
            }
            set { }
        }

        [XmlAttribute]
        public string Ssn
        {
            get { return GetReferenceId("SY"); }
            set { }
        }

        [XmlAttribute]
        public string PlanNumber
        {
            get { return GetReferenceId("18"); }
            set { }
        }

        [XmlAttribute]
        public string GroupNumber
        {
            get { return GetReferenceId("6P"); }
        }
    }
}
