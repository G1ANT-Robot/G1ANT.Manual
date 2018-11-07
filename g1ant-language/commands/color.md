# color

**Syntax:**

```text
color  position ‴‴
```

**Description:**

Command `color` retrieves the red, green, blue \(RGB\) color value of the pixel at the specified coordinates. Returned value is in hexadecimal format described as RRGGBB.

| Argument | Type | Required | Default Value | Description |
| :--- | :--- | :--- | :--- | :--- |
| `position` | [point](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/point.md) | yes |  | X,Y coordinates |
| `relative` | [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | false | coordinates can be set in absolute position \(argument relative false\) or relatively \(argument relative true\) to the active window |
| `result` | [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md) | name of variable where returned value will be stored \(in hexadecimal format described as RRGGBB\) |
| `if` | [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
| `timeout` | [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no |  | name of the label to jump to if given `timeout` expires |
| `errormessage` | [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md) manual page.

This command is contained in **G1ANT.Language.dll.**

**Example:**

This example checks color for provided pixel \(one from this green background\) and returns it as window dialog \("dialog":{TOPIC-LINK+command-dialog} command\).

```text
color position ‴610⫽507‴ relative false
dialog ♥result
```

