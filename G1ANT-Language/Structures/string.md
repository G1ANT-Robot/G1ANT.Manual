# string

A string is an object of type String which stores text value.



**Example 1:**

This example shows how string variable can be declared.

```G1ANT
♥text1 = ‴G1ANT‴
♥text2 = ⟦string⟧‴Please call our support.‴

```

**Example 2:**

This example shows how to place special characters like enter (
), tabulator(\t), etc. Before it will be inserted anywhere by `keyboard` command it needs to be stored in some variable (♥test as an example).

```G1ANT
program notepad
♥test = ‴After this text enter will be placed 
Tabulator\t "tab" 
Special chars:" \ / {(}{)}‴
keyboard ♥test

```

Characters in a string can be addressed using the notation of:

```G1ANT
♥mytext = ‴123456789ThisIsMyText‴
-addressing the 4th character in a string:
dialog ♥mytext⟦4⟧
-addressing characters from 4 to 13 of the string
dialog ♥mytext⟦4:13⟧

```
