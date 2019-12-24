using System.Collections.Generic;

namespace RedSpiderTech.StockDataNotifier.Data.Reader.Interface
{
    public interface IInputFileReader
    {
        IEnumerable<string> Symbols { get; }
    }
}
