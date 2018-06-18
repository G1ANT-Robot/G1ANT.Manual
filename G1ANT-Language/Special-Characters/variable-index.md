# Variable index

**Syntax:**

```G1ANT
♥var = 124Kitty
♥var⟦4⟧
```

Above: accessing variable's 4th digit


```G1ANT
♥var = 1029384766647480
♥var⟦4:8⟧
```

Above: accessing variable's positions starting from 4th digit, ending at 8th digit

**Description:**

In G1ANT.Language particular indexes/characters in variables can be addressed. Using "a:b" notation, whole ranges of indexes in variables can be addressed.

`⟦⟧` **Variable index** - available at G1ANT Developer Studio -&gt; Menu Insert -&gt; Variable index.



**Example 1:**

```G1ANT
♥str = ‴123456789MyText‴
dialog ♥str⟦4⟧
```

 

**Example 2:**

```G1ANT
♥str = ‴123456789MyText‴
dialog ♥str⟦4:13⟧
```

 

**Example 3:**

```G1ANT
♥rect = 24⫽12⫽40⫽48
dialog ♥rect⟦height⟧
```


