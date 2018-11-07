# try

**Syntax:**

```G1ANT
try
end try
```

**Description:**

`try` command checks if everything that is inside `try` and `end try` can be executed, if there is an error, something different will be executed depending on our specifications using error arguments.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeout](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no |  | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1:**

In this example window under the "blah" name will be brought to front otherwise procedure ➤oops will be called.

```G1ANT
try errorcall ➤oops
   window blah timeout 1000
end try
procedure ➤oops
   dialog ‴oops window not found‴
end procedure
```

**Example 2:**

This example does the same but in case there is no "blah" window, robot will jump to ➜oops label.

```G1ANT
try errorjump ➜oops
   window blah timeout 1000
end try
➜oops
dialog ‴oops window not found‴
```
