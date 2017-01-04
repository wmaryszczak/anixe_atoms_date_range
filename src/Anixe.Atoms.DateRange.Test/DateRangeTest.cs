using System;
using System.Globalization;
using Xunit;

namespace Anixe.Atoms.Test
{
  public class DateRangeTest
  {
    [
      Theory
      InlineData("20170101:20170110", "20170102", true)
      InlineData("20170101:20170110", "20170111", false)
      InlineData("20170101:20170110", "20161211", false)
      InlineData("20170101:20170110", "20170101", true)
      InlineData("20170101:20170110", "20170110", true)
      InlineData("20170110:20170101", "20170110", true)
      InlineData("20170101+", "20170111", true)
      InlineData("20170101", "20170101", true)
      InlineData("20170101", "20170102", false)
    ]
    public void Should_Include_Date(string dateRange, string input, bool expected)
    {
      var dr = DateRangeExtensions.FromString(dateRange);
      var inputDate = DateTime.ParseExact(input, "yyyyMMdd", CultureInfo.InvariantCulture);
      Assert.Equal(expected, dr.Includes(inputDate));
    }

    [
      Theory
      InlineData("20170101:20170110", "20170101:20170110", true)
      InlineData("20170101:20170110", "20170102:20170109", true)
      InlineData("20170101:20170110", "20170102:20170111", false)
      InlineData("20170101:20170110", "20161230:20170109", false)
    ]
    public void Should_Include_DateRange(string dateRange, string input, bool expected)
    {
      var dr = DateRangeExtensions.FromString(dateRange);
      var inputRange = DateRangeExtensions.FromString(input);
      Assert.Equal(expected, dr.Includes(inputRange));
    }

    [Fact]
    public void Undefined_DateRange_Should_Be_Empty()
    {
      var dr = new DateRange();
      Assert.Equal(DateRange.Empty, dr);
    }
    
  }
}