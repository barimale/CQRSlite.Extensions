using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSlite.Extensions.ReadModel.Queries.ExtraInit
{
    public class ObservablesRegisterPoint : IObservablesRegisterPoint
    {
        private readonly List<IExtraInit> services = new List<IExtraInit>();

        public void Register(IExtraInit service)
        {
            try
            {
                services.Add(service);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InitializeAsync(string userId, CancellationToken token)
        {
            try
            {
                List<Task<bool>> taskList = new List<Task<bool>>(services.Count);

                services.AsParallel().ForAll(p =>
                {
                    taskList.Add(Task.Run(() =>
                    {
                        return p.Initialize(userId, token);
                    }));

                });

                await Task.WhenAll(taskList.ToArray());

                return taskList.All(p => p.Result);
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
    }
}