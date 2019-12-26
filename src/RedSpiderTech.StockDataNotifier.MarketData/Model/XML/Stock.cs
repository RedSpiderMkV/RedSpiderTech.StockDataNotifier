using System.Xml.Serialization;

namespace RedSpiderTech.StockDataNotifier.Data.Model.XML
{
    [XmlRoot(ElementName = "stock")]
    public class Stock
    {
        [XmlAttribute(AttributeName = "symbol")]
        public string Symbol { get; set; }
        [XmlAttribute(AttributeName = "notificationChangePercentageRangeUpper")]
        public string PercentageChangeThresholdUpper { get; set; }
        [XmlAttribute(AttributeName = "notificationChangePercentageRangeLower")]
        public string PercentageChangeThresholdLower { get; set; }
    }
}
