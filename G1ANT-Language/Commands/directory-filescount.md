# directory.filescount

**Syntax:**

```G1ANT
directory.filescount  path ‴‴ 

```

**Description:**

Command `directory.filescount` allows to calculate the number of files of certain file extension, file name or file directory in specified location.  

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`path`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes | | path to the the directory where G1ANT.Robot should calculate the number of files |
|`pattern`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | this argument allows to filter results, e.g. file extensions, file names, type 'directory' to get only directories |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | "♥result":{TOPIC-LINK+special-variables-window} | name of variable where command's results will be stored |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [integer](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump`| [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This commands is contained in **G1ANT.Language.dll**.

**Example:**

This example shows how to calculate the number of files with '.docx' extension on the Desktop.

```G1ANT
directory.filescount path ‴C:\Users\user1\Desktop‴ pattern ‴**.docx‴ result ♥count
dialog ♥count  

```

The dialog window will show '2' result as there are only two .'docx' files

!{IMAGE-LINK+2017-12-04-directory-files-count}!