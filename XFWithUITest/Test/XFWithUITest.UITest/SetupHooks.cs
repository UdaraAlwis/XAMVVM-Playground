using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace XFWithUITest.UITest
{
    public class SetupHooks
    {
        public static IApp App { get; set; }

        public static Platform Platform { get; set; }
    }
}