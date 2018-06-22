# datetime

A datetime format stores information about date and time. 

**Example 1:**

This example shows how datetimes can be declared:

`♥dat = ⟦datetime⟧‴12:4:8‴` in this example, thanks to declaring (datetime), G1ANT.Robot  will get the information about the current date
`♥dat2 = ⟦datetime⟧‴10/05/2017 12:4:8‴` here the declared date is fixed

**Example 2:**

The date is not compulsory to specify. If only time is specified, the date is set as a current day.
Elements of datetime (year, month, day, hour, minute, second) can be accessed as follows:

```G1ANT
♥dat =  ⟦datetime⟧‴12:4:8‴
dialog ♥dat
dialog ♥dat⟦hour⟧
dialog ♥dat⟦year⟧
```

      
