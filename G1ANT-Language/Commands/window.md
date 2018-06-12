# window

**Syntax:**

```G1ANT
window  title ‴‴ 

```

**Description:**

Command `window` brings selected window to the front and activates it.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`title`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no|  | name of the window to activate. It can be obtained from menu Tools/Windows.|
|`style`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no|  |  arguments style defines the style of a window – maximized, minimized or restored (restore from minimized state)|
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | "♥timeoutwindow":{TOPIC-LINK+special-variables} | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

In order to access the names of all opened windows, you can use  `CTRL+W` shortcut.

!{IMAGE-LINK+2017-11-30-window}! 

**Example 1:**

In this example we want to activate Notepad window. In order to do this, despite the name of the Notepad file, there is always a "Notepad" word so we can bring this window to the front just by using `✱` sign in the following lines of code. Note that some names of windows might differ due to one's Operating System language.

```G1ANT
window ‴✱Notepad‴
window  ‴✱Notepad✱‴
window ‴filename✱pad‴

```

!{IMAGE-LINK+2016-11-18-17}! 

**Example 2:**

```G1ANT
window ‴✱notepad✱‴ style minimize
window ‴✱notepad✱‴ style restore
window ‴✱notepad✱‴ style maximize

```

**Video example 1:**

!{YOUTUBE-LINK+window-command}!