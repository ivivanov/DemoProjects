using MemBus.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembusWithRX
{
    public class CustomBus : IConfigurableBus
    {
        public void AddService<T>(T service)
        {
            throw new NotImplementedException();
        }

        public void ConfigurePublishing(Action<IConfigurablePublishing> configure)
        {
            throw new NotImplementedException();
        }

        public void AddResolver(MemBus.ISubscriptionResolver resolver)
        {
            throw new NotImplementedException();
        }

        public void AddSubscription(MemBus.ISubscription subscription)
        {
            throw new NotImplementedException();
        }

        public void ConfigureSubscribing(Action<IConfigurableSubscribing> configure)
        {
            throw new NotImplementedException();
        }
    }
}
