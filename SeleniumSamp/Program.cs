using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"Resources\Dev.properties";
            ResourceManager rm = new ResourceManager("SeleniumSamp.Dev", Assembly.GetExecutingAssembly());
            String strWebsite = rm.GetString("appURL");
            String strName = rm.GetString("Name");
        }


    }
}
