using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestTask.Models
{
    [XmlRoot(ElementName = "shop")]
    public class Shop
    {
	    [XmlElement(ElementName = "name")]
		public string Name { get; set; }
		
		[XmlElement(ElementName = "company")]
		public string Company { get; set; }
		
		[XmlElement(ElementName = "url")]
		public string Url { get; set; }
		
		[XmlArray(ElementName = "currencies")]
		[XmlArrayItem(typeof(Currency), ElementName="currency")]
		public List<Currency> Currencies { get; set; }
		
		[XmlArray(ElementName = "categories")]
		[XmlArrayItem(typeof(Category), ElementName = "category")]
		public List<Category> Categories { get; set; }
		
		[XmlElement(ElementName = "local_delivery_cost")]
		public string LocalDeliveryCost { get; set; }
		
		[XmlArray(ElementName = "offers")]
		[XmlArrayItem(typeof(Offer), ElementName = "offer")]
		public List<Offer> Offers { get; set; }
	}
}