using System;
using System.Globalization;

namespace Anixe.Atoms
{
  public static class DateRangeExtensions
  {
    public static DateRange FromString(string val, char delimiter = ':', string format = "yyyyMMdd")
    {
      var cu = CultureInfo.InvariantCulture;
      DateTime from;
      DateTime to;
      if(val.Contains(delimiter.ToString()))
      {
        var segments = val.Split(delimiter);
        if(segments.Length != 2)
        {
          throw new FormatException(val);
        }
        from  = DateTime.ParseExact(segments[0], format, cu);
        to  = DateTime.ParseExact(segments[1], format, cu);
      }
      else if(val.Contains("+"))
      {
        from  = DateTime.ParseExact(val.TrimEnd('+'), format, cu);
        to  = DateTime.MaxValue;
      }
      else
      {
        from  = DateTime.ParseExact(val, format, cu);
        to = from;
      }
      return new DateRange(from <= to ? from : to ,to >= from ? to : from);
    }    
  }
}