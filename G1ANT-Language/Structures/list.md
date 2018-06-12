# list

**list**

**Syntax:**

```G1ANT
♥list = ‴value1‴❚‴value 2‴❚‴value 3‴
dialog ♥list 
dialog ♥list⟦2⟧ 
```

**Description:**

List is a special type of data that enables to store multiple countable ordered values within a single variable. It behaves as a 'container' and the values can occur a number of times. However, every value inside of a list has to be separated by an array separator - ❚. What is more, the values have to be of the same type- either string, number, datetime, date, etc. If you accidentally insert a different value type inside of a list, G1ANT.Robot will convert it to the type of the first value from the list, because the first element defines the type. 
Please check the topic "array separator":{TOPIC-LINK+array-separator}

**Accessing values inside of a list:**

Any list element can be obtained using variable's name followed by `[1,2...n]` (see Example 1).
A new element can also be added to the existing table (see Example 2 &amp; 3).
To count the number of list elements, follow the variable's name with `⟦count⟧` (see Example 4).

**Examples:**

Example 1

```G1ANT
♥arr = ‴apple‴❚‴mango‴❚‴melon‴❚‴kiwi‴
dialog ♥arr[0]
```

!{IMAGE-LINK+2016-11-21}! 

Example 2

```G1ANT
♥arr = ‴apple‴❚‴mango‴❚‴melon‴❚‴kiwi‴
dialog ♥arr⟦count⟧
```

!{IMAGE-LINK+2016-11-21-3}!