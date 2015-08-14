using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VSversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var registry = Registry.ClassesRoot;
            var subKeyNames = registry.GetSubKeyNames();
            var regex = new Regex(@"^VisualStudio\.edmx\.(\d+)\.(\d+)$");
            foreach (var subKeyName in subKeyNames)
            {
                var match = regex.Match(subKeyName);
                if (match.Success)
                    Console.WriteLine("V" + match.Groups[1].Value + "." + match.Groups[2].Value);
            }
        }
    }
}
