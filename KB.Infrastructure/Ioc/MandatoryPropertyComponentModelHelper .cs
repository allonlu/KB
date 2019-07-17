using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Ioc
{
    public class MandatoryPropertyComponentModelHelper : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            foreach (var property in model.Properties)
            {
                if (property.Property.GetCustomAttributes(inherit: true).Any(x => x is MandatoryAttribute))
                {
                    property.Dependency.IsOptional = false;
                }
            }
        }
    }
}
