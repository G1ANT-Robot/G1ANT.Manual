# if

**Syntax:**

```G1ANT
if condition ‴‴
end if
```

**Description:**

`if` command allows to run some part of script depending on conditions set which return value true. It ends with `end if` command.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`condition`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes |  | if the condition in C# snippet returns true, robot will execute everything that is between `if` and `end if` or `if` and `else if` or `if` and `else` |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeout](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no |  | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

`if` command may also contain other commands: `else if` and `else`.
If the first condition after `if` is not met, robot will check if the below condition after `else if` command is met. I will do it as many times as there are `else if` commands between `if` and `end if` or if one condition is finally met (then it will execute what is between elses). If not, then robot will execute everything that is between `else` and `end if`.
See the example below for a clearer picture how it works.

**Example 1:**

In this example the variable ♥number is being checked for its value and depending on it, accurate dialog is displayed in the dialog box.

```G1ANT
♥number = 2
if ♥number==1
   dialog one
else if ♥number==2
   dialog two
else if ♥number==3
   dialog three
else
   dialog ‴number greater than 3 or less than 1‴
end if
```
