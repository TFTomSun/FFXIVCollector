using System;
using System.Collections.Generic;
using System.Text;

public static class UrlExtensions
{
    public static Uri AddParameter(this Uri uri, string name, string value)
    {
        UriBuilder x = new UriBuilder(uri);
        var parameterValue = $"{name}={value}";
        x.Query =  x.Query.IsNullOrEmpty() ? parameterValue : x.Query + "&"+ parameterValue;
        var result = x.Uri;
        return result;
        var attach = string.Empty;
        if (uri.Query.IsNullOrEmpty())
        {
            if (!uri.AbsolutePath.EndsWith("/"))
            {
                attach += "/";
            }
            attach += "?";
        }
        attach+=$"{name}={value}";

        return new Uri(uri.AbsolutePath + attach);
    }
}
    public static class StringExtensions
    {
        public static int ToInt32(this string value)
        {
            return int.Parse(value);
        }
    }

