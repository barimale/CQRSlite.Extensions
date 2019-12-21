using System.Threading;

namespace CQRSlite.Extensions.ReadModel.Queries.ExtraInit
{
    public interface IExtraInit
    {
        bool Initialize(string userId, CancellationToken token = default);
    }
}