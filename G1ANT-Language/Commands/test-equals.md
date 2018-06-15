# test.equals

**Syntax:**

```G1ANT
test.equals  current ‴‴  expected ‴‴

```

**Description:**

Command `test.equals` allows to check if current variable has expected value.
| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`current`|  [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | yes| | variable on which the test is performed (it can be a string, number, bool, rectangle) |
|`expected`|  [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | yes| | expected value of **current** |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1**: 

```G1ANT
♥text = ‴bananas and kiwi‴
text.find text ♥text search ‴orange‴ result ♥test 
test.equals current ♥test expected ‴orange‴ message ‴Text orange not found‴

```

**Example 2:**

```G1ANT
♥text = ‴Chris likes apples‴
test.equals current text expected ‴Chris likes bananas‴ jump ➜banana
dialog ‴Yes! Chris likes bananas!‴
➜banana
dialog ‴Sorry, Chris doesn't like bananas!‴

```