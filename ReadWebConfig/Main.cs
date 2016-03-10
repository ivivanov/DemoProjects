using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ReadWebConfig
{
    public class Program
    {
        public static void Main()
        {
            //CarsConfigSection customConfig = (CarsConfigSection)ConfigurationManager.GetSection("CarsConfig");
            Samples.AspNet.PageAppearanceSection config =
    (Samples.AspNet.PageAppearanceSection)System.Configuration.ConfigurationManager.GetSection(
    "pageAppearanceGroup/pageAppearance");

        }
    }
}
