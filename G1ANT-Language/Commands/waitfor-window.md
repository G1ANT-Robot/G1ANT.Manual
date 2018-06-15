# waitfor.window

**Syntax:**

```G1ANT
waitfor.window  title ‴‴

```

**Description:**

Command `waitfor.window` waits for specified window to become focused.
| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`title`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes |  |specifies title of the window|
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no |  [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | name of variable where execution status will be stored |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | "♥timeoutwindow":{TOPIC-LINK+special-variables} | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1**: 

This example opens notepad using `program` command, then opens firefox using `selenium.open` command, then `waitfor.window` command waits for notepad to be brought to the front. 

```G1ANT
program notepad timeout 5000
selenium.open type ‴firefox‴ url ‴http://google.pl‴
waitfor.window title ‴Untitled - Notepad‴ timeout 5000 

```

 !{IMAGE-LINK+waitforwindow}! 

**Example 2:**

```G1ANT
ie.open url ‴g1ant.com‴
excel.open
waitfor.window title ‴G1ANT - Internet Explorer‴ timeout 10000

```