using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Utilities
{
    static class StringUtils
    {
        public static string[] TrimAndSplit(String toModify, char seperator)
        {
            string[] split = toModify.Split(seperator);
            foreach(string field in split)
            {
             field.Trim();
            }

            return split;
        }
    }
}
