using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuntingYardAlgorithm.Extension
{
    internal static class QueueExtension
    {
        internal static string PrintRawData(this Queue<IToken> tokens)
        {
            //IList<IToken> data = tokens.ToList();
            List<string> data = new List<string>();

            foreach (var item in tokens)
            {
                data.Add(item.RawValue.ToString());
            }
            string result = String.Join(" ", data);
            return result;
        }
    }
}
