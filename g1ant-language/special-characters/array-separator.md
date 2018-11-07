# Array Separator

## Syntax

```text
♥array = element1❚element 2❚ele ment 3
```

## **Description**

You can define array variables \(lists\) in G1ANT.Language. An array is used to store multiple values, which can then be passed to a command. It is not possible to use multiple variable types in the same list.

An array separator `❚` is available from `Insert/Array Separator` menu or with **Ctrl+\** keyboard shortcut.

### **Example 1**

```text
♥array = element1❚element 2❚ele ment 3
dialog ♥array
```

![img](../../.gitbook/assets/2018-01-04-array-separator_v1.jpg)

In the example above the `♥array` variable contains 3 elements: `element1`, `element 2` and `ele ment 3`. They are all displayed with the `dialog` command.

### **Example 2**

```text
♥array = element1❚element 2❚ele ment 3
dialog ♥array⟦1⟧
```

![img](../../.gitbook/assets/2018-01-04-array-separator-2_v1.jpg)

Here, the `dialog` command displays the first element of the `♥array` variable — as specified by`⟦1⟧` index.

### **Example 3**

```text
♥array = ⟦list:date⟧12/12/2007❚1/2/2017❚22/3/2018
dialog ♥array⟦3⟧
```

![](../../.gitbook/assets/array3.png)

In the first line the `♥array` variable is declared as a list of date type elements. The third element called by the  `dialog` command will be displayed in a proper date format.

