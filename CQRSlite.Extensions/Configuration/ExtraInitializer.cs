using CQRSlite.Extensions.ReadModel.Queries.ExtraInit;
using Ninject;
using Ninject.Modules;
using System.Linq;

namespace CQRSlite.Extensions.Configuration
{
    public class ExtraInitializer : NinjectModule
    {
        public override void Load()
        {
            try
            {
                var extraInits = Kernel.GetAll<IExtraInit>().ToList();
                var observablesRegistrer = Kernel.Get<IObservablesRegisterPoint>();

                extraInits.ForEach(p =>
                {
                    observablesRegistrer.Register(p);
                });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
