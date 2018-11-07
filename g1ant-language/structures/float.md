# float

A float format represents a decimal number.

**Example 1:**

```G1ANT
♥var1 = 8.33
```

**Example 2:**

```G1ANT
♥num = 1.345
```

**Example 3:**

```G1ANT
♥dig = -0.14
```

**Example 4:**

```G1ANT
♥my_float = 123.2515664642
dialog ♥my_float
```

**Example 5:**

```G1ANT
♥price = ⟦float⟧399
dialog ♥price
```

In this example we are forcing the type of the variable using `⟦float⟧` formula. Forcing is not necessary, but useful when for example you are assigning a list with prices to a variable and some of them might be integers like 399, 459 and others may be float numbers like 399,99. If you force the type to `⟦float⟧`, then G1ANT.Robot will be aware than prices may not be integers. If you force type to `⟦integer⟧`, G1ANT.Robot will ignore floats and round numbers to integers.

**Example 6:**

In this example, G1ANT.Robot will dialog a list of integers, because we are forcing the type using `⟦list:integer⟧` formula.

```G1ANT
♥price_list = ⟦list:float⟧399.99❚458.59❚199❚19.50
dialog ♥price_list
```
