using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class ZeroDelenie : ApplicationException
    {
        public ZeroDelenie(string message) : base(message) { }
        
    }
}
