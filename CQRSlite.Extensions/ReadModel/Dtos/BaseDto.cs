using CQRSlite.Extensions.Common;

namespace CQRSlite.Extensions.ReadModel.Dtos
{
    public abstract class BaseDto : ISoftDelete, IPersonified
    {
        public int Version { get; set; }
        public string ExecutorId { get; set; }
        public bool IsDeleted { get; set; }
    }
}