# color.expected

**Syntax:**

```G1ANT
color.expected  position ‴‴  color ‴‴ 
```

**Description:**

Command `color.expected` allows to wait until an RGB color appears in (X, Y) coordinates of the screen.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`position`| [point](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes |  | X,Y coordinates |
|`color`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes |  | expected color in hex format defined as RRGGBB |
|`relative`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | coordinates can be set in absolute position (argument relative false) or relatively (argument relative true) to the active window |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)   | name of a variable where returned value will be stored (in hexadecimal format described as RRGGBB)  |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcolorexpected](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds to wait for command to be executed |
|`errorjump`| [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll.**

**Example:**

This example shows how to check if in provided pixel, the color is exactly as expected (see the screenshot below, we would like to find this green one). In case the pixel is having the expected color, `errorjump` argument will be omited. `errorjump` argument will only be performed if the script before the `errorjump` agrument is false- in our case if the pixel of certain colour does not exist in certain location.

```G1ANT
color.expected position ‴610⫽507‴ color ‴06914C‴ relative false  errorjump ➜notfound
dialog ‴Color found‴
jump ➜finish
➜notfound
dialog ‴Color not found‴
➜finish
```


