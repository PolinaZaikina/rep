using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    public class SaturationParameters : IParameters
    {
        [ParameterInfo(Name = "Коэффициент",
            MinValue = 0,
            MaxValue = 10,
            DefaultValue = 1,
            Increment = 0.05)]
        public double Coefficient { get; set; }
    }
}
