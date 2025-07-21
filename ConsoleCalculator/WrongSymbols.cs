using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class WrongSymbols : ApplicationException
    {
        public WrongSymbols(string message) : base(message) { }
    }
}
