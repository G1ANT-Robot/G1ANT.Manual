# list.indexof

**Syntax:**

```G1ANT
list.indexof  list ‴‴ value ‴‴
```

**Description:**

Command `list.indexof` returns index of specified value in defined list.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`list`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)  | yes | | variable holding a list or a list to search through |
|`value`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)   | yes |  | variable holding a list or a list to find |
|`alloccurances`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md)  | no | true | if set to true it will return all indexes of specified value, if set to false, it will return only first occurrence |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)  | no | [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | name of variable where command's result will be stored |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Addon.Language.dll**.

**Example 1**:

```G1ANT
list.create text ‴Johan,Samanta,Aren,Eve,Michael‴ separator ‴,‴ result ♥nameList
♥Sam = ‴Samanta‴
list.indexof list ♥nameList value ♥Sam alloccurances true result ♥position
dialog ♥position
```

in order to use `list.indexof` command, create a list `list.create` and give it a `result` argument so that it is stored in a variable. You can assign certain value to a variable, as we did `♥Sam = ‴Samanta‴`.
Then type `list.indexof` giving it `list` argument. The value of the argument is `♥nameList`, bacause we are storing the list in a variable. We did that while creating the list in `list.create` command.

**Example 2:**

```G1ANT
list.create text ‴Eggs-Flour-Milk-Eggs‴ separator ‴-‴ result ♥foodList
list.indexof list ♥foodList value ‴Eggs‴ alloccurances true result ♥position1
dialog ♥position1
```

The dialog window will give you two indexes of 'Eggs' value, because the `alloccurances` is true. If it is set on false, you will only get one index of the first 'Egg' value in the list.
