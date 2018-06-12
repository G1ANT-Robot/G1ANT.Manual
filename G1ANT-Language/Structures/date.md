# date

**date ⟦date⟧**

The date format stores information about the date.

**Example 1:**

This example shows how dates can be declared. Please note that while declaring a date, you need to force the type by using `⟦date⟧` formula before declaring the content of the variable inside of ‴ ‴.
As for the format of date, you can either use `/` or `.`

```G1ANT
♥mydate = ⟦date⟧‴8/07/2016‴
```

```G1ANT
♥mydate2 = ⟦date⟧‴2.04.2017‴
```


**Example 2:**

Elements of date (year, month, day) can be accessed as follows:

```G1ANT
♥mydate=⟦date⟧‴8.07.2016‴
dialog ♥mydate
dialog ♥mydate⟦year⟧
dialog ♥mydate⟦month⟧
dialog ♥mydate⟦day⟧
```

