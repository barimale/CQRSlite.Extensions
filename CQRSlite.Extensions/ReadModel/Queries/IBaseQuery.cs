using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSlite.Extensions.ReadModel.Queries
{
    public interface IBaseQuery<TDbSet>
    {
        Task<List<TDbSet>> GetAllAsync(string userId);
    }
}