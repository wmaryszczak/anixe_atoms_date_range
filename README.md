# date_range
```
var dr = new DateRange(DateTime.Now, DateTime.Now.AddDays(3));
Assert.True(dr.Includes(DateTime.Now.AddDays(1)));
Assert.False(dr.Includes(DateTime.Now.AddDays(5)));


var dr = DateRange.FromString("20171110:20171113");
Assert.True(dr.Includes(new DateTime(2016,11,11)));
Assert.False(dr.Includes(new DateTime(2016,11,14)));


var dr = DateRange.FromString("20171113:20171110");
Assert.Equals(new DateTime(2016,11,10), dr.From);
Assert.Equals(new DateTime(2016,11,13), dr.To);

```
