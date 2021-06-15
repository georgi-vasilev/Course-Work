namespace CourseWork.Data.Seeder.Dtos
{
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class ImportCardsDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("ImageUrl")]
        public string ImageUrl { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Attack")]
        public int Attack { get; set; }

        [XmlElement("Defense")]
        public int Defense { get; set; }
    }
}
