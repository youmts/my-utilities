using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureClassLibrary
{
    public class StringSplitter
    {
        /// <summary>
        /// 入力Textを指定Encodingで指定byteLengthでSplitする
        /// Split(...).Firstとすると最初の分のみ処理する
        /// </summary>
        /// <param name="text"></param>
        /// <param name="byteLength"></param>
        /// <param name="enc"></param>
        /// <returns></returns>
        public IEnumerable<string> Split(string text, int byteLength, Encoding enc)
        {
            if(byteLength <= 0) throw new ArgumentException("byteLength <= 1");

            if (text == "")
            {
                yield return "";
                yield break;
            }

            StringBuilder nowString = new StringBuilder();
            int nowCount = 0;
            foreach (var c in text)
            {
                var str = c.ToString();
                var len = enc.GetByteCount(str);;

                if (nowCount + len > byteLength)
                {
                    yield return nowString.ToString();
                    nowString = new StringBuilder(str);
                    nowCount = len;
                }
                else
                {
                    nowString.Append(str);
                    nowCount += len;
                }
            }

            if (nowString.Length > 0) yield return nowString.ToString();
        }
    }
}
