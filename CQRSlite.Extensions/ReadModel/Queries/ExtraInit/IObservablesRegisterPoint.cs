using System.Threading;
using System.Threading.Tasks;

namespace CQRSlite.Extensions.ReadModel.Queries.ExtraInit
{
    public interface IObservablesRegisterPoint
    {
        Task<bool> InitializeAsync(string userId, CancellationToken token = default);

        void Register(IExtraInit service);
    }
}