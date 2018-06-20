# test

**Syntax:**

```G1ANT
test  condition ⊂⊃ 
```

**Description:**

Command `test` allows to check if the expression in argument **condition** is true and jump to label if needed.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`condition`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | yes| | argument with condition to pass the test, insert C# macro here |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1**:

In this example, two variables are compared. If they are not equal, **condition** argument is not fulfilled.

```G1ANT
♥text = ‴bananas and kiwi‴
♥web = ‴orange‴
test condition ⊂♥test==♥web⊃ errormessage ‴Text orange not found‴
```



**Example 2:**

In this example, variable is compared to a string. They are not equal, so the condition is not fulfilled, we set an **errorjump** argument that jumps over `dialog ‴Yes! Chris likes bananas!‴` to `dialog ‴Sorry, Chris doesn't like bananas!‴` if the condition is false.

```G1ANT
♥text = ‴Chris likes apples‴
test condition ⊂♥text == "Chris likes bananas"⊃ errorjump ➜banana
dialog ‴Yes! Chris likes bananas!‴
stop silentmode true
➜banana
dialog ‴Sorry, Chris doesn't like bananas!‴
```

 

**Example 3:**

```G1ANT
test condition ⊂♥environment⟦HOMEDRIVE⟧=="C:"⊃
test condition ⊂♥environment⟦OS⟧ != "Windows*xp"⊃
dialog message ‴System settings ok.‴ 
```

**Example 4:**

```G1ANT
♥text = ‴bananas and kiwi‴
♥web = ‴bananas and kiwi‴
test condition ⊂♥text==♥web⊃
```

**Example 5:**

```G1ANT
♥text = ‴bananas and kiwi‴
♥web = ‴oranges‴
test condition ⊂♥text==♥web⊃
```
