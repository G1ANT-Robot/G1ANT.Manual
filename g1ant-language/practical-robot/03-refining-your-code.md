# Refining Your Code

The code is never good enough. Of course, the golden rule of life says that if it ain't broke, don’t fix it — and we couldn’t agree more. But when you are practicing with programming, refinements are the part of the learning process. You learn new things and you can look back at your previous works to see if it’s possible to use your latest knowledge to optimize the code, make it clearer and more efficient.

In the past two exercises, you used some basic commands and logic. In the first code, you can notice that there are many lines that could be reduced to just one, using a list variable and a loop:

```G1ANT
excel.getvalue row ♥rownumber colname a result ♥cell1
excel.getvalue row ♥rownumber colname b result ♥cell2
excel.getvalue row ♥rownumber colname c result ♥cell3
excel.getvalue row ♥rownumber colname d result ♥cell4
excel.getvalue row ♥rownumber colname e result ♥cell5
excel.getvalue row ♥rownumber colname f result ♥cell6
```

There is the `♥rownumber` variable which takes its value from the `for` loop, so it stays the same in all 6 rows of the procedure. How can you make the other two arguments change incrementally in the same line as the first one? By employing a list variable and another loop.

Let’s start with the `♥cells` variable. Instead of creating a new variable for each cell, you could just create a list variable and add each cell’s content to this list as a value of a subsequent element. The resulting `♥cells` list variable in this case would look like this: `cell1❚cell2❚cell3❚cell4❚cell5❚cell6`. In order to move through the list elements, you would use the good old `foreach` loop or ordinary `for` loop and incremental indexing in the list variable.

The second approach would be even better, since you could apply the same incremental indexing in column addressing. “Wait”, you can ask, “how come? There are letters as values for the `colname` argument!”. Yes, you are absolutely right! This is why you won’t use that argument. Instead, you can refer to a more practical `colindex` argument, which operates on column numbers, not letters.

Before calling `GetValues` and `SetValues` procedures, you have to create an empty `♥cells` list variable and put it somewhere at the beginning of your script, after both `♥datafile` variables, for example:

```G1ANT
♥datafile1 = ‴♥environment⟦USERPROFILE⟧\Documents\Data\data.xlsx‴
♥datafile2 = ‴♥environment⟦USERPROFILE⟧\Documents\Data\data2.xlsx‴
list.create result ♥cells
```

The `for` loop, inside which the procedures are called, gives sequential row numbers to be used by the `row` argument and its  `♥rownumber` variable. In each row you want to process six cells in six columns. Therefore, for both procedures you have to set up another counter in the `for` loop, which will count from 1 to 6 and pass this value both to a column number in the `colindex` argument and a cell index in the `♥cells` list variable. Let’s name this counter `♥col` and insert the loop into each procedure:

```G1ANT
procedure GetValues
    excel.switch ♥excelid1
    for counter ♥col from 1 to 6
```

```G1ANT
procedure SetValues
    excel.switch ♥excelid2
    for counter ♥col from 1 to 6
```

Now it’s time to modify the `excel.getvalue` and the `excel.setvalue` commands to include the `colindex` argument and the `♥col` counter. The result of the `excel.getvalue` command — the value of a cell — is stored in the default `♥result` variable. You will add it to the `♥cells` list variable as a subsequent element thanks to the `list.add` command.

```G1ANT
procedure GetValues
    excel.switch ♥excelid1
    for counter ♥col from 1 to 6
        excel.getvalue row ♥rownumber colindex ♥col
        list.add ♥cells toadd ♥result
    end for
end procedure
```

```G1ANT
procedure SetValues
    excel.switch ♥excelid2
    for counter ♥col from 1 to 6
        excel.setvalue value ♥cells⟦♥col⟧ row ♥rownumber colindex ♥col
    end for
end procedure
```

Great! You managed to reduce couple of code lines in each procedure.

## Unsubscribing Improved

The exercise with automatic unsubscribing from the mailing list has one major flaw: it does delete a sender’s email address from the list, but this person’s other information persists. It would be great to erase the whole entry — not only the email address — from the file. In other words, to remove a line containing the email address to be unsubscribed.

In the final code, there is one line that deletes the email address from the list:

```G1ANT
text.replace ♥mailinglist search ♥address replace ‴‴ result ♥mailinglist
```

It simply replaces the matching address with an empty text. You can use the same `text.replace` command to delete a whole line. The only difference is that you will use the `regex` argument instead of `search`.

Regex stands for “regular expressions” and is a method of writing conditions when searching for particular strings. For more information on regex, please refer to a [Wikipedia entry](https://en.wikipedia.org/wiki/Regular_expression) and the [Regex Appendix](../../appendices/regex.md) to this manual.

The regex you are looking for should search for any text between the start and the end of the line containing the email address. If you read through the available expressions, you will find these blocks to build your regex:

* `\A` asserts position at start of the string,
* `\z` asserts position at the end of the string,
* `.*` matches any character (except for line terminators).

Put these block together in the following order: `\A.*♥address.*\z`. This regex translates into: start with the beginning of the line, then find any characters before and after the email address stored in the `♥address` variable, including this address, until the end of the line is reached.

Now change the `text.replace` command arguments:

```G1ANT
text.replace ♥mailinglist regex ‴\A.*♥address.*\z‴ replace ‴‴ result ♥mailinglist
```

This small correction in one line of your code makes a huge difference to the results you receive.
