# stop

**Syntax:**

```G1ANT
stop
```

**Description:**

The `stop` command stops the process and shows a dialog box message.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`silentmode`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | false | if set to 'true', silently finishes the script without showing errors, set to 'false' shows errors   |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if a command throws an exception |
|`errorcall` | "procedure":{TOPIC-LINK+procedure}| no | | name of the procedure to call if a command throws an exception |
|`errorresult` | "error":{TOPIC-LINK+errorresult}| no | | name of a variable, which will store the returned exception |
|`errormessage`| "text":{TOPIC-LINK+text}| no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump`, `errorcall`, `errorresult` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1:**

```G1ANT
stop
```

**Example 2:**

```G1ANT
♥r = 3
stop if ⊂♥r ==3⊃
```

**Example 3:**

In this example, G1ANT.Robot, thanks to setting **silentmode** argument, will silently close the script without showing an error dialog.

```G1ANT
♥r = 3
stop if ⊂♥r ==3⊃ silentmode true
```
