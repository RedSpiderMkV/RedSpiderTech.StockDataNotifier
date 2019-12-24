using System.Collections.Generic;
using System.Xml.Serialization;

namespace RedSpiderTech.StockDataNotifier.Data.Model.XML
{
    [XmlRoot(ElementName = "stockAlerts")]
    public class StockAlerts
    {
        [XmlElement(ElementName = "stock")]
        public List<Stock> Stock { get; set; }
    }
}
