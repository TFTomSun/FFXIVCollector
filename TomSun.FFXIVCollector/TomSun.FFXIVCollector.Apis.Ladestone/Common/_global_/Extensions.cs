using System;
using System.Collections.Generic;
using System.Text;


    public static class StringExtensions
    {
        public static int ToInt32(this string value)
        {
            return int.Parse(value);
        }
    }

