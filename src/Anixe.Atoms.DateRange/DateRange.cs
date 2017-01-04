using System;

namespace Anixe.Atoms
{
  public struct DateRange
  {
    public readonly DateTime From;
    public readonly DateTime To;

    public DateRange(DateTime from, DateTime to)
    {
      this.From = from;
      this.To = to;
    }

    public bool Includes(DateTime val)
    {
      return val >= this.From && val <= this.To;
    }     

    public bool Includes(DateRange val)
    {
      return val.From >= this.From && val.To <= this.To;
    }     

    public override int GetHashCode()
    {
      return this.From.GetHashCode() ^ this.To.GetHashCode();
    }

    public bool Equals(DateRange obj) 
    {
      return this == obj;
    }

    public override bool Equals(Object obj) 
    {
      return obj is DateRange && this == (DateRange)obj;
    }

    public static bool operator ==(DateRange x, DateRange y) 
    {
      return x.From == y.From && x.To == y.To;
    }

    public static bool operator !=(DateRange x, DateRange y) 
    {
      return !(x == y);
    }

    public override string ToString()
    {
      return string.Concat(this.From.ToString(), ":", this.To.ToString());
    }
  }
}