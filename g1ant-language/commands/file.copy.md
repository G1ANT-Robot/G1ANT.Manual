# file.copy

**Syntax:**

```G1ANT
file.copy  path ‴‴  destinationpath ‴‴
```

**Description:**

Command `file.copy` allows to copy specified file to the specified path (in `destinationpath`).

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`path`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | a source path to copy from |
|`destinationpath`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | a path specifying where we are copying the file (can be absolute or relative) |
|`overwrite`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command even if a file of the same name exists in the destination location |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1:**

This example copies specified file using `file.copy` command.

```G1ANT
file.copy path ‴D:\New folder\test.txt‴ destinationpath ‴D:\New folder\copied_file.txt‴
```

Same results can be achieved by using:

```G1ANT
file.copy path ‴D:\New folder\test.txt‴ destinationpath ‴copied_file.txt‴
```

or, if the file needs to be copied to "D:\New Folder 1", however leave the file name unchanged:

```G1ANT
file.copy path ‴D:\New folder\test.txt‴ destinationpath ‴..\New Folder 1‴
```

Before using the script:

After using the script:

**Example 2:**

```G1ANT
file.exists C:\Tests\TestLogo.png timeout 1000 errorcall ➤noFile
file.copy path ‴C:\Tests\TestLogo.png‴ destinationpath ‴C:\Tests\TestLogo2.png‴ overwrite true
-
procedure ➤noFile
    dialog ‴File not found‴
end procedure
```
