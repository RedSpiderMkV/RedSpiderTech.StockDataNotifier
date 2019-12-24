using System.Collections.Generic;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;

namespace RedSpiderTech.StockDataNotifier.Data.Reader.Interface
{
    public interface IInputFileReader
    {
        IEnumerable<string> Symbols { get; }
        IEnumerable<ITrackedData> TrackedDataCollection { get; }
    }
}
