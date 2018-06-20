# chrome

**Syntax:**

```G1ANT
chrome  url ‴‴ 
```

**Description:**

Command `chrome` opens Google Chrome browser and displays specified page. 

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`url`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes| | web address to be displayed in Google Chrome browser |
| `if` | [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutchrome](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | defines time in milliseconds for Google Chrome to launch |
| `errorjump`  | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no |  | name of the label to jump to if given `timeout` expires |
| `errormessage ` | [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no | | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll.**

**Example 1:**

```G1ANT
chrome url ‴https://www.google.co.uk/search?q=g1ant‴
```

 

This example opens a website and waits 5 seconds (thanks to "delay":{TOPIC-LINK+command-delay} command) till it loads, afterwards "keyboard":{TOPIC-LINK+command-keyboard} command emulates TAB key and presses it twice, then presses ENTER. Finally "http://irpaai.com/membership/":http://irpaai.com/membership/ opens. Sometimes the advertising banner displays on this website, so by pressing ESC key, we made sure that despite this ad, the automation will still work.

**Example 2:**

```G1ANT
chrome url ‴www.irpanetwork.com‴
delay 5
keyboard ⋘esc⋙⋘tab 2⋙⋘enter⋙
```

 


