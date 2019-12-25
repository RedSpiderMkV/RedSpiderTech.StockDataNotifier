namespace RedSpiderTech.StockDataNotifier.Data.Reader.Interface
{
    public interface IXmlDeserialiser<T>
    {
        T GetDeserialised();
    }
}