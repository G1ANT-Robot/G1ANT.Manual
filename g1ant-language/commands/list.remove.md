# list.remove

**Syntax:**

```G1ANT
list.remove  list ‴‴ toremove ‴‴
```

**Description:**

Command `list.remove` allows to remove all specified elements from list.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`list`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | yes|  | list to be reduced |
|`toremove`| [list](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/list.md)  | yes|  | list of elements to be removed|
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)  | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | name of variable where new list will be stored |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Language.dll**.

**Example 1**:

In this example we are first creating a list using ';' separator and assigning it to a variable called ♥riverNames. In the next step we are creating a list using `list.create` argument.

```G1ANT
list.create text ‴Quiet Run;Moaning Beck;Gleaming Brook;Cirq Tributary‴ separator ‴;‴ result ♥riverNames
dialog ♥riverNames
list.create text ‴Moaning Beck‴ separator ‴,‴ result ♥toRemove
list.remove list ♥riverNames toremove ♥toRemove result ♥cleanList
dialog ♥cleanList
```

**Example 2:**

```G1ANT
list.create text ‴Quiet Run;Moaning Beck;Gleaming Brook;Cirq Tributary‴ separator ‴;‴ result ♥riverNames
dialog ♥riverNames
list.remove list ♥riverNames toremove ‴Moaning Beck❚‴ result ♥cleanList
dialog ♥cleanList
```

**Example 3:**

```G1ANT
♥MB = ‴Moaning Beck❚‴
list.remove list ‴Quiet Run❚Moaning Beck❚Gleaming Brook❚Cirq Tributary‴ toremove ♥MB result ♥cleanList
dialog ♥cleanList
```
