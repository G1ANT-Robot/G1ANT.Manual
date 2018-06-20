# text.find

**Syntax:**

```G1ANT
text.find  text ‴‴
 
**Description:**
```

Command `text.find` allows to search for text within text or variable and assign result to another variable.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`text`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | yes| |inputs text or variable|
|`search, search2, search3`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | no |  |defines text to be found within variable or text|
|`regex`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | no |  |defines regular expression to be found within variable or text|
|`casesensitivity`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md)  | no | true | turns on case sensitivity |
|`result`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md)  | no |  [♥result](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  | the variable with the name passed in the result argument will be list type |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutcommand](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md)  | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll**.

**Example 1:**

This example creates variable ♥source and using `text.find` command we search for 'John'. Finally, the result is prompted in dialog window using `dialog` command.

```G1ANT
♥source = ‴Name: John Surname: Smith‴
text.find ♥source search Name:✱Surname: result ♥name
dialog ♥name
```

 

**Example 2:**

This example creates variable ♥address and using `text.find` command with specified 'regex' we search for results. Finally, the result is prompted in dialog window using `dialog` command.

```G1ANT
♥address = ‴57B Rathbone Place‴
text.find text ♥address regex ‴(\d+)-?(\d+)**(\D)?(w+)?‴ result ♥house
dialog ♥house
```

 

**Example 3:**

```G1ANT
♥catText = ‴Wack the mini furry mouse run outside as soon as door open yet run in circles, or try to jump onto window and fall while scratching at wall so munch on tasty moths or sweet beast. Play time destroy the blinds, and jump around on couch, meow constantly until given food, so meow to be let in. ‴
text.find text ♥catText search ‴Wack✱in.‴ search2 ‴window✱blinds‴ search3 ‴at wall so✱. Play‴ 
result ♥textBefore
dialog ♥textBefore
```

 

**Example 4:**

```G1ANT
♥adress = ‴53 Bullimore Street‴
text.find text ♥adress regex ‴(\d+)-?(\d+)**(\D)?(w+)?‴ result ♥house
dialog ♥house
```

 

**Example 5:**

```G1ANT
♥html = ‴&lt;html&gt;&lt;body&gt;This is fake page With some spaces&lt;crazydiv&gt;`#$**&amp; and special ch`rs !09 &lt;number&gt;123&lt;/number&gt;();&lt;/crazydiv&gt; '|+&lt;/body&gt;&lt;/html&gt;‴
text.find text ♥html search ‴&lt;html&gt;✱&lt;/html&gt;‴ search2 ‴&lt;crazydiv&gt;✱&lt;/crazydiv&gt;‴ regex ‴\d\d\d‴ result ♥toExpect
dialog ♥toExpect 
```


