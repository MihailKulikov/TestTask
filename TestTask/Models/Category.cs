﻿using System.Xml.Serialization;

namespace TestTask.Models
{
    [XmlRoot(ElementName = "category")]
	public class Category
	{
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		
		[XmlText]
		public string Text { get; set; }
		
		[XmlAttribute(AttributeName = "parentId")]
		public string ParentId { get; set; }
	}
}