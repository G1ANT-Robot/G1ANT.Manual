# program

```G1ANT
program  name ‴‴
```

**Description:**

Command `program` allows to run executable file of a program installed on a user’s system.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`name`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | program name or path to program’s executable file |
|`arguments`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | argument to pass to the launched application |
|`wait`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | "♥programwait"(https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | when the value is true, the robot performing the program command waits for program to run |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutprogram](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Language.dll**.

**Example 1:**

```G1ANT
program name ‴notepad‴
```

**Example 2:**

```G1ANT
program name ‴C:\Program Files\7-Zip\7zG.exe‴
```

**Example 3:**

```G1ANT
program name ‴C:\Documents\report.xls‴
```

**Example 4:**

In this example we are opening some notepad file from a path. The path is saved in a variable. `program.notepad` command can take **arguments** argument. Every program has its own list of arguments. In this case, for notepad, we are using **/p** to print the file.

```G1ANT
♥file = ‴♥environment⟦HOMEDRIVE⟧♥environment⟦HOMEPATH⟧\Desktop\test2.txt‴
program notepad arguments ‴/p ♥file‴
```
