using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureClassLibrary
{
    public class StringSplitter
    {
        public IEnumerable<string> Split(string text, int byteLength)
        {
            return new [] {text};
        }
    }
}
