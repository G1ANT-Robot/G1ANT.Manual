# jump

**Syntax:**

```text
jump  label ‴‴
```

**Description:**

Execution control flow command `jump` allows to move G1ANT.Robot's action to previously defined label or procedure located in a process. Please note: after doing the jump, the script will not go back to the previous line unless you specify another jump, back to another label.

| Argument | Type | Required | Default Value | Description |
| :--- | :--- | :--- | :--- | :--- |
| `label` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes |  | label name \(preceded with "➜"\) |
| `if` | [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
| `timeout` | [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | name of the label to jump to if given `timeout` expires |
| `errormessage` | [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit "Common Arguments":{TOPIC-LINK+common-arguments} manual page.

**Example 1:**

```text
program name ‴notepad‴
jump ➜start
keyboard ‴Jump over this text‴
➜start 
keyboard ‴Congratulation! You've made a jump!‴
```

In this example G1ANT.Robot opens notepad, then instead of typing ‴Jump over this text‴, it types ‴Congratulation! You've made a jump!‴ because we defined a jump command

```text
jump ➜start
keyboard ‴Jump over this text‴
➜start
```

which enables to omit certain part of the script between `jump ➜start` and `➜start`. In our case: `keyboard ‴Jump over this text‴`

**Example 2:**

```text
➜robot
dialog message ‴something to display‴
jump ➜end
jump label robot
➜end
dialog message ‴end‴
```

