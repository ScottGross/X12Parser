using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;

namespace OopFactory.X12.Hipaa.Eligibility
{
    [XmlRoot(Namespace = "http://www.oopfactory.com/2011/XSL/Hipaa")]
    [DevExpress.ExpressApp.DC.DomainComponent]
    [EditorAlias(EditorAliases.ObjectPropertyEditor)]
    public class EligibilityBenefitResponse : EligibilityBenefitBase
    {
        public EligibilityBenefitResponse()
        {
            if (BenefitInfos == null) BenefitInfos = new List<EligibilityBenefitInformation>();
        }

        [XmlAttribute]
        public string TransactionControlNumber { get; set; }


        [XmlElement(ElementName = "BenefitInfo")]
        public List<EligibilityBenefitInformation> BenefitInfos { get; set; }



        #region Serialization Methods
        public string Serialize()
        {
            StringWriter writer = new StringWriter();
            new XmlSerializer(typeof(EligibilityBenefitResponse)).Serialize(writer, this);
            return writer.ToString();
        }

        public static EligibilityBenefitResponse Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EligibilityBenefitResponse));
            return (EligibilityBenefitResponse)serializer.Deserialize(new StringReader(xml));

        }

        #endregion
    }

}
