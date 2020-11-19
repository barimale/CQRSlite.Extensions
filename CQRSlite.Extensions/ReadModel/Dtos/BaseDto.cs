using CQRSlite.Extensions.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSlite.Extensions.ReadModel.Dtos
{
    public abstract class BaseDto : ISoftDelete, IPersonified
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }
        public string ExecutorId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
