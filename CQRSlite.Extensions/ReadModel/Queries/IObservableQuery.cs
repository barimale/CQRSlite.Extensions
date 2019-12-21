using System;
using TableDependency.SqlClient.Base.EventArgs;

namespace CQRSlite.Extensions.ReadModel.Queries
{
    public interface IObservableQuery<TTable>
        where TTable : class, new()
    {
        event EventHandler<RecordChangedEventArgs<TTable>> RecordChangeRaised;
    }
}