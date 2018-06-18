# Array separator

**Syntax:**

```G1ANT
♥array = ‴element1‴❚‴element 2‴❚‴ele ment 3‴
```

**Description:**

In G1ANT.Language variables which are arrays can be defined. In an array multiple values can be held to pass them later to command or display specific value. It is not possible to use multiple types in the same list. 
`❚` **Array separator** - available at G1ANT Developer Studio -&gt; Menu Insert -&gt; Array separator.



**Example 1:**

```G1ANT
♥array = ‴element1‴❚‴element 2‴❚‴ele ment 3‴
dialog ♥array
```

 

**Example 2:**

```G1ANT
♥arr = ‴element1‴❚‴element 2‴❚‴ele ment 3‴
dialog ♥arr⟦1⟧
```

 

**Example 3:**

```G1ANT
♥arr = ⟦list:date⟧12/12/2007❚1/2/2017❚22/3/2018
dialog ♥arr⟦3⟧
```


