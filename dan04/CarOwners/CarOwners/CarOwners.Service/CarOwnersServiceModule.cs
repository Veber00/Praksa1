using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CarOwners.Service.Common;

namespace CarOwners.Service
{
    public class CarOwnersServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarOwnersService>().As<ICarOwnersService>();
            base.Load(builder);
        }
    }
}
