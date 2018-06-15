# file.delete

**Syntax:**

```G1ANT
file.delete  

```

**Description:**

Command `file.delete` aims to delete the file specified by filename. It waits given timeout and when the expected file does not appear or cannot be deleted, it jumps to the defined label or stops the process.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`filename`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | path and filename of the expected file |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | name of variable where execution status will be stored |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1:**

This example shows how to check if expected file will appear in given timeout, and delete the file when it appears.

```G1ANT
file.exists filename ‴C:\G1ANT\test.txt‴ timeout 1000 errorjump ➜notfound
dialog ‴File exists‴
jump ➜delete
➜notFound
dialog ‴File doesn't exist‴
jump ➜end
➜delete
file.delete C:\G1ANT\test.txt
dialog ♥result
➜end

```

**Example 2:**

Please, bear in mind that in order to delete a file, you need to have permission to access it.

```G1ANT
file.delete filename ‴C:\Tests\TestLogo.png‴

```