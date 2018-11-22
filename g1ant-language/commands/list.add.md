# list.add

**Syntax:**

```G1ANT
list.add  list1 ‴‴  list2 ‴‴
```

**Description:**

Command `list.add` allows to create a new list by adding two existing. Required arguments: list1, list2
| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`list1`| [list](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/list.md) | yes | | first list to add|
|`list2`| [list](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/list.md) | yes |  | second list to add |
|`result`| "string":{TOPIC-LINK+variable} | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)   | name of variable where new list will be stored|
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Language.dll**.

**Example 1**:

This example adds two lists using `list.add` command. First we create two lists and then using `list.add` command we add them together. Afterwards we display added list (result) using `dialog` command.

```G1ANT
♥list1 = ‴foo1‴❚‴foo2‴❚‴foo3‴❚123❚‴45‴
♥list2 = ‴a‴❚‴b‴❚‴c‴
list.add list ♥list1 toadd ♥list2
dialog ♥result
```

**Example 2:**

```G1ANT
♥nameList = ‴John‴❚‴Alba‴❚‴Tom‴
list.add list ♥nameList toadd ‴Abraham‴❚‴Sammy‴ result ♥newList
dialog ♥newList
```

**Example 3:**

```G1ANT
♥nameList = ‴John‴❚‴Alba‴❚‴Tom‴
list.create text ‴Eggs-Flour-Milk‴ separator ‴-‴ result ♥foodList
list.add list ♥nameList toadd ♥foodList result ♥newList
dialog ♥newList
```

**Example 4:**

```G1ANT
list.add list ‴Leia‴❚‴Anakin‴❚‴Obi Wan‴ toadd ‴Vader‴❚‴Palpatine‴ result ♥newList
dialog ♥newList
```

**Example 5:**

This example shows another way of creating list using `list.create` command.

```G1ANT
list.create text ‴Johan,Samanta,Aren,Eve,Michael‴ separator ‴,‴ result ♥nameList
list.create text ‴Eggs-Flour-Milk‴ separator ‴-‴ result ♥foodList
list.add list ♥nameList toadd ♥foodList result ♥newList
dialog ♥newList
```

