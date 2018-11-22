# list.create

**Syntax:**

```G1ANT
list.create  text ‴‴  separator ‴‴
```

**Description:**

Command `list.create` creates new list based on provided string which contains separators like \";'/[]\".
| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`text`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | yes |  | string to be parsed to list |
|`separator`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | yes|  | separator used to create list |
|`type`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | no |  | the expected "type of structure":{TOPIC-LINK+types-of-variables} the list consists of  (lists can be of one type only) |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)  | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | name of variable where command's result will be stored |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Language.dll**.

**Example 1**:

```G1ANT
list.create text ‴Johan, Samanta, Aren, Eve, Michael‴ separator ‴,‴ result ♥nameList
dialog ♥nameList
```

**Example 2:**

```G1ANT
list.create text ‴Eggs-Flour-Milk‴ separator ‴-‴ result ♥foodList
dialog ♥foodList
```

**Example 3:**

```G1ANT
♥list1 = ‴John‴❚‴Alba‴❚‴Tom‴
dialog ♥list1
```

Another way to create a list is  by simply typing `♥list1 = ‴John‴❚‴Alba‴❚‴Tom‴`.
Then you would always have to use one type of separator- array separator (you can access it by CTRL + |)
