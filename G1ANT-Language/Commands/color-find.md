# color.find

**Syntax:**

```G1ANT
color.find  color ‴‴  position ‴‴  direction ‴‴ 
```

**Description:**

Command `color.find` allows to capture first pixel in a specified directory starting from predefined position that matches specified color.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`color`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | expected color in hex format defined as RRGGBB |
|`position`| [point](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/point.md) | yes |  | screen pixel coordinate of starting position |
|`direction`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | direction of search: down, up, right or left |
|`relative`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | coordinates can be set in absolute position (argument relative false) or relatively (argument relative true) to the active window |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | name of variable where returned [point](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/point.md)  will be stored (if not found point (-1,-1) will be returned) |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)  | no | [♥timeoutrest](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)| defines time in milliseconds for a command to wait before an error is thrown|
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |
|`errorjump`| [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no |  | name of the label to jump to if given `timeout` expires |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll.**

h4. Example:

This example shows how to find the first pixel which has required color (‴FFFFFF‴ - white in this case), starting from position X=50, Y=500 and going down.

```G1ANT
color.find color ‴FFFFFF‴ position ‴50⫽500‴ direction ‴down‴ relative false 
dialog ♥result  
```

The dialog box will show the result '50//500', because it turns out the first pixel in the position we specified is white.

 

You can see the position of the pixel- it is marked with blue color, but the pixel itself is white.


