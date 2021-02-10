using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CarOwners.Model.Common;

namespace CarOwners.Model
{
    public class CarOwnersModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<Car>().As<ICar>();
            base.Load(builder);
        }
    }
}
