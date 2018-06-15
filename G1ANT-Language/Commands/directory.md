# directory

**Syntax:**

```G1ANT
directory  path ‴‴ 
```

**Description:**

Command `directory` allows to obtain directory content and attach it to the variable.  

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`path`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes |  | directory path |
|`pattern`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | allows to filter results, e.g. file extensions, file names, type 'directory' to get only directories |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | "♥result":{TOPIC-LINK+special-variables-window} | name of variable where results will be stored as a [list](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md)  elements. To calculate number of elements, use `[count]` |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump`| [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1:**

This example shows how to easily list what provided directory contains.  In our case we are searching for files starting with '2017-12', there are only two in chosen path. After the script is executed, dialog window will pop up showing a list of results. The list is separated with list separators: ❚. 

```G1ANT
directory path ‴C:\Users\ania\Documents\G1ANT.Robot\logs‴ pattern ‴2017-12**‴
dialog ♥result
```

 

**Example 2:**

in this example the path argument is specified using variables- when you do that, G1ant.Robot will automatically retrieve all environment variable names and their values from the current process.
The information displayed in dialog windows indicates that there is one file with .txt extension is specified location and it is called '3rd video'.

```G1ANT
directory path ‴♥environment⟦HOMEDRIVE⟧♥environment⟦HOMEPATH⟧\Desktop‴  pattern ‴**.txt‴ result ♥res1
dialog ♥res1
```

 

**Example 3:**

In this case, G1ANT.Robot will calculate the number of specified items in specified directory thanks to `dialog ♥res1⟦count⟧` line.

```G1ANT
directory path ‴♥environment⟦HOMEDRIVE⟧♥environment⟦HOMEPATH⟧\Desktop‴  pattern ‴**.txt‴ result ♥res1
dialog ♥res1⟦count⟧
```
