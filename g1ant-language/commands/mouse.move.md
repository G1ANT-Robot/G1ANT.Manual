# mouse.move

**Syntax:**

```G1ANT
mouse.move  position ‴‴
```

**Description:**

Command `mouse.move` allows to move mouse cursor to a specified position.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`position`| [point](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/point.md) | yes |  | position to move mouse to in screen pixels |
|`relative`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | if true position is specified relative to active window. |
|`wait`| [integer](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/integer.md) | no |  | determines time in milliseconds between mouse 'jumps' to the specified position |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Language.dll**.

**Example 1:**

```G1ANT
mouse.move position 300⫽300 relative true
```

**Example 2:**

In this example we are using the `mouse.click` command to click a certain position on the desktop with a left button (we set the value for **button** argument to 'left'). In order to see how exactly `mouse.click` command works, please go to "mouse.click":{TOPIC-LINK+command-mouse-click} command.
In another step, we are using `mouse.move` command to move the mouse cursor with left button still down as the previous script line provides- it enables us to mark certain fragment on the screen. As you can see on the video, the cursor of the mouse moves in steps, **wait** argument is the time in milliseconds between mouse steps.

```G1ANT
mouse.click position 39⫽89 button ‴left‴ type ‴down‴ relative ‴false‴
mouse.move position 240⫽810 wait 3000 relative ‴false‴
mouse.click position 240⫽810 button ‴right‴ relative ‴false‴
```
