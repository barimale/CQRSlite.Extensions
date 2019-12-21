using CQRSlite.Commands;
using CQRSlite.Extensions.Common;
using System;

namespace CQRSlite.Extensions.WriteModel.Commands
{
    public abstract class BaseCommand : ICommand, IPersonified
    {
        public string ExecutorId { get; set; }
        public Guid Id { get; set; }
        public int ExpectedVersion { get; set; }
    }
}