using System.Xml.Serialization;

namespace RedSpiderTech.StockDataNotifier.Data.Model.XML
{
    [XmlRoot(ElementName = "stock")]
    public class Stock
    {
        [XmlAttribute(AttributeName = "symbol")]
        public string Symbol { get; set; }
        [XmlAttribute(AttributeName = "percentageChangeThreshold")]
        public string PercentageChangeThreshold { get; set; }
    }
}
