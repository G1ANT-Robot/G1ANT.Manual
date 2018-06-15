# text.replace

**Syntax:**

```G1ANT
text.replace  text ‴‴ replace ‴‴
```

**Description:**

Command `text.replace` allows to replace a string with other value within text or variable and assigns result to another variable.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`text`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes|  | inputs text or variable |
|`search`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |   | defines text to be searched within a variable or text |
|`regex`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no|   | defines regular expression to be found within a variable or text |
|`replace`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes|   | defines value to replace to |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)  | no |  [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | variable name for command’s result |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1:**

```G1ANT
♥source = ‴Name: John Surname: Smith‴
text.replace ♥source search ‴John‴ replace ‴Tom‴ result ♥name
dialog ♥name
```

**Example 2:**

In order to use `text.replace` command, first open a file with some text and assign its content to the `result` argument in a variable to use it later.

```G1ANT
text.read filename ‴C:\Users\user1\Desktop\tests\textwritetest.txt‴ result ♥read
dialog ♥read
text.replace text ♥read search ‴distributing‴ replace ‴flying‴ result ♥newText
dialog ♥newText
```

This is some text from our file:

 

`text.replace` command replaces word 'distributing' with 'flying'.

 

**Example 3:**

In this example, G1ANT.Robot searches for a word using regex expression and exchanges it with the word 'fox'.

```G1ANT
♥loremIpsum = ‴It's a fez. I wear a fez now. Fezes are cool. You hit me with a cricket bat. Saving the world with meals on wheels. I hate yogurt. It's just stuff with bits in.‴
text.replace text ♥loremIpsum regex ‴\b\w{3}\b‴ replace ‴fox‴ result ♥NN1
dialog ♥NN1
```


