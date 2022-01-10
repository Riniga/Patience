using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idioten
{
    public static class Extensions
    {     
        public static string ToStringFirstletterUpper(this string input)
        {
            return string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
        }
    }
}
