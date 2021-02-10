using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CarOwners.Repository.Common;

namespace CarOwners.Repository
{
    public class CarOwnersRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarOwnersRepository>().As<ICarOwnersRepository>();
            base.Load(builder);
        }
    }
}
