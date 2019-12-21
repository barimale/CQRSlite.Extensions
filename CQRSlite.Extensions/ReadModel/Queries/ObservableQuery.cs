using ConfigurationManager.Api.Helper.Adapters;
using CQRSlite.Extensions.ReadModel.Dtos;
using CQRSlite.Extensions.ReadModel.Queries.ExtraInit;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Abstracts;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Where;

namespace CQRSlite.Extensions.ReadModel.Queries
{
    public abstract class ObservableQuery<TTable> : IExtraInit, IObservableQuery<TTable>
        where TTable : BaseDto, new()
    {
        private SqlTableDependency<TTable> Table;
        private string connectionString;
        private string connectionStringName;
        private IAdapter _adapter;

        public ObservableQuery(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ObservableQuery(IAdapter adapter, string connectionStringName)
        {
            _adapter = adapter;
            this.connectionStringName = connectionStringName;
        }

        public abstract string TableName { get; }

        public event EventHandler<RecordChangedEventArgs<TTable>> RecordChangeRaised;

        public bool Initialize(string userId, CancellationToken token)
        {
            try
            {
                return Task.Run(() =>
                {
                    var finalConnectionString = _adapter == null ?
                        connectionString : 
                        _adapter.ConnectionStrings(this.connectionStringName);

                    Expression<Func<TTable, bool>> filterExpression = p => p.ExecutorId == userId;

                    ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<TTable>(filterExpression);

                    Table = new SqlTableDependency<TTable>(
                        finalConnectionString,
                        TableName,
                        filter: whereCondition);

                    Table.OnChanged += OnChangeRaised;
                    Table.OnError += Table_OnError;
                    Table.Start();

                    return true;
                }, token).Result;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Table_OnError(object sender, ErrorEventArgs e)
        {
            var builder = new StringBuilder();

            builder.Append("Table_OnError: ");
            builder.Append("sender: ");
            builder.Append(sender.ToString());
            builder.AppendLine();

            builder.Append("ErrorEventArgs: ");
            builder.Append(e.Message);

            Console.WriteLine(builder.ToString());

            try
            {
                Table.Stop();
                Table.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnChangeRaised(object sender, RecordChangedEventArgs<TTable> e)
        {
            EventHandler<RecordChangedEventArgs<TTable>> handler = RecordChangeRaised;
            handler?.Invoke(this, e);
        }
    }
}