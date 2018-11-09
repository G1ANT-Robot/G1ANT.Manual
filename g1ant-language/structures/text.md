# text

An object of text type stores text value.

## Example 1

This example shows how a text variable can be declared.

```G1ANT
♥text1 = ‴G1ANT‴
♥text2 = (text)‴Please call our support.‴
```

## Example 2

This example shows how to place special characters like enter (`\n`), tabulator (`\t`), etc. Before it is inserted somewhere with `keyboard` command, it needs to be stored in a variable (`♥test` for example).

```G1ANT
program notepad
♥test = ‴After this text, Enter will be placed⊂"\r\n"⊃Tabulator⊂"\t"⊃ "tab"⊂"\r\n"⊃Special chars:" \ / {(}{)}‴
keyboard ♥test
```

Note that these special characters were inserted into a variable using C# snippets (the text embraced with [macro signs](../special-characters/macro.md) `⊂⊃`).

Particular characters in a text can be addressed using the index notation embraced with [variable index](../special-characters/variable-index.md) double brackets (`⟦⟧`):

```G1ANT
♥mytext = ‴123456789ThisIsMyText‴

-addressing the 4th character in a text:
dialog ♥mytext⟦4⟧

-addressing characters from the 4th to the 13th of a text:
dialog ♥mytext⟦4:13⟧
```

   
