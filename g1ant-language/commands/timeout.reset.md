# timeout.reset

h1. KOMENDA NIE DZIALA!!!!!

**Syntax:**

```G1ANT
timeout.reset value number if true errorjump ➜labelname errormessage ‴‴
```

**Description:**

Command `timeout.reset` allows you to reset global timeout.

| Name | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`value`| "integer":{TOPIC-LINK+object}| yes | | resets to certain number of seconds |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if "if" condition is true |
|`errorjump`| [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | ➜labelname | name of the label to jump to if given timeout expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no | ‴ ‴ | message that will be shown in case error occurs and no `errorjump` argument is specified |
|`timeout`| [integer](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/integer.md) | no | [♥timeout](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies maximum number of milliseconds to wait for command to execute |

