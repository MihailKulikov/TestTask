using System.Xml.Serialization;

namespace TestTask.Models
{
    [XmlRoot(ElementName = "yml_catalog")]
	public class YmlCatalog
	{
		[XmlElement(ElementName = "shop")]
		public Shop Shop { get; set; }
		
		[XmlAttribute(AttributeName = "date")]
		public string Date { get; set; }
	}
}