using CQRSlite.Events;
using CQRSlite.Extensions.Common;
using System;

namespace CQRSlite.Extensions.ReadModel.Events
{
    [Serializable]
    public class BaseEvent : IEvent, IPersonified
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string ExecutorId { get; set; }
    }
}