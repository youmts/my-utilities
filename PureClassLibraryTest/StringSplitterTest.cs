using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureClassLibrary;
using Xunit;

namespace PureClassLibraryTest
{
    public class StringSplitterTest
    {
        [Theory]
        [InlineData("", 10, "")]
        void SplitTest(string input, int byteLength, string expected1, string expected2 = null)
        {
            var ss = new StringSplitter();
            var expected = (new[] {expected1, expected2}).Where(x => x != null);
            ss.Split(input, byteLength).Is(expected);
        }
    }
}
