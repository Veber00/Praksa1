using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CarOwners.Model;
using CarOwners.Model.Common;
using CarOwners.Repository;
using CarOwners.Repository.Common;
using CarOwners.Service;
using CarOwners.Service.Common;
using System.Web;
using System.Web.Http;


namespace Container
{
    public class ContainerConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();
            
        }
    }
}
