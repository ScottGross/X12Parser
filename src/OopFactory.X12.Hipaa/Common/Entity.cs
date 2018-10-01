using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;

namespace OopFactory.X12.Hipaa.Common
{
    [DevExpress.ExpressApp.DC.DomainComponent]
    public class Entity
    {
        public Entity()
        {
            if (Name == null) Name = new EntityName();
            if (Identifications == null) Identifications = new List<Identification>();
            if (Contacts == null) Contacts = new List<Contact>();
            if (RequestValidations!=null) RequestValidations = new List<RequestValidation>();
        }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public EntityName Name { get; set; }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public PostalAddress Address { get; set; }

        [XmlElement(ElementName="Identification")]
        [Appearance("Identifications_Visibility", "NOT Identifications.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<Identification> Identifications { get; set; }

        protected string GetReferenceId(string qualifier)
        {
            var reference = Identifications.FirstOrDefault(id => id.Qualifier == qualifier);
            if (reference != null)
                return reference.Id;
            else
                return null;
        }

        [XmlElement(ElementName="Contact")]
        [Appearance("Contacts_Visibility", "NOT Contacts.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<Contact> Contacts { get; set; }

        [XmlElement(ElementName = "RequestValidation")]
        [Appearance("RequestValidations_Visibility", "NOT RequestValidations.Exists()", Visibility = ViewItemVisibility.Hide)]
        public List<RequestValidation> RequestValidations { get; set; }

    }
}
