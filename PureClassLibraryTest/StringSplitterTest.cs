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
        private static Encoding enc = Encoding.GetEncoding("Shift-JIS");

        [Theory]
        [InlineData("", 10, "")]
        [InlineData("あいうえお", 1, "")]
        [InlineData("あいうえお", 4, "あい")]
        [InlineData("あいうえお", 5, "あい")]
        [InlineData("あいうえお", 6, "あいう")]
        [InlineData("あいうえお", 9, "あいうえ")]
        [InlineData("あいうえお", 10, "あいうえお")]
        [InlineData("あいうえお", 11, "あいうえお")]
        [InlineData("あいうえお", 100, "あいうえお")]
        void SplitTest(string input, int byteLength, string expectedFirst)
        {
            var ss = new StringSplitter();
            ss.Split(input, byteLength, enc)
                .First().Is(expectedFirst);
        }

        [Fact]
        void MultiSplitTest()
        {
            var ss = new StringSplitter();
            ss.Split("あいうえお", 5, enc)
                .Is("あい", "うえ", "お");
            ss.Split("あいうえお", 4, enc)
                .Is("あい", "うえ", "お");
        }
    }
}
