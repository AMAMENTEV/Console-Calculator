using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class Poriadok : ApplicationException
    {
        public Poriadok(string message) : base(message) { }
    }
}
