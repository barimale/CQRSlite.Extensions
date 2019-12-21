using System;

namespace CQRSlite.Extensions.Common
{
    [Serializable]
    public class TrackedTag
    {
        public TrackedTag()
        {
            //intentionally left blank
        }

        public TrackedTag(Guid id, int version)
            : this()
        {
            Id = id;
            Version = version;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}